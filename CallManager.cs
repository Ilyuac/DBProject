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

namespace sql
{
    public partial class CallManager : Form
    {
        Transaction transaction = new Transaction();
        SqlConnection connection;
        string Login;
        
        public CallManager(string login)
        {
            Login = login;
            InitializeComponent();
            DataUpdateLoad(false);            
        }

        private void DataUpdateLoad(bool Update)
        {
            string DataClient = "SELECT * FROM Клиент";
            connection = transaction.Connection();
            if (Update)
            {   //загрузка данных в бд
                dataTable.Rows.Clear();
                #region Загрузка Клиентов
                SqlCommand command = new SqlCommand(DataClient, connection);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    string[] NewRow = new string[4];
                    for (int i = 0; i < 4; i++)
                        NewRow[i] = read[i].ToString();
                    dataTable.Rows.Add(NewRow);
                }
                read.Close();
                #endregion

                TableOrder.Rows.Clear();
                #region Загрузка заказов
                string QueryOrder = "SELECT Заказ.[НомерЗаявки], Дата_подачи, ФИО_Клиента, Адрес_Клиента, Краткое_Описание_Проблемы FROM Заказ, Информация_о_Заявке, Клиент, Заявки, Оборудование_Клиента WHERE (Информация_о_Заявке.Дата_подачи=@date or Заказ.Отметка_о_Выполнении = 0) and Заказ.[НомерЗаявки] = Информация_о_Заявке.[НомерЗаявки] and Информация_о_Заявке.[НомерЗаявки] = Заявки.[НомерЗаявки] and Оборудование_Клиента.[SN_Оборудования]=Информация_о_Заявке.[SN_Оборудования] and Оборудование_Клиента.[№_Клиента] = Клиент.[№_Клиента]";
                SqlCommand OrderCommand = new SqlCommand(QueryOrder, connection);
                OrderCommand.Parameters.AddWithValue("date", DateTime.Now.ToShortDateString());
                SqlDataReader LoadOrder = OrderCommand.ExecuteReader();
                while (LoadOrder.Read())
                {
                    string[] NewRow = new string[5];
                    for (int i = 0; i < 5; i++)
                        NewRow[i] = LoadOrder[i].ToString();
                    TableOrder.Rows.Add(NewRow);
                }

                LoadOrder.Close();
                #endregion
            }//Update Data

