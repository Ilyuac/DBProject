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
using System.IO;

namespace sql
{
    public partial class Foremen : Form
    {
        #region Global Var
        Transaction transaction = new Transaction();
        SqlConnection connection;
        string Nomber, Qeruy="SELECT  НомерБригады, ФИО_Сотрудника, Отметка_о_Приходе_на_Работу FROM Список_бригад, Сотрудники WHERE Список_бригад.Логин=Сотрудники.Логин";
        public struct TableOrder
        {
            public string ID;
            public string Date;
            public string Name;
            public string Adress;
            public string Comment;
            public TableOrder(string id, string date, string name, string adress, string comment)
            {
                ID = id;
                Date = date;
                Name = name;
                Adress = adress;
                Comment = comment;
            }
        }
        List<TableOrder> table = new List<TableOrder>();
        string Login;
        #endregion

        public Foremen(string nomber,string login)
        {
            Login = login;
            InitializeComponent();            
            Nomber = nomber;
            DataUpdateLoad(false);
            LoadCheckListDO();
        }

        private void DataUpdateLoad(bool Update)
        {
            connection = transaction.Connection();
            if (Update)
            {   //загрузка данных в бд
                if (CheckListPerson.CheckedItems.Count != 0)
                {
                    string Select = "(SELECT  Сотрудники.Логин FROM Список_бригад, Сотрудники WHERE Список_бригад.Логин = Сотрудники.Логин and Список_бригад.НомерБригады=@Nomber and Сотрудники.ФИО_Сотрудника=@Person)";
                    SqlCommand UpdateCommand = new SqlCommand("UPDATE Сотрудники SET [Отметка_о_Приходе_на_Работу] = 1 WHERE Логин=" + Select, connection);
                    SqlCommand UpdateMark = new SqlCommand("UPDATE Информация_о_Бригаде SET [Отметка_о_Выходе_на_Смену]=1 WHERE НомерБригады=@Nomber", connection);
                    UpdateCommand.Parameters.AddWithValue("Nomber", Nomber);
                    for (int i = 0; i < CheckListPerson.CheckedItems.Count; i++)
                    {                       
                        UpdateCommand.Parameters.AddWithValue("Person", CheckListPerson.CheckedItems[i]);
                        UpdateCommand.Parameters.AddWithValue("Mark", 1);
                        if (i < CheckListPerson.CheckedItems.Count - 1)
                        {
                            UpdateCommand.ExecuteNonQuery();
                            UpdateCommand.Parameters.RemoveAt("Person");
                            UpdateCommand.Parameters.RemoveAt("Mark");
                        }
                        else
                        {
                            UpdateCommand.ExecuteNonQuery();//строка которая вносит изменения в бд
                            UpdateMark.Parameters.AddWithValue("Nomber",Nomber);
                            UpdateMark.ExecuteNonQuery();
                        }
                    }
                }                               
            }//Update Data

            else//Load Data
            {
                #region Загрузка сотрудников
                SqlCommand command = new SqlCommand(Qeruy, connection);                
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    if (read["НомерБригады"].ToString() == Nomber)
                    {CheckListPerson.Items.Add(read["ФИО_Сотрудника"].ToString(), Convert.ToBoolean(read["Отметка_о_Приходе_на_Работу"]));}                    
                }
                read.Close();                
                #endregion

                #region Загрузка заказов
                string QueryOrder = "SELECT Заказ.[НомерЗаявки], Дата_подачи, ФИО_Клиента, Адрес_Клиента, Краткое_Описание_Проблемы FROM Заказ, Информация_о_Заявке, Клиент, Заявки, Оборудование_Клиента  WHERE Заказ.Отметка_о_Выполнении = 0 and Заказ.[НомерЗаявки] = Информация_о_Заявке.[НомерЗаявки] and Информация_о_Заявке.[НомерЗаявки] = Заявки.[НомерЗаявки] and  Оборудование_Клиента.[№_Клиента] = Клиент.[№_Клиента] and Оборудование_Клиента.SN_Оборудования=Информация_о_Заявке.SN_Оборудования and Заявки.[Код_отказа]=0 and Заказ.НомерБригады=@NomBrigad";
                SqlCommand OrderCommand = new SqlCommand(QueryOrder, connection);
                OrderCommand.Parameters.AddWithValue("NomBrigad", Nomber);
                SqlDataReader LoadOrder = OrderCommand.ExecuteReader();
                TableOrder Order= new TableOrder();
                while(LoadOrder.Read())
                {
                    Order.ID = LoadOrder[0].ToString();
                    Order.Date = LoadOrder[1].ToString();
                    Order.Name = LoadOrder[2].ToString();
                    Order.Adress = LoadOrder[3].ToString();
                    Order.Comment = LoadOrder[4].ToString();
                    table.Add(Order);
                    ListOrder.Items.Add(LoadOrder[0].ToString()+' '+LoadOrder[2].ToString()+' '+LoadOrder[4].ToString());
                }
                LoadOrder.Close();
                #endregion
            }
            transaction.CloseConnect();
        }
                
