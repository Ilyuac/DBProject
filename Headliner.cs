using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace sql
{
    public partial class Headliner : Form
    {
        #region GlodalVar
        Transaction transaction = new Transaction();
        SqlConnection connection;
        string Login; List<string> IdPerson = new List<string>();
        bool select = true; int kol = 0;
        public struct Table
        {
            public string NomberOrder;
            public string NomberBrigad;
            public string Check;
            public string Reason;
            public string NameWork;
            public string Price;
            public Table(string nomberOrder, string nomberBrigad, string check, string reason, string nameWork, string price)
            {
                NomberOrder = nomberOrder;
                NomberBrigad = nomberBrigad;
                Check = check;
                Reason = reason;
                NameWork = nameWork;
                Price = price;
            }
        }
        int i = 0;
        #endregion

        public Headliner(string login)
        {
            Login = login;
            InitializeComponent();
            AddCheck.Checked = false;
            AddCheck.Checked = true;
            SelectConect.Checked = false;
            YearReport.Maximum = Convert.ToInt32(DateTime.Now.Year);
            YearReport.Minimum = YearReport.Maximum - 2;
            YearReport.Value = Convert.ToInt32(DateTime.Now.Year);
            //загрузка данных о сотруднике
            LoadWorkers();
        }       

        private void Headliner_FormClosing(object sender, FormClosingEventArgs e)
        {
            transaction.CloseConnect();
            transaction.CloseApp(Login);
        }

        private void SelectConnect_CheckedChanged(object sender, EventArgs e)
        {
            if(SelectConect.Checked==true)
                textBoxPassword.Enabled = true;
            else
                textBoxPassword.Enabled = false;
        }

        private void AddCheck_CheckedChanged(object sender, EventArgs e)
        {
            textBoxLogin.Enabled = true;
            textBoxName.Enabled = true;
            TextBoxPhone.Enabled = true;
            textBoxWork.Enabled = true;
            buttonDoCheck.Text = "Добавить";
            butBack.Enabled = false;
            butNext.Enabled = false;
            textBoxLogin.Clear();
            textBoxName.Clear();
            TextBoxPhone.Clear();
            textBoxWork.Clear();
            textBoxPassword.Clear();
        }

        private void UpdateCheck_CheckedChanged(object sender, EventArgs e)
        {
            textBoxLogin.Enabled = true;
            textBoxName.Enabled = true;
            TextBoxPhone.Enabled = true;
            textBoxWork.Enabled = true;
            buttonDoCheck.Text = "Сохранить";
            LoadWorker();
            butNext.Enabled = true;
            butBack.Enabled = true;
            if (i == 0)
            {butBack.Enabled = false;}
        }

        private void DeleteCheck_CheckedChanged(object sender, EventArgs e)
        {
            textBoxLogin.Enabled = true;
            textBoxName.Enabled = false;
            TextBoxPhone.Enabled = false;
            textBoxWork.Enabled = false;
            buttonDoCheck.Text = "Удалить";
            LoadWorker();
            butNext.Enabled = true;
            butBack.Enabled = true;
            if (i == 0)
            {butBack.Enabled = false;}
        }

        private void buttonDoCheck_Click(object sender, EventArgs e)
        {
            bool QuestionDo = false, Update=false;
            connection = transaction.Connection();
            string query = "", mess = ""; string[] querys = new string[4];
            if (AddCheck.Checked==true)
            {
                query = "INSERT INTO [Сотрудники]([Логин], [ФИО_Сотрудника], [Телефон_Сотрудника], [Должность], [Пароль]) VALUES (@login, @name, @phone, @work, @password)";
                QuestionDo = true;
                Update = false;
                mess = "Новый сотрудник добавлен успешно.";
            }
            if(UpdateCheck.Checked==true)
            {                
                querys[0] = "UPDATE Сотрудники SET [ФИО_Сотрудника] = @name WHERE Логин=@login";
                querys[1]= "UPDATE Сотрудники SET [Телефон_Сотрудника]=@phone WHERE Логин=@login";
                querys[2]= "UPDATE Сотрудники SET [Должность]=@work WHERE Логин=@login";
                querys[3]= "UPDATE Сотрудники SET [Пароль]=@password WHERE Логин=@login";
                QuestionDo = false;
                Update = true;
                mess = "Данные сотрудника успешно изменены.";
            }
            if(DeleteCheck.Checked==true)
            {
                query = "DELETE FROM Сотрудники WHERE Логин=@login";
                if(MessageBox.Show("Вы уверены, что хотите удалить запись в журнале.", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    QuestionDo = false;
                    Update = false;
                    mess = "Сотрудник успешно удален.";
                }
            }
            SqlCommand commandQuery=null;
            if (Update)
            {
                for (int j = 0; j < querys.Length; j++)
                {
                    commandQuery = new SqlCommand(querys[j], connection);
                    commandQuery.Parameters.AddWithValue("login", textBoxLogin.Text);
                    commandQuery.Parameters.AddWithValue("name", textBoxName.Text);
                    commandQuery.Parameters.AddWithValue("phone", TextBoxPhone.Text);
                    commandQuery.Parameters.AddWithValue("work", textBoxWork.Text);
                    if (AddCheck.Checked == true)
                    {
                        if (SelectConect.Checked == true)
                            commandQuery.Parameters.AddWithValue("password", textBoxPassword.Text);
                        else
                            commandQuery.Parameters.AddWithValue("password", "");
                    }
                    else
                        commandQuery.Parameters.AddWithValue("password", textBoxPassword.Text);
                    commandQuery.ExecuteNonQuery();
                }
            }
            else
            {
                commandQuery = new SqlCommand(query, connection);
                if (QuestionDo)
                {
                    commandQuery.Parameters.AddWithValue("login", textBoxLogin.Text);
                    commandQuery.Parameters.AddWithValue("name", textBoxName.Text);
                    commandQuery.Parameters.AddWithValue("phone", TextBoxPhone.Text);
                    commandQuery.Parameters.AddWithValue("work", textBoxWork.Text);
                    if (AddCheck.Checked == true)
                    {
                        if (SelectConect.Checked == true)
                            commandQuery.Parameters.AddWithValue("password", textBoxPassword.Text);
                        else
                            commandQuery.Parameters.AddWithValue("password", "");
                    }
                    else
                        commandQuery.Parameters.AddWithValue("password", textBoxPassword.Text);
                }
                else
                { commandQuery.Parameters.AddWithValue("login", textBoxLogin.Text); i--; }
                commandQuery.ExecuteNonQuery();
            }
            MessageBox.Show(mess, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            transaction.CloseConnect();
            IdPerson.Clear();
            LoadWorkers();
        }

        private void butDay_Click(object sender, EventArgs e)
        {           
            connection = transaction.Connection();
            DateTime date = Convert.ToDateTime(DateDayRaport.Text);
            SqlCommand commandSerchRow = new SqlCommand("SELECT Заказ.НомерЗаявки, НомерБригады, Отметка_о_Выполнении, Причина, Наименование_Работ, Цена FROM Заказ,Заявки,Информация_о_Заявке,Отказы,Список_работ,Прайс_лист WHERE Заказ.НомерЗаявки=Информация_о_Заявке.НомерЗаявки and Заявки.НомерЗаявки=Информация_о_Заявке.НомерЗаявки and Заявки.Код_Отказа=Отказы.Код_Отказа and Информация_о_Заявке.НомерЗаявки=Список_работ.НомерЗаявки and Список_работ.Код_Работ=Прайс_лист.Код_Работ and Заказ.Дата_исполнения_заказа=@date", connection);
            commandSerchRow.Parameters.AddWithValue("date", date.ToShortDateString());
            SqlDataReader readerSerchRow = commandSerchRow.ExecuteReader();
            List<Table> table = new List<Table>();
            while (readerSerchRow.Read())
            {
                Table tempTable;
                tempTable.NomberOrder = readerSerchRow["НомерЗаявки"].ToString();
                tempTable.NomberBrigad = readerSerchRow["НомерБригады"].ToString();
                tempTable.Check = readerSerchRow["Отметка_о_Выполнении"].ToString();
                tempTable.Reason = readerSerchRow["Причина"].ToString();
                tempTable.NameWork = readerSerchRow["Наименование_Работ"].ToString();
                tempTable.Price = readerSerchRow["Цена"].ToString();
                table.Add(tempTable);
            }
            readerSerchRow.Close();
            Word.Application app = new Word.Application();
            Word.Document docWord = app.Documents.Open(@"G:\Sql\SQL\sql\Library\template\DayReport.docx", Visible: true, ReadOnly: false);
            app.Visible = false;
            Word.Bookmarks bookmark = docWord.Bookmarks;
            Word.Range range;
            Word.Bookmark mark = bookmark[1];
            range = mark.Range;
            range.Text = DateDayRaport.Text;
            mark = bookmark[2];
            range = mark.Range;
            Word.Table tableWord = docWord.Tables.Add(range, table.Count + 1/*строки*/, 6/*столбцы*/);
            tableWord.Borders.Enable = 1;
            tableWord.Rows[1].Cells[1].Range.Text ="Номер заказа";
            tableWord.Rows[1].Cells[2].Range.Text = "Номер бригады";
            tableWord.Rows[1].Cells[3].Range.Text = "Выполнено";
            tableWord.Rows[1].Cells[4].Range.Text = "Отказ";
            tableWord.Rows[1].Cells[5].Range.Text = "Работы";
            tableWord.Rows[1].Cells[6].Range.Text = "Цена";
            string newOrder= "";
            for(int i=1;i<table.Count;i++)
            {
                if (table[i].NomberOrder != newOrder)
                {
                    tableWord.Rows[i + 1].Cells[1].Range.Text = table[i].NomberOrder;
                     newOrder=table[i].NomberOrder;
                }
                tableWord.Rows[i + 1].Cells[2].Range.Text = table[i].NomberBrigad;
                tableWord.Rows[i + 1].Cells[3].Range.Text = table[i].Check;
                tableWord.Rows[i + 1].Cells[4].Range.Text = table[i].Reason;
                tableWord.Rows[i + 1].Cells[5].Range.Text = table[i].NameWork;
                tableWord.Rows[i + 1].Cells[6].Range.Text = table[i].Price;
                kol+= Convert.ToInt32(table[i].Price);
            }
            tableWord.Rows[table.Count+2].Cells[5].Range.Text = "ИТОГО";
            tableWord.Rows[table.Count + 2].Cells[6].Range.Text = kol.ToString();
            kol = 0;
            transaction.CloseConnect();           
            DateTime Data = Convert.ToDateTime(DateDayRaport.Text);
            MessageBox.Show("Суточный отчет за "+Data.ToShortDateString()+" сформирован.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string link = String.Concat(@"G:\Sql\SQL\sql\Library\Reports\", "R",Data.ToShortDateString(), ".docx");
            docWord.SaveAs2(link);
            docWord.Close();
            app.Quit();
        }

        private void butError_Click(object sender, EventArgs e)
        {
            connection = transaction.Connection();
            DateTime date = Convert.ToDateTime(DateError.Text);
            SqlCommand commandSerchRow = new SqlCommand("SELECT Заказ.НомерЗаявки, НомерБригады, Отметка_о_Выполнении, Причина, Наименование_Работ, Цена FROM Заказ,Заявки,Информация_о_Заявке,Отказы,Список_работ,Прайс_лист WHERE Заказ.НомерЗаявки=Информация_о_Заявке.НомерЗаявки and Заявки.НомерЗаявки=Информация_о_Заявке.НомерЗаявки and Заявки.Код_Отказа=Отказы.Код_Отказа and Информация_о_Заявке.НомерЗаявки=Список_работ.НомерЗаявки and Список_работ.Код_Работ=Прайс_лист.Код_Работ and Заказ.Дата_исполнения_заказа=@date", connection);
            commandSerchRow.Parameters.AddWithValue("date", date.ToShortDateString());
            SqlDataReader readerSerchRow = commandSerchRow.ExecuteReader();
            List<Table> table = new List<Table>();
            while (readerSerchRow.Read())
            {
                Table tempTable;
                if (readerSerchRow["Причина"].ToString() != "-")
                {
                    tempTable.NomberOrder = readerSerchRow["НомерЗаявки"].ToString();
                    tempTable.NomberBrigad = readerSerchRow["НомерБригады"].ToString();
                    tempTable.Check = readerSerchRow["Отметка_о_Выполнении"].ToString();
                    tempTable.Reason = readerSerchRow["Причина"].ToString();
                    tempTable.NameWork = readerSerchRow["Наименование_Работ"].ToString();
                    tempTable.Price = readerSerchRow["Цена"].ToString();
                    table.Add(tempTable);
                }
            }
            readerSerchRow.Close();
            Word.Application app = new Word.Application();
            Word.Document docWord = app.Documents.Open(@"G:\Sql\SQL\sql\Library\template\ErrorReport.docx", Visible: true, ReadOnly: false);
            app.Visible = false;
            Word.Bookmarks bookmark = docWord.Bookmarks;
            Word.Range range;
            Word.Bookmark mark = bookmark[1];
            range = mark.Range;
            range.Text = DateError.Text;
            mark = bookmark[2];
            range = mark.Range;
            Word.Table tableWord = docWord.Tables.Add(range, table.Count + 1/*строки*/, 6/*столбцы*/);
            tableWord.Borders.Enable = 1;
            tableWord.Rows[1].Cells[1].Range.Text = "Номер заказа";
            tableWord.Rows[1].Cells[2].Range.Text = "Номер бригады";
            tableWord.Rows[1].Cells[3].Range.Text = "Выполнено";
            tableWord.Rows[1].Cells[4].Range.Text = "Отказ";
            tableWord.Rows[1].Cells[5].Range.Text = "Работы";
            tableWord.Rows[1].Cells[6].Range.Text = "Цена";
            string newOrder = "";
            for (int i = 1; i < table.Count; i++)
            {
                if (table[i].NomberOrder != newOrder)
                {
                    tableWord.Rows[i + 1].Cells[1].Range.Text = table[i].NomberOrder;
                    newOrder = table[i].NomberOrder;
                }
                tableWord.Rows[i + 1].Cells[2].Range.Text = table[i].NomberBrigad;
                tableWord.Rows[i + 1].Cells[3].Range.Text = table[i].Check;
                tableWord.Rows[i + 1].Cells[4].Range.Text = table[i].Reason;
                tableWord.Rows[i + 1].Cells[5].Range.Text = table[i].NameWork;
                tableWord.Rows[i + 1].Cells[6].Range.Text = table[i].Price;
                kol += Convert.ToInt32(table[i].Price);
            }
            tableWord.Rows[table.Count + 2].Cells[5].Range.Text = "ИТОГО";
            tableWord.Rows[table.Count + 2].Cells[6].Range.Text = kol.ToString();
            kol = 0;
            transaction.CloseConnect();
            DateTime Data = Convert.ToDateTime(DateError.Text);
            MessageBox.Show("Отчет по отказам за " + Data.ToShortDateString() + " сформирован.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string link = String.Concat(@"G:\Sql\SQL\sql\Library\Reports\", "ED", Data.ToShortDateString(), ".docx");
            docWord.SaveAs2(link);
            docWord.Close();
            app.Quit();
        }

        private void butYard_Click(object sender, EventArgs e)
        {
            connection = transaction.Connection();
            SqlCommand commandSerchRow = new SqlCommand("SELECT Заказ.НомерЗаявки, НомерБригады, Отметка_о_Выполнении, Причина, Наименование_Работ, Цена, Дата_исполнения_заказа FROM Заказ,Заявки,Информация_о_Заявке,Отказы,Список_работ,Прайс_лист WHERE Заказ.НомерЗаявки=Информация_о_Заявке.НомерЗаявки and Заявки.НомерЗаявки=Информация_о_Заявке.НомерЗаявки and Заявки.Код_Отказа=Отказы.Код_Отказа and Информация_о_Заявке.НомерЗаявки=Список_работ.НомерЗаявки and Список_работ.Код_Работ=Прайс_лист.Код_Работ", connection);
            SqlDataReader readerSerchRow = commandSerchRow.ExecuteReader();
            List<Table> table = new List<Table>();
            while (readerSerchRow.Read())
            {
                Table tempTable;
                if (readerSerchRow["Дата_исполнения_заказа"].ToString().Split('.')[2] == YearReport.Value.ToString())
                {
                    tempTable.NomberOrder = readerSerchRow["НомерЗаявки"].ToString();
                    tempTable.NomberBrigad = readerSerchRow["НомерБригады"].ToString();
                    tempTable.Check = readerSerchRow["Отметка_о_Выполнении"].ToString();
                    tempTable.Reason = readerSerchRow["Причина"].ToString();
                    tempTable.NameWork = readerSerchRow["Наименование_Работ"].ToString();
                    tempTable.Price = readerSerchRow["Цена"].ToString();
                    table.Add(tempTable);
                }
            }
            readerSerchRow.Close();
            Word.Application app = new Word.Application();
            Word.Document docWord = app.Documents.Open(@"G:\Sql\SQL\sql\Library\template\YearReport.docx", Visible: true, ReadOnly: false);
            app.Visible = false;
            Word.Bookmarks bookmark = docWord.Bookmarks;
            Word.Range range;
            Word.Bookmark mark = bookmark[1];
            range = mark.Range;
            range.Text = DateError.Text;
            mark = bookmark[2];
            range = mark.Range;
            Word.Table tableWord = docWord.Tables.Add(range, table.Count + 1/*строки*/, 6/*столбцы*/);
            tableWord.Borders.Enable = 0;
            tableWord.Rows[1].Cells[1].Range.Text = "Номер заказа";
            tableWord.Rows[1].Cells[2].Range.Text = "Номер бригады";
            tableWord.Rows[1].Cells[3].Range.Text = "Выполнено";
            tableWord.Rows[1].Cells[4].Range.Text = "Отказ";
            tableWord.Rows[1].Cells[5].Range.Text = "Работы";
            tableWord.Rows[1].Cells[6].Range.Text = "Цена";
            string newOrder = "";
            for (int i = 1; i < table.Count; i++)
            {
                if (table[i].NomberOrder != newOrder)
                {
                    tableWord.Rows[i + 1].Cells[1].Range.Text = table[i].NomberOrder;
                    newOrder = table[i].NomberOrder;
                }
                tableWord.Rows[i + 1].Cells[2].Range.Text = table[i].NomberBrigad;
                tableWord.Rows[i + 1].Cells[3].Range.Text = table[i].Check;
                tableWord.Rows[i + 1].Cells[4].Range.Text = table[i].Reason;
                tableWord.Rows[i + 1].Cells[5].Range.Text = table[i].NameWork;
                tableWord.Rows[i + 1].Cells[6].Range.Text = table[i].Price;
                kol += Convert.ToInt32(table[i].Price);
            }
            tableWord.Rows[table.Count + 2].Cells[5].Range.Text = "ИТОГО";
            tableWord.Rows[table.Count + 2].Cells[6].Range.Text = kol.ToString();
            kol = 0;
            transaction.CloseConnect();
            MessageBox.Show("Годовой отчет за " + YearReport.Value.ToString() + " сформирован.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string link = String.Concat(@"G:\Sql\SQL\sql\Library\Reports\", "RY", YearReport.Value.ToString(), ".docx");
            docWord.SaveAs2(link);
            docWord.Close();
            app.Quit();
        }

        #region Печать документов 
        protected void PrintDoc(string Path)
        {  
            Word.Application app = new Word.Application();
            Word.Document docWord = app.Documents.Open(String.Concat(@"G:\Sql\SQL\sql\Library\Reports\",Path), Visible: true, ReadOnly: false);
            app.Visible = false;
            app.Dialogs[Word.WdWordDialog.wdDialogFilePrint].Show();
            docWord.Close();
            app.Quit();
        }

        private void butPrintDay_Click(object sender, EventArgs e)
        {PrintDoc(String.Concat("RD", Convert.ToDateTime(DateDayRaport.Text).ToShortDateString(),".docx"));}

        private void butPrintError_Click(object sender, EventArgs e)
        {PrintDoc(String.Concat("ED", Convert.ToDateTime(DateError.Text).ToShortDateString(), ".docx"));}

        private void butPrintYard_Click(object sender, EventArgs e)
        {PrintDoc(String.Concat("RY", YearReport.Text, ".docx"));}
        #endregion

        private void butNext_Click(object sender, EventArgs e)
        {
            if (IdPerson.Count > i)
            {
                i++;
                LoadWorker();
            }
            if (i == IdPerson.Count-1)
            {butNext.Enabled = false;}
            else
            {butBack.Enabled = true;}
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
                LoadWorker();
            }
            if (i == 0)
            {butBack.Enabled = false;}
            else
            {butNext.Enabled = true;}
        }

        public void LoadWorker()
        {
            connection = transaction.Connection();
            SqlCommand commandLoad = new SqlCommand("SELECT * FROM Сотрудники WHERE  Логин=@login", connection);
            commandLoad.Parameters.AddWithValue("login", IdPerson[i].ToString());
            SqlDataReader readerLoad = commandLoad.ExecuteReader();
            readerLoad.Read();
            textBoxLogin.Text = readerLoad["Логин"].ToString();
            textBoxName.Text = readerLoad["ФИО_Сотрудника"].ToString();
            TextBoxPhone.Text = readerLoad["Телефон_Сотрудника"].ToString();
            textBoxWork.Text = readerLoad["Должность"].ToString();
            textBoxPassword.Text = readerLoad["Пароль"].ToString();
            transaction.CloseConnect();
        }

        public void LoadWorkers()
        {
            connection = transaction.Connection();
            SqlCommand commandLoadPerson = new SqlCommand("SELECT Логин, ФИО_Сотрудника FROM Сотрудники", connection);
            SqlDataReader readerLoadPerson = commandLoadPerson.ExecuteReader();
            while (readerLoadPerson.Read())
            {IdPerson.Add(readerLoadPerson[0].ToString());}
            readerLoadPerson.Close();
            transaction.CloseConnect();
        }

        private void ControlTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ControlTab.SelectedIndex==2)
            {rButNorm.Checked = true;}
            if(ControlTab.SelectedIndex==3)
            {
                if (select)
                {
                    LName.Text = "";
                    LoginBox.Text = "";
                    NomberBrigad.Value = 0;
                    Proffession1.Text = "";
                    connection = transaction.Connection();
                    SqlCommand commandLoadList = new SqlCommand("SELECT Логин, ФИО_Сотрудника FROM Сотрудники", connection);
                    SqlDataReader reader = commandLoadList.ExecuteReader();
                    while (reader.Read())
                    {LoginBox.Items.Add(String.Concat(reader[0].ToString()+" "+reader[1].ToString()));}
                    reader.Close();
                    transaction.CloseConnect();
                }
            }
            Proverka();
        }

        private void rButNorm_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxNorm.Enabled = true;
            groupBox4.Enabled = false;
        }

        private void rButDoPlan_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxNorm.Enabled = false;
            groupBox4.Enabled = true;
        }

        private void butAddDate_Click(object sender, EventArgs e)
        {
            if (BoxMonth1.Text != "" || Oclock.Value != 0)
            {
                connection = transaction.Connection();
                SqlCommand commandAdd = new SqlCommand("UPDATE Норма_Выработки SET Количество_часов=@oclock WHERE Месяц=@mounth", connection);
                commandAdd.Parameters.AddWithValue("mounth", BoxMonth1.Text);
                commandAdd.Parameters.AddWithValue("oclock", Convert.ToInt32(Oclock.Value));
                commandAdd.ExecuteNonQuery();
                transaction.CloseConnect();
                MessageBox.Show("План выработки на " + BoxMonth1.Text + "-" + Oclock.Value+"установлен.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Выберете месяц и установите количество часов.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butShow_Click(object sender, EventArgs e)
        {
            if (BoxMounth2.Text != "")
            {
                //MessageBox.Show(BoxMonth1.Items[Convert.ToInt32(DateTime.Now.Month)-1].ToString(),"проверка");
                connection = transaction.Connection();
                string command2 = "SELECT * FROM Норма_Выработки WHERE Месяц=@monthNow";
                SqlCommand sql = new SqlCommand(command2, connection);
                sql.Parameters.AddWithValue("monthNow", DateTime.Now.Month.ToString());
                SqlDataReader read = sql.ExecuteReader();
                read.Read();
                if (read[0].ToString() == BoxMounth2.Text)
                {
                    int hour = Convert.ToInt32(read[1].ToString());
                    read.Close();
                    SqlCommand commandShow = new SqlCommand("SELECT Сотрудники.ФИО_Сотрудника, Сотрудники.Должность, Список_бригад.Часы FROM Сотрудники, Список_бригад", connection);
                    SqlDataReader readShow = commandShow.ExecuteReader();
                    while (readShow.Read())
                    {
                        if (Convert.ToInt32(readShow[2]) >= hour)
                        {
                            string[] Add = new string[3];
                            Add[0] = readShow[0].ToString();
                            Add[1] = readShow[1].ToString();
                            Add[2] = readShow[2].ToString();
                            dataShow.Rows.Add(Add);
                        }
                    }
                    readShow.Close();
                }
                    transaction.CloseConnect();
                }
                else
                    MessageBox.Show("Выберете месяц!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void butAddNewBrigad_Click(object sender, EventArgs e)
        {NomberBrigad.Maximum = NomberBrigad.Maximum + 1;}

        private void button1_Click(object sender, EventArgs e)
        {
            if (NomberBrigad.Maximum == NomberBrigad.Value)
            {NomberBrigad.Maximum = NomberBrigad.Maximum - 1;}
            else
                MessageBox.Show("Удалить можно только последнюю бригаду.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butAddBprigad_Click(object sender, EventArgs e)
        {
            if (LName.Text != "" || LoginBox.Text != "" || NomberBrigad.Value != 1 || Proffession1.Text != "")
            {
                connection = transaction.Connection();
                int Prov = 0;
                for (int i = 0; i < Proffession1List.Items.Count; i++)
                {
                    if (Proffession1.Text != Proffession1List.Items[i].ToString())
                    {Prov++;}
                }
                bool Add = false;
                if (Prov == Proffession1List.Items.Count)
                {Add = true;}
                else
                {
                    if (MessageBox.Show("В бригаде уже есть сотрудник стакой специализацией. Хотите его заменить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Add = true;
                        SqlCommand commandDelete = new SqlCommand("SELECT Список_бригад.Логин FROM Список_бригад, Сотрудники WHERE Сотрудники.Логин=Список_бригад.Логин and Должность=@prof and НомерБригады=@nomber", connection);
                        commandDelete.Parameters.AddWithValue("prof", Proffession1.Text);
                        commandDelete.Parameters.AddWithValue("nomber", NomberBrigad.Value);
                        SqlDataReader reader = commandDelete.ExecuteReader();
                        string log = reader[0].ToString();
                        reader.Close();
                        SqlCommand commandUpdate = new SqlCommand("UPDATE Список_бригад SET [НомерБригады] = 0 WHERE Логин=@login", connection);
                        commandUpdate.Parameters.AddWithValue("login", log);
                        commandUpdate.ExecuteNonQuery();
                    }
                }
                if(Add)
                {                   
                    SqlCommand commandAddPerson = new SqlCommand("UPDATE Список_бригад SET [НомерБригады] = @nomber WHERE Логин=@login", connection);
                    commandAddPerson.Parameters.AddWithValue("login", LoginBox.Text);
                    commandAddPerson.Parameters.AddWithValue("nomber", NomberBrigad.Value);
                    commandAddPerson.ExecuteNonQuery();
                }
                transaction.CloseConnect();
            }
            else
                MessageBox.Show("Заполните все поля.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoginBox.Enabled = false;
            NomberBrigad.Enabled = false;
            butAddBprigad.Enabled = false;
            butProv.Enabled = true;
        }

        private void LoginBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection = transaction.Connection();
            SqlCommand commandLoadPerson = new SqlCommand("SELECT ФИО_Сотрудника, Должность  FROM Сотрудники WHERE Логин=@log", connection);
            commandLoadPerson.Parameters.AddWithValue("log", LoginBox.Text);
            SqlDataReader reader = commandLoadPerson.ExecuteReader();
            reader.Read();
            LName.Text = reader[0].ToString();
            Proffession1.Text = reader[1].ToString();
            transaction.CloseConnect();
        }

        private void NomberBrigad_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Proffession1List.Items.Count; i++)
            {Proffession1List.SetItemChecked(i, false);}
            if (NomberBrigad.Value==0)
            {
                LoginBox.Enabled = false;
                butAddBprigad.Enabled = false;                
            }
            else
            {
                LoginBox.Enabled = true;
                butAddBprigad.Enabled = true;
            }
            connection = transaction.Connection();
            SqlCommand commandLoadProf = new SqlCommand("SELECT Должность FROM Сотрудники, Список_бригад  WHERE Сотрудники.Логин=Список_бригад.Логин and НомерБригады=@nom", connection);
            commandLoadProf.Parameters.AddWithValue("nom", NomberBrigad.Value);
            SqlDataReader readerLoadProf = commandLoadProf.ExecuteReader();
            while (readerLoadProf.Read())
            {
                for (int i = 0; i < Proffession1List.Items.Count; i++)
                {
                    if (readerLoadProf[0].ToString() == Proffession1List.Items[i].ToString())
                    {Proffession1List.SetItemChecked(i, true);}
                }
            }
            transaction.CloseConnect();
        }

        private void Proverka()
        {
            if(Proffession1List.CheckedItems.Count != Proffession1List.Items.Count && NomberBrigad.Value != 0)
            {
                MessageBox.Show("Бригада не доукомплектованна.", "Сообщение",MessageBoxButtons.OK, MessageBoxIcon.Information);
                select = false;
                ControlTab.SelectedIndex=3;
            }
        }

        private void butProv_Click(object sender, EventArgs e)
        {
            Proverka();
            LoginBox.Enabled = true;
            NomberBrigad.Enabled = true;
            butAddBprigad.Enabled = true;
            butProv.Enabled = false;
        }
    }
}