            else//Load Data
            {
                #region Загрузка Клиентов
                SqlCommand command = new SqlCommand(DataClient, connection);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    string[] NewRow = new string[4];
                    for (int i = 0; i < 4; i++)
                        NewRow[i] = read[i].ToString();
                    dataTable.Rows.Add(NewRow);
                }
                read.Close();
                #endregion
                #region Загрузка заказов 
                string QueryOrder = "SELECT Заказ.[НомерЗаявки], Дата_подачи, ФИО_Клиента, Адрес_Клиента, Краткое_Описание_Проблемы FROM Заказ, Информация_о_Заявке, Клиент, Заявки, Оборудование_Клиента WHERE (Информация_о_Заявке.Дата_подачи=@date or Заказ.Отметка_о_Выполнении = 0) and Заказ.[НомерЗаявки] = Информация_о_Заявке.[НомерЗаявки] and Информация_о_Заявке.[НомерЗаявки] = Заявки.[НомерЗаявки] and Оборудование_Клиента.[SN_Оборудования]=Информация_о_Заявке.[SN_Оборудования] and Оборудование_Клиента.[№_Клиента] = Клиент.[№_Клиента]";
                SqlCommand OrderCommand = new SqlCommand(QueryOrder, connection);
                OrderCommand.Parameters.AddWithValue("date", DateTime.Now.ToShortDateString());
                SqlDataReader LoadOrder = OrderCommand.ExecuteReader();
                while (LoadOrder.Read())
                {
                    string[] NewRow = new string[5];
                    for (int i = 0; i < 5; i++)
                        NewRow[i] = LoadOrder[i].ToString();
                    TableOrder.Rows.Add(NewRow);
                }
                LoadOrder.Close();
                #endregion
            }
            transaction.CloseConnect();
        }

        #region Клиент
        private void butAdd_Click(object sender, EventArgs e)
        {
            NewClient faindClient = new NewClient(false,"");
            faindClient.Show();
            //Обновлене таблицы с клиентами
            DataUpdateLoad(true);
        }

        private void butDeletClient_Click(object sender, EventArgs e)
        {
            if(dataTable.SelectedRows.Count!=0)
            {
                if(dataTable.SelectedRows.Count==1)
                {
                    if (MessageBox.Show("Вы уверены что хотите удалить всю инфорацию о клиенте?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string NomberClient = dataTable.SelectedRows[0].Cells[0].ToString();
                        connection = transaction.Connection();
                        //Удаление заяок клиента
                        List<string> OrderClient = new List<string>();
                        SqlCommand command = new SqlCommand("SELECT Информация_о_Заявке.НомерЗаявки FROM Информация_о_Заявке, Заказ, Заявки, Оборудование_Клиента WHERE (Информация_о_Заявке.НомерЗаявки=Заказ.НомерЗаявки or Информация_о_Заявке.НомерЗаявки=Заявки.НомерЗаявки) and Информация_о_Заявке.SN_Оборудования=Оборудование_Клиента.SN_Оборудования and Оборудование_Клиента.[№_Клиента]=@Client",connection);
                        command.Parameters.AddWithValue("Client", dataTable.SelectedRows[0].Cells[0].Value.ToString());
                        SqlDataReader reader = command.ExecuteReader();
                        while(reader.Read())
                        {
                            OrderClient.Add(reader[0].ToString());
                        }
                        reader.Close();

                        string[] StrDelete = new string[3];
                        StrDelete[0] = "DELETE FROM Заказ WHERE НомерЗаявки= @NomberOrder";
                        StrDelete[1] = "DELETE FROM Заявки WHERE НомерЗаявки= @NomberOrder";
                        StrDelete[2] = "DELETE FROM Информация_о_Заявке WHERE НомерЗаявки= @NomberOrder";
                        for (int j = 0; j < OrderClient.Count; j++)
                        {
                            for (int i = 0; i < StrDelete.Length; i++)
                            {
                                SqlCommand commandDelete = new SqlCommand(StrDelete[i], connection);
                                commandDelete.Parameters.AddWithValue("NomberOrder", OrderClient[j]);
                                commandDelete.ExecuteNonQuery();
                            }
                        }
                        //Удаление оборудования клиента
                        SqlCommand commandDeleteDevice = new SqlCommand("DELETE FROM Оборудование_Клиента WHERE [№_Клиента]=@Client", connection);
                        commandDeleteDevice.Parameters.AddWithValue("Client", dataTable.SelectedRows[0].Cells[0].Value.ToString());
                        commandDeleteDevice.ExecuteNonQuery();
                        //Удаление клиента
                        SqlCommand commandDeleteClient = new SqlCommand("DELETE FROM Клиент WHERE [№_Клиента]= @Client", connection);
                        commandDeleteClient.Parameters.AddWithValue("Client", dataTable.SelectedRows[0].Cells[0].Value.ToString());
                        commandDeleteClient.ExecuteNonQuery();
                        MessageBox.Show("Клиент успешно удалени из базы.","Сообщение",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        transaction.CloseConnect();
                        DataUpdateLoad(true);
                    }
                }
            }
        }
        
        private void butFaind_Click(object sender, EventArgs e)
        {            
            dataTable.Rows.Clear();
            if (textBoxName.Text != "")
            {
                connection = transaction.Connection();
                SqlCommand commandSearch = new SqlCommand("SELECT * FROM Клиент WHERE ФИО_Клиента LIKE @FIO or Адрес_Клиента LIKE @FIO", connection);
                string FIO = textBoxName.Text.Replace('*', '%');
                FIO = FIO.Replace('?', '_');
                commandSearch.Parameters.AddWithValue("FIO", FIO);
                SqlDataReader readerSearch = commandSearch.ExecuteReader();
                string[] str = new string[4];
                while (readerSearch.Read())
                {
                    str[0] = readerSearch[0].ToString();
                    str[1] = readerSearch[1].ToString();
                    str[2] = readerSearch[2].ToString();
                    str[3] = readerSearch[3].ToString();
                    dataTable.Rows.Add(str);
                }
                readerSearch.Close();
                transaction.CloseConnect();
            }
            else
                DataUpdateLoad(false);
        }
        #endregion

        #region Заявка
        private void butAddOrder_Click(object sender, EventArgs e)
        {
            string[] client = new string[2];
            client[0] = dataTable.SelectedCells[0].Value.ToString();
            client[1] = dataTable.SelectedCells[1].Value.ToString();
            NewOrder newOrder = new NewOrder(client,false);
            newOrder.ShowDialog();
            DataUpdateLoad(true);
        }

        private void butDeleteOrder_Click(object sender, EventArgs e)
        {
            if(TableOrder.SelectedRows.Count!=0)
            {
                if (TableOrder.SelectedRows.Count == 1)
                {
                    if(MessageBox.Show("Вы уверенычто хотите удалить заказ.","Сообщение",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                    {
                        connection = transaction.Connection();
                        string[] StrDelete = new string[4];
                        StrDelete[0]= "DELETE FROM Заказ WHERE НомерЗаявки= @NomberOrder";
                        StrDelete[1] = "DELETE FROM Заявки WHERE НомерЗаявки= @NomberOrder";
                        StrDelete[2] = "DELETE FROM Список_работ WHERE НомерЗаявки= @NomberOrder";
                        StrDelete[3] = "DELETE FROM Информация_о_Заявке WHERE НомерЗаявки= @NomberOrder";
                        for (int i = 0; i < StrDelete.Length; i++)
                        {
                            SqlCommand commandDelete = new SqlCommand(StrDelete[i], connection);
                            commandDelete.Parameters.AddWithValue("NomberOrder", Convert.ToInt32(TableOrder.SelectedRows[0].Cells[0].Value));
                            commandDelete.ExecuteNonQuery();
                        }
                        transaction.CloseConnect();
                    }
                }
                else
                {MessageBox.Show("Выберете только одну строку.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);}
            }
            else
            {MessageBox.Show("Выберете заказ.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);}
            DataUpdateLoad(true);
        }

        private void TableOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(TableOrder.SelectedRows.Count==1)
            {
                butDeleteOrder.Enabled = true;
                butSave.Enabled = true;
            }
            else
                MessageBox.Show("Выберете только одну заявку.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void CallManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            transaction.CloseConnect();
            transaction.CloseApp(Login);
        }

        private void butUpdateClient_Click(object sender, EventArgs e)
        {
            if (dataTable.SelectedRows.Count == 1)
            {
                NewClient client = new NewClient(true, dataTable.SelectedRows[0].Cells[0].Value.ToString());
                client.ShowDialog();
                DataUpdateLoad(false);
            }
            else
                MessageBox.Show("Выберете только одного клиента для изменения.","Сообщение",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if(TableOrder.SelectedRows.Count==1)
            {
                string[] client = new string[2];
                client[0] = TableOrder.SelectedRows[0].Cells[0].Value.ToString();
                client[1] = TableOrder.SelectedRows[0].Cells[2].Value.ToString();
                NewOrder order = new NewOrder(client,true);
                order.ShowDialog();
            }
            else
                MessageBox.Show("Выберете только один заказ для изменения.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {ClearName.Enabled = true;}        

        private void ClearName_Click(object sender, EventArgs e)
        {
            textBoxName.Clear();
            ClearName.Enabled = false;
        }       

        private void TableOrder_DoubleClick(object sender, EventArgs e)
        {
            // подготовка к печати чека
            if (TableOrder.SelectedRows.Count != 0)
            {
                if (TableOrder.SelectedRows.Count == 1)
                {
                    string nomberBrigad="";
                    InfoOrder infoOrder = new InfoOrder(TableOrder.SelectedRows[0].Cells[0].Value.ToString(), TableOrder.SelectedRows[0].Cells[1].Value.ToString(), TableOrder.SelectedRows[0].Cells[2].Value.ToString(), 
                    TableOrder.SelectedRows[0].Cells[3].Value.ToString(), TableOrder.SelectedRows[0].Cells[4].Value.ToString(), nomberBrigad, true, DateTime.Now);
                    infoOrder.ShowDialog();
                }
                else
                    MessageBox.Show("Выберете только одну строку.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Выберете заказ с которым хотите провести работу.","Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dataTable_DoubleClick(object sender, EventArgs e)
        {
            if (dataTable.SelectedRows.Count != 0)
            {
                if (dataTable.SelectedRows.Count == 1)
                {
                    butAddOrder.Enabled = true;
                    butUpdateClient.Enabled = true;
                    butDeletClient.Enabled = true;
                }
            }
        }
    }
}