        private void Foremen_FormClosed(object sender, FormClosedEventArgs e)
        {            
            transaction.CloseConnect();
            transaction.CloseApp(Login);
        }

        private void ListOrder_SelectedIndexChanged(object sender, EventArgs e)//вывод информ. о заказе
        {
            InfoOrder FormInfo=null;
            for (int i=0;i<table.Count;i++)
            {
                if(table[i].ID==ListOrder.SelectedItem.ToString().Split(' ')[0])
                {
                    FormInfo = new InfoOrder(table[i].ID, table[i].Date, table[i].Name, table[i].Adress, table[i].Comment, Nomber, false, DateTime.Now);
                    FormInfo.Owner = this;                                       
                }
            }
            FormInfo.Show();
        }
             
        private void сформироватьАктToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (groupAct.Enabled == true)
            {
                if (BoxNomAct.Text != "")
                {
                    if (checkedListDO.CheckedItems.Count != 0)
                    {DoAct();}
                    else
                        MessageBox.Show("Выберете выполненые работы для формирования акта.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Выберете акт, который хотите сформировать.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Нет завершенных заказов.", "Сообщение",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butDoAct_Click(object sender, EventArgs e)
        {
            if (BoxNomAct.Text != "")
            {
                if (checkedListDO.CheckedItems.Count != 0)
                {DoAct();}
                else
                    MessageBox.Show("Выберете выполненые работы для формирования акта.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Выберете акт, который хотите сформировать.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void IControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckListPerson.CheckedItems.Count == 0)
            {
                if(IControl.SelectedIndex==1 || IControl.SelectedIndex==2)
                {
                    IControl.SelectedTab=IControl.TabPages[0];
                    MessageBox.Show("Отмете сотрудников пришедших на работу.", "Сообщение", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            if(IControl.SelectedIndex==2)
            {UpdateActNom();}
        }

        public void UpdateData()
        {
            CheckListPerson.Items.Clear();
            ListOrder.Items.Clear();
            DataUpdateLoad(false);
        }

        protected void UpdateActNom()
        {
            BoxNomAct.Text = "";
            BoxNomAct.Items.Clear();
            connection = transaction.Connection();
            string str = "SELECT НомерЗаявки, Акт_выполненых_работ FROM Заказ WHERE НомерБригады=@NomBrigad and Отметка_о_Выполнении=1";
            SqlCommand command = new SqlCommand(str, connection);
            command.Parameters.AddWithValue("NomBrigad", Nomber);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == "")
                    BoxNomAct.Items.Add(reader[0].ToString());
            }
            transaction.CloseConnect();
        }

        private void UpdateMenu_Click(object sender, EventArgs e)
        {DataUpdateLoad(true);}

        protected void DoAct()
        {
            #region
            StreamReader reader = new StreamReader(@"G:\Sql\SQL\sql\Library\Path.txt");
            string text = reader.ReadToEnd(), path = null, Save = "";
            List<string> Text = new List<string>();
            Text.AddRange(text.Split('\n'));
            for (int i = 0; i < Text.Count; i++)
            {
                if (Text[i].Split('=')[0] == "PathAct")
                    path = Text[i].Split('=')[1];
                if (Text[i].Split('=')[0] == "SaveAct")
                    Save = Text[i].Split('=')[1];
            }
            reader.Close();
            #endregion
            Word.Application app = new Word.Application();            
            Word.Document docWord = app.Documents.Open(@"G:\Sql\SQL\sql\Library\template\TempAct.docx", Visible: true, ReadOnly:false);
            app.Visible = false;            
            Word.Bookmarks bookmark = docWord.Bookmarks;
            Word.Range range;
            Word.Bookmark mark = bookmark[1];
            range = mark.Range;
            range.Text = BoxNomAct.Text;//номер
            connection = transaction.Connection();
            SqlCommand commandNameClient = new SqlCommand("SELECT Клиент.ФИО_Клиента FROM Клиент, Информация_о_Заявке, Оборудование_Клиента WHERE Клиент.[№_Клиента]=Оборудование_Клиента.[№_Клиента] and Оборудование_Клиента.SN_Оборудования=Информация_о_Заявке.SN_Оборудования and Информация_о_Заявке.НомерЗаявки=@nomberOrder", connection);
            commandNameClient.Parameters.AddWithValue("nomberOrder", BoxNomAct.Text);
            SqlDataReader readerNameClient = commandNameClient.ExecuteReader();
            readerNameClient.Read();
            mark = bookmark[2];
            range = mark.Range;
            range.Text = readerNameClient[0].ToString();//заказчик
            readerNameClient.Close();
            mark = bookmark[3];
            range = mark.Range;
            range.Text = "ООО Энерготех";//исполнитель
            mark = bookmark[4];
            range = mark.Range;
            Word.Table table = docWord.Tables.Add(range, checkedListDO.CheckedItems.Count + 2, 3);
            table.Borders.Enable = 1;            
            table.Rows[1].Cells[1].Range.Text = "№";
            table.Rows[1].Cells[2].Range.Text = "Название";
            table.Rows[1].Cells[3].Range.Text = "Цена";
            SqlCommand commandCreateRow = new SqlCommand("INSERT INTO [Список_работ] ([Код_Работ], [НомерЗаявки]) VALUES (@Code, @Nomber)", connection);
            int Sum = 0;
            for (int i = 0; i < checkedListDO.CheckedItems.Count; i++)
            {
                SqlCommand commandListWork = new SqlCommand("SELECT * FROM Прайс_лист WHERE Код_Работ=@CodeWork", connection);
                commandListWork.Parameters.AddWithValue("CodeWork", Convert.ToInt32(checkedListDO.CheckedItems[i].ToString().Split(' ')[0]));
                commandCreateRow.Parameters.AddWithValue("Nomber", BoxNomAct.Text);
                commandCreateRow.Parameters.AddWithValue("Code",Convert.ToInt32(checkedListDO.CheckedItems[i].ToString().Split(' ')[0]));
                SqlDataReader readerListWork = commandListWork.ExecuteReader();
                readerListWork.Read();
                table.Rows[i+2].Cells[1].Range.Text = Convert.ToString(i+1);//№
                table.Rows[i+2].Cells[2].Range.Text = readerListWork[1].ToString();//Название
                table.Rows[i+2].Cells[3].Range.Text = readerListWork[3].ToString();//Цена
                Sum += Convert.ToInt32(readerListWork[3]);
                readerListWork.Close();
                commandCreateRow.ExecuteNonQuery();
                commandCreateRow.Parameters.Clear();
            }
            table.Rows[checkedListDO.CheckedItems.Count + 2].Cells[2].Range.Text = "Итого:";
            table.Rows[checkedListDO.CheckedItems.Count + 2].Cells[3].Range.Text = Convert.ToString(Sum);
            string link = String.Concat(@"G:\Sql\SQL\sql\Library\Act\", "A", BoxNomAct.Text, ".docx");
            docWord.SaveAs2(link);            
            docWord.Close();
            app.Quit();
            SqlCommand commandAddLink = new SqlCommand("UPDATE Заказ SET [Акт_выполненых_работ]=@linkAct WHERE НомерЗаявки=@nomber", connection);
            commandAddLink.Parameters.AddWithValue("nomber", Convert.ToInt32(BoxNomAct.Text));
            commandAddLink.Parameters.AddWithValue("linkAct", link);
            commandAddLink.ExecuteNonQuery();
            MessageBox.Show("Акт выполненых работ по заказу №" + BoxNomAct.Text + " был успешно сформирован и сохранен.", "Соодщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            checkedListDO.Items.Clear();
            LoadCheckListDO();
            UpdateActNom();            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection = transaction.Connection();
            string Select = "(SELECT  Сотрудники.Логин FROM Список_бригад, Сотрудники WHERE Список_бригад.Логин = Сотрудники.Логин and Список_бригад.НомерБригады=@Nomber and Сотрудники.ФИО_Сотрудника=@Person)";
            SqlCommand commandReset = new SqlCommand("UPDATE Сотрудники SET [Отметка_о_Приходе_на_Работу]=0 WHERE Сотрудники.Логин="+Select, connection);
            commandReset.Parameters.AddWithValue("Nomber", Nomber);
            for (int i = 0; i < CheckListPerson.CheckedItems.Count; i++)
            {
                commandReset.Parameters.AddWithValue("Person", CheckListPerson.CheckedItems[i]);
                if (i < CheckListPerson.CheckedItems.Count - 1)
                {
                    commandReset.ExecuteNonQuery();
                    commandReset.Parameters.RemoveAt("Person");
                }
                else
                {commandReset.ExecuteNonQuery();}                
            }
            transaction.CloseConnect();
            Application.Exit();
        }

        protected void LoadCheckListDO()
        {
            connection = transaction.Connection();
            SqlCommand command = new SqlCommand("SELECT * FROM Прайс_лист", connection);
            SqlDataReader reader = command.ExecuteReader();
            string str = "";
            while (reader.Read())
            {
                str = reader[0].ToString() + ' ' + reader[1].ToString() + ' ' + reader[2].ToString() + ' ' + reader[3].ToString();
                checkedListDO.Items.Add(str);
            }
            transaction.CloseConnect();
        }

        private void BoxNomAct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Change()
        {
            connection = transaction.Connection();
            SqlCommand commandChange = new SqlCommand("UPDATE Информация_о_Бригаде SET [Отметка_о_Выходе_на_Смену]=1 WHERE НомерБригады=@nomber", connection);
            commandChange.Parameters.AddWithValue("nomber",Nomber);
            commandChange.BeginExecuteNonQuery();
            transaction.CloseConnect();
        }
    }
}