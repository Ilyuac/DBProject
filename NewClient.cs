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
    public partial class NewClient : Form
    {
        Transaction transaction = new Transaction();
        SqlConnection connection;
        string NomberClient = "";

        public NewClient(bool update, string nomClient)
        {
            InitializeComponent();

            if(update==true)
            {
                butAdd.Enabled = false;
                butAdd.Visible = false;
                butSave.Enabled = true;
                butSave.Visible = true;
                NomberClient = nomClient;
                LoadClient(nomClient,true);
            }
            else
            {
                butAdd.Enabled = true;
                butAdd.Visible = true;
                butSave.Enabled = false;
                butSave.Visible = false;
                LoadClient(nomClient, false);
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            connection = transaction.Connection();            
            if (BoxAdress.Text != "" || BoxName.Text != "" || BoxPhon.Text != "")
            {
                if (DeviceData.Rows.Count > 0)
                {
                    string ClientRow = "INSERT INTO [Клиент] ([ФИО_Клиента], [Адрес_Клиента], [Телефон_Клиента]) VALUES (@Name, @Adress, @Phone)";
                    SqlCommand UpdateCommand = new SqlCommand(ClientRow, connection);
                    UpdateCommand.Parameters.AddWithValue("Name", BoxName.Text);
                    UpdateCommand.Parameters.AddWithValue("Adress", BoxAdress.Text);
                    UpdateCommand.Parameters.AddWithValue("Phone", BoxPhon.Text);
                    UpdateCommand.ExecuteNonQuery();

                    string DeviceClient = "INSERT INTO [Оборудование_Клиента] ([SN_Оборудования], [Дата_Установки], [Гарантийный_Срок], [Код_Оборудования]) VALUES (@SN, @Date, @Time, @code)";
                    SqlCommand UpdateDevice = new SqlCommand(DeviceClient,connection);
                    for (int i = 0; i < DeviceData.Rows.Count; i++)
                    {
                        SqlCommand commandDivace = new SqlCommand("SELECT Код_Оборудования FROM Обслуживаемое_Оборудование FROM Вид_Оборудования = @view", connection);
                        commandDivace.Parameters.AddWithValue("view", DeviceData.Rows[i].Cells[2].ToString());
                        SqlDataReader reader = commandDivace.ExecuteReader();
                        reader.Read();
                        if (reader.VisibleFieldCount == 1)
                        {
                            UpdateDevice.Parameters.AddWithValue("code",reader[0].ToString());
                        }                        
                        else
                        {
                            SqlCommand commandAdd = new SqlCommand("INSERT INTO [Обслуживаемое_Оборудование]([Вид_Оборудования]) VALUES (@view)", connection);
                            commandAdd.Parameters.AddWithValue("view", DeviceData.Rows[i].Cells[2].ToString());
                           commandDivace = new SqlCommand("SELECT Код_Оборудования FROM Обслуживаемое_Оборудование FROM Вид_Оборудования = @view", connection);
                            commandDivace.Parameters.AddWithValue("view", DeviceData.Rows[i].Cells[2].ToString());
                            reader = commandDivace.ExecuteReader();
                            reader.Read();
                            if (reader.VisibleFieldCount == 1)
                            {
                                UpdateDevice.Parameters.AddWithValue("code", reader[0].ToString());
                            }
                        }
                        reader.Close();
                        UpdateDevice.Parameters.AddWithValue("Название", DeviceData.Rows[i].Cells[1].ToString());
                        UpdateDevice.Parameters.AddWithValue("SN",DeviceData.Rows[i].Cells[0].ToString());
                        UpdateDevice.Parameters.AddWithValue("Date",DeviceData.Rows[i].Cells[3].ToString());
                        UpdateDevice.Parameters.AddWithValue("Time",DeviceData.Rows[i].Cells[4].ToString());
                        UpdateDevice.ExecuteNonQuery();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Добавте оборудование клиента.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля клиента.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            Close();
        }

        private void FaindClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            transaction.CloseConnect();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            connection = transaction.Connection();
            SqlCommand Savecommand = new SqlCommand("UPDATE [Клиент] SET [ФИО_Клиента]=@nameClient , [Адрес_Клиента]=@adress, [Телефон_Клиента]=@phone WHERE [№_Клиента]=@nomberClient", connection);
            Savecommand.Parameters.AddWithValue("nomberClient",NomberClient);
            Savecommand.Parameters.AddWithValue("nameClient",BoxName.Text);
            Savecommand.Parameters.AddWithValue("adress",BoxAdress.Text);
            Savecommand.Parameters.AddWithValue("phone",BoxPhon.Text);
            Savecommand.ExecuteNonQuery();
            
            SqlCommand SaveDevicecommand = new SqlCommand("UPDATE [Оборудование_Клиента] SET [SN_Оборудования]=@nomDivace, [Название]=@name, [Код_Оборудования]=@code, [Дата_Установки]=@date, [Гарантийный_Срок]=@time WHERE [№_Клиента]=@nomber", connection);
            
            for (int i =0;i<DeviceData.Rows.Count-1;i++)
            {
                SaveDevicecommand.Parameters.AddWithValue("nomDivace", DeviceData.Rows[i].Cells[0].Value.ToString());
                SaveDevicecommand.Parameters.AddWithValue("name", DeviceData.Rows[i].Cells[1].Value.ToString());
                SaveDevicecommand.Parameters.AddWithValue("nomber", NomberClient);
                    SqlCommand commandDeviceService = new SqlCommand("SELECT Код_Оборудования FROM Обслуживаемое_Оборудование WHERE Вид_Оборудования=@view", connection);
                    commandDeviceService.Parameters.AddWithValue("view", DeviceData.Rows[i].Cells[2].Value.ToString());
                    SqlDataReader readerService = commandDeviceService.ExecuteReader();
                    readerService.Read();
                SaveDevicecommand.Parameters.AddWithValue("code", readerService[0].ToString());
                SaveDevicecommand.Parameters.AddWithValue("date", Convert.ToDateTime(DeviceData.Rows[i].Cells[3].Value));
                SaveDevicecommand.Parameters.AddWithValue("time", DeviceData.Rows[i].Cells[4].Value.ToString());
                    readerService.Close();

                SaveDevicecommand.ExecuteNonQuery();
                SaveDevicecommand.Parameters.Clear();
            }

            MessageBox.Show("Изменения успешно сохранены.","Сообщение",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Close();
        }

        protected void LoadClient(string nomClient, bool update)
        {
            connection = transaction.Connection();
            if (update)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Клиент WHERE [№_Клиента]=@nomber", connection);
                command.Parameters.AddWithValue("nomber", nomClient);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                BoxName.Text = reader[1].ToString();
                BoxAdress.Text = reader[2].ToString();
                BoxPhon.Text = reader[3].ToString();
                reader.Close();

                SqlCommand commandView = new SqlCommand("SELECT Вид_Оборудования FROM Обслуживаемое_Оборудование", connection);
                SqlDataReader readerView = commandView.ExecuteReader();
                while (readerView.Read())
                { View.Items.Add(readerView[0].ToString()); }
                readerView.Close();

                string[] DataSTR = new string[5];
                SqlCommand commandDivace = new SqlCommand("SELECT SN_Оборудования, Оборудование_Клиента.Название, Обслуживаемое_Оборудование.Вид_Оборудования, Дата_Установки, Гарантийный_Срок FROM Оборудование_Клиента, Обслуживаемое_Оборудование WHERE [№_Клиента]=@nomber and Обслуживаемое_Оборудование.Код_Оборудования=Оборудование_Клиента.Код_Оборудования", connection);
                commandDivace.Parameters.AddWithValue("nomber", nomClient);
                SqlDataReader readerDivace = commandDivace.ExecuteReader();
                while (readerDivace.Read())
                {
                    DataSTR[0] = readerDivace[0].ToString();
                    DataSTR[1] = readerDivace[1].ToString();
                    DataSTR[2] = readerDivace[2].ToString();
                    DateTime date = new DateTime(Convert.ToInt32(readerDivace[3].ToString().Split(' ')[0].Split('.')[2]), Convert.ToInt32(readerDivace[3].ToString().Split(' ')[0].Split('.')[1]), Convert.ToInt32(readerDivace[3].ToString().Split(' ')[0].Split('.')[0]));

                    DataSTR[3] = date.ToShortDateString();
                    DataSTR[4] = readerDivace[4].ToString();
                    DeviceData.Rows.Add(DataSTR);
                }
            }
            else
            {
                SqlCommand commandView = new SqlCommand("SELECT Вид_Оборудования FROM Обслуживаемое_Оборудование", connection);
                SqlDataReader readerView = commandView.ExecuteReader();
                while (readerView.Read())
                { View.Items.Add(readerView[0].ToString()); }
                readerView.Close();
            }
            transaction.CloseConnect();
        }
    }
}
