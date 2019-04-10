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
    public partial class InfoOrder : Form
    {
        Transaction transaction = new Transaction();
        SqlConnection connection;
        string Nomber, NomberOrder; bool CallMenedger_Foremen;
        DateTime Time;

        public InfoOrder(string nomberOrder, string date, string client, string adress, string comment, string NomberBrigad, bool CallMeneger_Foremen, DateTime time)
        {
            InitializeComponent();
            NomberOrder=nomberOrder;
            NomOrder.Text = NomberOrder;
            Date.Text = date;
            Client.Text = client;
            Adress.Text = adress;
            Comment.Text = comment;
            Nomber = NomberBrigad;
            CallMenedger_Foremen = CallMeneger_Foremen;
            Time = time;
            if(CallMeneger_Foremen==true)
            {
                //callmeneger
                butCancel.Enabled = false;
                butEnd.Enabled = false;
                butPerform.Enabled = false;
                                
                butCancel.Visible = false;
                butEnd.Visible = false;
                butPerform.Visible = false;
            }
            else
            {
                //foremen
                butCheck.Enabled = false;
                butCheck.Visible = false;
            }
        }

        public void Perform(bool PerformAndCansel)
        {
            connection = transaction.Connection();
            string UpdatePerform = "UPDATE Информация_о_Бригаде SET [Отметка_о_Выезде]=@Mark WHERE Информация_о_Бригаде.Отметка_о_Выходе_на_Смену=1 and Информация_о_Бригаде.НомерБригады=@Nomber";
            SqlCommand Perform = new SqlCommand(UpdatePerform, connection);
            Perform.Parameters.AddWithValue("Nomber", Nomber);
            if (PerformAndCansel)
                Perform.Parameters.AddWithValue("Mark", 1);
            else
                Perform.Parameters.AddWithValue("Mark", 0);
            Perform.ExecuteNonQuery();
            Perform.Parameters.RemoveAt("Mark");
            transaction.CloseConnect();
        }

        private void butPerform_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Nomber, "Проверка");
            Perform(true);
            #region Button Enable & Visible
            butPerform.Visible=false;
            butPerform.Enabled = false;
            butEnd.Enabled = true;
            butEnd.Visible = true;
            butCancel.Enabled = true;
            butCancel.Visible = true;
            #endregion
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Perform(false);
            #region Button Enable & Visible
            butPerform.Visible = true;
            butPerform.Enabled = true;
            butEnd.Enabled = false;
            butEnd.Visible = false;
            butCancel.Enabled = false;
            butCancel.Visible = false;
            #endregion

            Refusal form = new Refusal(NomOrder.Text);
            form.ShowDialog();
        }

        private void butEnd_Click(object sender, EventArgs e)
        {
            connection = transaction.Connection();            
            string QueryOrder = "UPDATE Заказ SET [Отметка_о_Выполнении]=1, [Дата_исполнения_заказа]=@date, [Акт_выполненых_работ]=@str1, [Чек_товарный]=@str2 WHERE Заказ.НомерЗаявки=@NomberOrder";
            SqlCommand command = new SqlCommand(QueryOrder, connection);
            command.Parameters.AddWithValue("NomberOrder", NomOrder.Text);
            command.Parameters.AddWithValue("date", DateTime.Now.ToShortDateString());
            command.Parameters.AddWithValue("str1", "");
            command.Parameters.AddWithValue("str2", "");
            command.ExecuteNonQuery();
            #region Button Enable & Visible
            butEnd.Enabled = false;
            butEnd.Visible = false;
            butCancel.Enabled = false;
            butCancel.Visible = false;
            #endregion

            SqlCommand commandTime = new SqlCommand("SELECT Отаботаные_часы FROM Информация_о_Бригаде WHERE НомерБригады=@nomber", connection);
            commandTime.Parameters.AddWithValue("nomber", Nomber);
            SqlDataReader readerTime = commandTime.ExecuteReader();
            readerTime.Read();
            string OldTime = readerTime[0].ToString();
            readerTime.Close();

            SqlCommand commandUpdateTime = new SqlCommand("UPDATE Информация_о_Бригаде SET [Отаботаные_часы]=@time WHERE НомерБригады=@nomber", connection);
            string NewTime = Convert.ToString((DateTime.Now.Hour - Time.Hour) + (DateTime.Now.Minute - Time.Minute)*60 + Convert.ToInt32(OldTime));//ошибка преобразования формата
            commandUpdateTime.Parameters.AddWithValue("nomber", Nomber);
            commandUpdateTime.Parameters.AddWithValue("time", Convert.ToInt32(NewTime)+Convert.ToInt32(OldTime));
            commandUpdateTime.ExecuteNonQuery();

            SqlCommand commandTimePerson = new SqlCommand("SELECT Сотрудники.Логин, Список_бригад.Часы FROM Сотрудники, Список_бригад WHERE Сотрудники.Логин=Список_бригад.Логин and НомерБригады=@nomber and Сотрудники.Отметка_о_Приходе_на_Работу=1", connection);
            commandTimePerson.Parameters.AddWithValue("nomber", Nomber);
            SqlDataReader readerPerson = commandTimePerson.ExecuteReader();
            List<string> TempLogin = new List<string>();
            while(readerPerson.Read())
            {
                TempLogin.Add(String.Concat(readerPerson[0].ToString(), "-", readerPerson[1].ToString()));
            }
            readerPerson.Close();
            
            for (int i = 0; i < TempLogin.Count; i++)
            {
                SqlCommand commandUpdate = new SqlCommand("UPDATE Список_бригад SET [Часы]=@timer WHERE Логин=@login", connection);
                commandUpdate.Parameters.AddWithValue("login", TempLogin[i].Split('-')[0]);
                //MessageBox.Show(TempLogin[i].Split('-')[1]+"-"+ NewTime,"Проверка");
                commandUpdate.Parameters.AddWithValue("timer", Convert.ToInt32(TempLogin[i].Split('-')[1]) + Convert.ToInt32(NewTime));
                commandUpdate.ExecuteNonQuery();
            }

            transaction.CloseConnect();
            Close();
        }

        bool Act=false;
        private void butAct_Click(object sender, EventArgs e)
        {
            Act = true;            
            Close();
        }

        private void InfoOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CallMenedger_Foremen == false)
            {
                Foremen foremen = (Foremen)this.Owner;
                foremen.UpdateData();
                if (Act)
                {
                    foremen.groupAct.Enabled = true;
                }
            }
            if(connection!=null)
            transaction.CloseConnect();
        }

        private void butCheck_Click(object sender, EventArgs e)
        {
            connection = transaction.Connection();
            //работа с чеком
            Word.Application app = new Word.Application();
            Word.Document docWord = app.Documents.Open(@"G:\Sql\SQL\sql\Library\template\TempCheck.docx", Visible: true,ReadOnly:false);
            app.Visible = false;

            Word.Bookmarks bookmark = docWord.Bookmarks;
            Word.Range range;
            Word.Bookmark mark = bookmark[1];
            range = mark.Range;
            range.Text =NomOrder.Text;//номер

            mark = bookmark[2];
            range = mark.Range;
            range.Text =Date.Text;//дата

            mark = bookmark[3];
            range = mark.Range;
            range.Text ="ООО Энерготех";//продавец

            mark = bookmark[4];
            range = mark.Range;
            range.Text =Client.Text;//покупатель

            SqlCommand commandRow = new SqlCommand("SELECT Код_Работ FROM Список_работ WHERE НомерЗаявки = @nomber", connection);
            commandRow.Parameters.AddWithValue("nomber", NomOrder.Text);
            //MessageBox.Show(NomOrder.Text, "Проверка");
            SqlDataReader readerRow = commandRow.ExecuteReader();
            List<string> Code = new List<string>();
            while (readerRow.Read())
            {
                Code.Add(readerRow[0].ToString());
                //MessageBox.Show(readerRow[0].ToString(), "Проверка");
            }
            readerRow.Close();

            mark = bookmark[5];
            range = mark.Range;
            Word.Table table = docWord.Tables.Add(range, Code.Count+1, 3);
            table.Borders.Enable = 1;

            table.Rows[1].Cells[1].Range.Text = "№";
            table.Rows[1].Cells[2].Range.Text = "Название";
            table.Rows[1].Cells[3].Range.Text = "Цена";

            //заполнить строки таблицы
            for(int i=2;i<Code.Count+2;i++)
            {
                SqlCommand commandWork = new SqlCommand("SELECT Наименование_Работ, Цена FROM Прайс_лист WHERE Прайс_лист.Код_Работ=@code", connection);
                commandWork.Parameters.AddWithValue("code", Code[i-2]);
                SqlDataReader readerWork = commandWork.ExecuteReader();
                readerWork.Read();
                table.Rows[i].Cells[1].Range.Text = Convert.ToString(i-1);
                table.Rows[i].Cells[2].Range.Text = readerWork[0].ToString();
                table.Rows[i].Cells[3].Range.Text = readerWork[1].ToString();
                readerWork.Close();
            }

            string link = String.Concat(@"G:\Sql\SQL\sql\Library\Check\", "Ch", NomOrder.Text, ".docx");
            docWord.SaveAs2(link);
            docWord.Close();
            app.Quit();

            SqlCommand commandLinkCheck = new SqlCommand("UPDATE Заказ SET [Чек_товарный]=@linkCheck WHERE НомерЗаявки=@nomber", connection);
            commandLinkCheck.Parameters.AddWithValue("nomber", NomOrder.Text);
            commandLinkCheck.Parameters.AddWithValue("linkCheck", link);
            commandLinkCheck.ExecuteNonQuery();

            transaction.CloseConnect();

            butCheck.Enabled = false;
            butCheck.Visible = false;
            butPrintAct.Visible = true;
            butPrintCheck.Visible = true;
            butPrintCheck.Enabled = true;
            butPrintAct.Enabled = true;
        }

        private void butPrintAct_Click(object sender, EventArgs e)
        {
            string PathAct="";
            #region
            connection = transaction.Connection();
            SqlCommand commandPrintAct = new SqlCommand("SELECT Акт_выполненых_работ FROM Заказ WHERE НомерЗаявки=@nomberOrder", connection);
            commandPrintAct.Parameters.AddWithValue("nomberOrder", Convert.ToInt32(NomOrder.Text));
            SqlDataReader readerPrintAct = commandPrintAct.ExecuteReader();
            readerPrintAct.Read();
            PathAct = readerPrintAct[0].ToString();
            readerPrintAct.Close();
            transaction.CloseConnect();
            #endregion

            if (PathAct != "")
            {
                Word.Application app = new Word.Application();
                Word.Document docWord = app.Documents.Open(PathAct, Visible: true, ReadOnly:false);
                app.Visible = false;
                //печать документа
                app.Dialogs[Word.WdWordDialog.wdDialogFilePrint].Show();
                docWord.Close();
                app.Quit();
            }
            else
                MessageBox.Show("Для данного заказа ещё не сформирован акт.", "Соодщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butPrintCheck_Click(object sender, EventArgs e)
        {
            string PathCheck = "";
            #region
            connection = transaction.Connection();
            SqlCommand commandPrintCheck = new SqlCommand("SELECT Чек_товарный FROM Заказ WHERE НомерЗаявки=@nomberOrder", connection);
            commandPrintCheck.Parameters.AddWithValue("nomberOrder", Convert.ToInt32(NomOrder.Text));
            SqlDataReader readerPrintCheck = commandPrintCheck.ExecuteReader();
            readerPrintCheck.Read();
            PathCheck = readerPrintCheck[0].ToString();
            readerPrintCheck.Close();
            transaction.CloseConnect();
            #endregion
            Word.Application app = new Word.Application();
            Word.Document docWord = app.Documents.Open(PathCheck, Visible: true, ReadOnly: false);
            app.Visible = false;
            app.Dialogs[Word.WdWordDialog.wdDialogFilePrint].Show();
            docWord.Close();
            app.Quit();
        }
    }
}
