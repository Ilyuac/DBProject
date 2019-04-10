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
    public partial class NewOrder : Form
    {
        #region Global Var
        Transaction transaction = new Transaction();
        SqlConnection connection;
        string[] SelectBrigad = new string[2];
        string[] Client = new string[2];
        string SerialNo="";
        string[] OrderInho=new string[5];
        #endregion

        public NewOrder(string[] client, bool update)
        {            
            InitializeComponent();
            if (update == false)
            {
                Client = client;
                Load_Order();
            }
            else
            {
                Client = client;
                LoadOrder_forUpdate(client[0]);
            }
            //MessageBox.Show(Client[0], "Проверка");
            OrderInho[0] = BoxEquipment.Text;
            OrderInho[1] = BoxErrors.Text;
            if(Garant.Checked)
            {
                OrderInho[2] = "1";
            }
            else
            {
                OrderInho[2] = "0";
            }
            OrderInho[3] = CommentBox.Text;
            OrderInho[4] = labelSelectBrigad.Text;
        }
        
        protected void Load_Order()
        {
            butAddOrder.Visible = true;
            connection = transaction.Connection();
            SqlCommand commandDivace = new SqlCommand("SELECT Оборудование_Клиента.Название FROM Оборудование_Клиента, Обслуживаемое_Оборудование WHERE Обслуживаемое_Оборудование.Код_Оборудования=Оборудование_Клиента.Код_Оборудования and [№_Клиента]=@NomberClient", connection);
            LableDate.Text = DateTime.Today.ToShortDateString();
            labelName.Text =Client[1];
            //MessageBox.Show(Client[0], "Проверка");
            commandDivace.Parameters.AddWithValue("NomberClient", Client[0]);
            SqlDataReader read = commandDivace.ExecuteReader();
            while (read.Read())
            {
                //MessageBox.Show(read[0].ToString(), "Проверка");
                BoxEquipment.Items.Add(read[0].ToString());
            }
            read.Close();
            SqlCommand commandErrors = new SqlCommand("SELECT  Причина FROM Отказы", connection);
            SqlDataReader reader = commandErrors.ExecuteReader();
            while (reader.Read())
            {
                //MessageBox.Show(reader[0].ToString(), "Проверка");
                BoxErrors.Items.Add(reader[0].ToString());
            }

            reader.Close();
            BoxErrors.Text = BoxErrors.Items[0].ToString();
            transaction.CloseConnect();
        }

        private void butAddOrder_Click(object sender, EventArgs e)
        {
            if (SerialNo == "")
                MessageBox.Show("Выберете оборудование. Поле неможет быть пустым.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (CommentBox.Text == "")
                    MessageBox.Show("Описание должно быть заполнено.","Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    connection = transaction.Connection();
                    //try
                    {
                        #region Информация о заявке
                        SqlCommand commandAdd = new SqlCommand("INSERT INTO [Информация_о_Заявке]([SN_Оборудования], [Дата_подачи], [Краткое_Описание_Проблемы], [Вид_Обслуживания]) VALUES (@SetialNo, @Date, @Comment, @Garant)", connection);
                        commandAdd.Parameters.AddWithValue("SetialNo", SerialNo);
                        commandAdd.Parameters.AddWithValue("Date", LableDate.Text);
                        commandAdd.Parameters.AddWithValue("Comment", CommentBox.Text);
                        //MessageBox.Show(SerialNo+' '+LableDate.Text+' '+ CommentBox.Text, "Проверка");
                        if (Garant.Checked.ToString() == "true")
                            commandAdd.Parameters.AddWithValue("Garant", 1);
                        else
                            commandAdd.Parameters.AddWithValue("Garant", 0);
                        commandAdd.ExecuteNonQuery();
                        #endregion


                        SqlCommand commandSelect = new SqlCommand("SELECT НомерЗаявки FROM Информация_о_Заявке", connection);
                        SqlDataReader reader = commandSelect.ExecuteReader();
                        string NoberOrder = "";
                        while (reader.Read())
                            NoberOrder = reader["НомерЗаявки"].ToString();
                        reader.Close();
                        //MessageBox.Show(NoberOrder,"Проверка");

                        #region Заявка                    
                        SqlCommand commandErrors = new SqlCommand("SELECT Код_Отказа FROM Отказы WHERE Причина=@Error", connection);
                        commandErrors.Parameters.AddWithValue("Error", BoxErrors.Text);
                        //MessageBox.Show(BoxErrors.Text,"Проверка");
                        SqlDataReader ReadError = commandErrors.ExecuteReader();
                        ReadError.Read();
                        string Error = ReadError[0].ToString();


                        SqlCommand commandAdd1 = new SqlCommand("INSERT INTO [Заявки] ([НомерЗаявки], [Код_Отказа]) VALUES (@id, @Code)", connection);
                        commandAdd1.Parameters.AddWithValue("id", Convert.ToInt32(NoberOrder));
                        //MessageBox.Show(ReadError[0].ToString(),"Проверка");
                        commandAdd1.Parameters.AddWithValue("Code", ReadError[0].ToString());
                        //MessageBox.Show(NoberOrder + ' ' + "1234" + ' ' + Error,"Проверка");
                        ReadError.Close();
                        commandAdd1.ExecuteNonQuery();
                        #endregion

                        #region Заказ
                        SqlCommand commandAdd2 = new SqlCommand("INSERT INTO [Заказ] ([НомерЗаявки], [НомерБригады], [Отметка_о_Выполнении]) VALUES (@id, @NomberBrigad, @Check)", connection);
                        commandAdd2.Parameters.AddWithValue("id", NoberOrder);
                        commandAdd2.Parameters.AddWithValue("NomberBrigad", SelectBrigad[0]);
                        if (BoxErrors.Text != "-")
                        {
                            commandAdd2.Parameters.AddWithValue("Check", 0);
                        }
                        else
                        {
                            commandAdd2.Parameters.AddWithValue("Check", 1);
                        }
                        //MessageBox.Show(NoberOrder + ' ' + SelectBrigad[0] + ' ' + "0", "Проверка");
                        commandAdd2.ExecuteNonQuery();
                        #endregion

                        MessageBox.Show("Заказ успешно добавлен.", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                        panelOrder.Enabled = false;
                        butAddOrder.Enabled = false;
                        Close();
                    }
                    //catch()
                    {

                    }
                }
            }
        }

        private void BoxEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Garant.Enabled = false;
            //Определение Гарантийного случая
            connection = transaction.Connection();
            SqlCommand commandGarant = new SqlCommand("SELECT SN_Оборудования, Дата_Установки, Гарантийный_Срок FROM Оборудование_Клиента, Обслуживаемое_Оборудование WHERE Оборудование_Клиента.Код_Оборудования=Обслуживаемое_Оборудование.Код_Оборудования and [№_Клиента]=@NomberClient and Название=@NameDivace", connection);
            commandGarant.Parameters.AddWithValue("NomberClient", Client[0]);
            commandGarant.Parameters.AddWithValue("NameDivace", BoxEquipment.Text);
            SqlDataReader reader = commandGarant.ExecuteReader();
            DateTime date,date1;
            while (reader.Read())
            {
                date = Convert.ToDateTime(reader["Дата_Установки"]);
               date1 = date.AddMonths((date.Month + Convert.ToInt32(reader["Гарантийный_Срок"])));
              
                if (date1.Year >= DateTime.Now.Year)
                {
                    if (date1.Month >= DateTime.Now.Month)
                    {
                        Garant.Enabled = true;                        
                    }
                }
                SerialNo = reader["SN_Оборудования"].ToString();
            }
            transaction.CloseConnect();
        }

        public void SelectedBrigad(string nomber, string foremen)
        {
            SelectBrigad[0] = nomber;
            SelectBrigad[1] = foremen;
            labelSelectBrigad.Text = nomber + ' ' + foremen;
            butAddOrder.Enabled = true;
        }

        private void butBrigadSeach_Click_1(object sender, EventArgs e)
        {
            FaindBrigad faindBrigad = new FaindBrigad(Client[0])
            {
                Owner = this
            };
            faindBrigad.Show();
        }

        protected void LoadOrder_forUpdate(string nomberOrder)
        {
            butSaveOrder.Enabled = true;
            butSaveOrder.Visible = true;
            butCancel.Visible = true;
            LableDo.Visible = true;
            connection = transaction.Connection();
            #region проверка гарантии
            SqlCommand commandGarant = new SqlCommand("SELECT SN_Оборудования, Дата_Установки, Гарантийный_Срок FROM Оборудование_Клиента WHERE [№_Клиента]=@NomberClient and Название=@NameDivace", connection);
            commandGarant.Parameters.AddWithValue("NomberClient", Client[0]);
            commandGarant.Parameters.AddWithValue("NameDivace", BoxEquipment.Text);
            SqlDataReader readerGarant = commandGarant.ExecuteReader();
            DateTime date, date1;
            while (readerGarant.Read())
            {
                date = Convert.ToDateTime(readerGarant["Дата_Установки"]);
                date1 = date.AddMonths((date.Month + Convert.ToInt32(readerGarant["Гарантийный_Срок"])));

                if (date1.Year >= DateTime.Now.Year)
                {
                    if (date1.Month >= DateTime.Now.Month)
                    {
                        Garant.Enabled = true;
                    }
                }
                SerialNo = readerGarant["SN_Оборудования"].ToString();
            }
            readerGarant.Close();
            #endregion

            string NomberOrder = nomberOrder;
            string str = "SELECT SN_Оборудования, Информация_о_Заявке.Дата_подачи, Краткое_Описание_Проблемы, Вид_Обслуживания, Код_Отказа, НомерБригады, Отметка_о_Выполнении FROM Информация_о_Заявке, Заявки, Заказ WHERE Заказ.НомерЗаявки=Информация_о_Заявке.НомерЗаявки and Информация_о_Заявке.НомерЗаявки=Заявки.НомерЗаявки and Информация_о_Заявке.НомерЗаявки=@nomberorder";
            
            SqlCommand commandLoadOrder = new SqlCommand(str, connection);
            commandLoadOrder.Parameters.AddWithValue("nomberOrder", nomberOrder);
            SqlDataReader reader = commandLoadOrder.ExecuteReader();
            reader.Read();
            SerialNo = reader[0].ToString();
            LableDate.Text= reader[1].ToString();
            CommentBox.Text = reader[2].ToString();
            //MessageBox.Show(reader[3].ToString(), "Проверка");
            if (reader[3].ToString() == "True")
            {
                Garant.Checked = true;                
            }
            else
                Garant.Checked = false;
            int NomError = Convert.ToInt32(reader[4]);
            
            if(reader[6].ToString()=="True")
            {
                LableDo.Visible=false;
                lableNoDo.Visible = true;
                // изменить цвет на зеленый
                butCancel.Enabled = true;
            }
            else
            {
                LableDo.Visible = true;
                lableNoDo.Visible = false;
                //LableDo.ForeColor изменить цвет на красный
                butCancel.Text = "Отметить как выполненое";
                butCancel.Enabled = true;
            }
            reader.Close();

            labelName.Text =Client[1];

            SqlCommand commandErrors = new SqlCommand("SELECT  Причина FROM Отказы", connection);
            SqlDataReader ReadErrors = commandErrors.ExecuteReader();
            int i = 0;
            while (ReadErrors.Read())
            {
                //MessageBox.Show(reader[0].ToString(), "Проверка");                
                BoxErrors.Items.Add(ReadErrors[0].ToString());
                //MessageBox.Show(BoxErrors.Items[i].ToString(), "Проверка");
                i++;
            }
            BoxErrors.Text = BoxErrors.Items[NomError].ToString();
            ReadErrors.Close();
            //загрузка бригады исполнителя
            string[] SelectBrigad = new string[2];
            SqlCommand commandBrigad = new SqlCommand("SELECT Заказ.НомерБригады, ФИО_Бригадира FROM Заказ, Информация_о_Бригаде WHERE Заказ.НомерБригады=Информация_о_Бригаде.НомерБригады and Заказ.НомерЗаявки=@nomberOrder", connection);
            commandBrigad.Parameters.AddWithValue("nomberOrder",nomberOrder);
            SqlDataReader readerBrigad = commandBrigad.ExecuteReader();
            readerBrigad.Read();
            SelectBrigad[0] = readerBrigad[0].ToString();
            SelectBrigad[1] = readerBrigad[1].ToString();
            readerBrigad.Close();
            labelSelectBrigad.Text = SelectBrigad[0] + ' ' + SelectBrigad[1];
            //загрузка списка оборудования клиента
            SqlCommand commandLoadEqupment = new SqlCommand("SELECT SN_Оборудования, Название FROM Оборудование_Клиента WHERE [№_Клиента]=(SELECT [№_Клиента] FROM Оборудование_Клиента WHERE SN_Оборудования=@SerialNo)", connection);
            commandLoadEqupment.Parameters.AddWithValue("SerialNo",SerialNo);
            SqlDataReader readerEquipment = commandLoadEqupment.ExecuteReader();
            while(readerEquipment.Read())
            {
                if(readerEquipment[0].ToString()==SerialNo)
                {
                    BoxEquipment.Text = readerEquipment[1].ToString();
                }
                BoxEquipment.Items.Add(readerEquipment[1].ToString());
            }
            BoxEquipment.Enabled = false;
            transaction.CloseConnect();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            connection = transaction.Connection();
            SqlCommand commandDo = new SqlCommand("UPDATE Заказ SET [Отметка_о_Выполнении]=@mark WHERE НомерЗаявки=@nomderOrder", connection);
            commandDo.Parameters.AddWithValue("nomderOrder",Client[0]);
            if(LableDo.Visible==true)
            {
                commandDo.Parameters.AddWithValue("mark", 1);
                LableDo.Visible = false;
                lableNoDo.Visible = true;
                butCancel.Text = "Отметить как выполнено";
            }
            else
            {
                commandDo.Parameters.AddWithValue("mark", 0);
                LableDo.Visible = true;
                lableNoDo.Visible = false;
                butCancel.Text = "Отменить выполнение";
            }
            commandDo.ExecuteNonQuery();
            transaction.CloseConnect();
            //NewOrder order = new NewOrder(Client,true);
            //LoadOrder_forUpdate(Client[0]);
        }

        private void butSaveOrder_Click(object sender, EventArgs e)
        {
            connection = transaction.Connection();
            SqlCommand commandUp;
            
            if(OrderInho[1] != BoxErrors.Text)
            {
                if(BoxErrors.Text!="-")
                {
                    SqlCommand commandSQL = new SqlCommand("SELECT Код_Отказа FROM Отказы WHERE Причина=@prich", connection);
                    commandSQL.Parameters.AddWithValue("prich", BoxErrors.Text);
                    SqlDataReader reader = commandSQL.ExecuteReader();
                    reader.Read();
                    commandUp = new SqlCommand("UPDATE Заявки SET [Код_Отказа]=@code WHERE НомерЗаявки=@nom", connection);
                    commandUp.Parameters.AddWithValue("code", reader[0].ToString());
                    commandUp.Parameters.AddWithValue("nom", Client[0]);
                    reader.Close();
                    commandUp.ExecuteNonQuery();
                }
            }
            if (OrderInho[2] != "1")
            {
                commandUp = new SqlCommand("UPDATE Информация_о_Заявке SET [Вид_Обслуживания]=0 WHERE НомерЗаявки=@nom", connection);
                commandUp.Parameters.AddWithValue("nom", Client[0]);
                commandUp.ExecuteNonQuery();
            }
            else
            {
                commandUp = new SqlCommand("UPDATE Информация_о_Заявке SET [Вид_Обслуживания]=1 WHERE НомерЗаявки=@nom", connection);
                commandUp.Parameters.AddWithValue("nom", Client[0]);
                commandUp.ExecuteNonQuery();
            }
            if(OrderInho[3] != CommentBox.Text)
            {
                commandUp = new SqlCommand("UPDATE Информация_о_Заявке SET [Краткое_Описание_Проблемы]=@comment WHERE НомерЗаявки=@nom", connection);
                commandUp.Parameters.AddWithValue("nom", Client[0]);
                commandUp.Parameters.AddWithValue("comment", CommentBox.Text);
                commandUp.ExecuteNonQuery();
            }
            if(OrderInho[4] != labelSelectBrigad.Text)
            {
                commandUp = new SqlCommand("UPDATE Заказ SET НомерБригады=@nomberBr WHERE НомерЗаявки=@nom", connection);
                commandUp.Parameters.AddWithValue("nom", Client[0]);
                commandUp.Parameters.AddWithValue("nomberBr", labelSelectBrigad.Text.Split(' ')[0].ToString());
                commandUp.ExecuteNonQuery();
            }
            transaction.CloseConnect();
            Close();
        }
    }
}
