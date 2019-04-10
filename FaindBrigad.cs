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
    public partial class FaindBrigad : Form
    {
        Transaction transaction = new Transaction();
        SqlConnection connection;
        string NomberClient;

        public FaindBrigad(string client)
        {
            InitializeComponent();
            NomberClient = client;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {            
            dataBrigad.Rows.Clear();
            connection = transaction.Connection();
            SqlCommand commandNoBrigad = new SqlCommand("SELECT НомерБригады FROM Черный_Список WHERE Черный_Список.[№_Клиента]=@client", connection);
            List<string> NoBrigad = new List<string>();
            commandNoBrigad.Parameters.AddWithValue("client",NomberClient);
            SqlDataReader readerNoBrigad = commandNoBrigad.ExecuteReader();
            if (readerNoBrigad.Read() != false)
            {
                NoBrigad.Add(readerNoBrigad[0].ToString());
                while (readerNoBrigad.Read())
                {
                    NoBrigad.Add(readerNoBrigad[0].ToString());
                }
            }
            else
                NoBrigad.Add("0");
            readerNoBrigad.Close();

            SqlCommand command;
            if (Free.Checked == true && Plan.Checked == true)
            {
                command = new SqlCommand("SELECT Список_бригад.НомерБригады, Сотрудники.ФИО_Сотрудника FROM Список_бригад, Сотрудники, Информация_о_Бригаде WHERE Сотрудники.Логин=Список_бригад.Логин and Информация_о_Бригаде.НомерБригады=Список_бригад.НомерБригады  and Информация_о_Бригаде.Отметка_о_Выезде=0 and Список_бригад.Отметка_о_Выполнении_плана=0 and Информация_о_Бригаде.Отметка_о_Выходе_на_Смену=1 and Сотрудники.Должность=@Job", connection);
                command.Parameters.AddWithValue("Job", "Бригадир");               
                SqlDataReader reader = command.ExecuteReader();
                string[] str = new string[2];
                while (reader.Read())
                {
                    for (int i = 0; i < NoBrigad.Count; i++)
                    {
                        if (reader[0].ToString() != NoBrigad[i])
                        {
                            str[0] = reader[0].ToString();
                            str[1] = reader[1].ToString();
                            dataBrigad.Rows.Add(str);
                        }
                    }
                }
            }
            else
            {
                if (Free.Checked == true)
                {
                    command = new SqlCommand("SELECT Список_бригад.НомерБригады, Сотрудники.ФИО_Сотрудника FROM Список_бригад, Сотрудники, Информация_о_Бригаде WHERE Сотрудники.Логин=Список_бригад.Логин and Информация_о_Бригаде.НомерБригады=Список_бригад.НомерБригады  and Информация_о_Бригаде.Отметка_о_Выезде=0 and Информация_о_Бригаде.Отметка_о_Выходе_на_Смену=1 and Сотрудники.Должность=@Job", connection);
                    command.Parameters.AddWithValue("Job", "Бригадир");
                    SqlDataReader reader = command.ExecuteReader();
                    string[] str = new string[2];
                    while (reader.Read())
                    {
                        for (int i = 0; i < NoBrigad.Count; i++)
                        {
                            if (reader[0].ToString() != NoBrigad[i])
                            {
                                str[0] = reader[0].ToString();
                                str[1] = reader[1].ToString();
                                dataBrigad.Rows.Add(str);
                            }
                        }
                    }
                }
                else
                {
                    if (Plan.Checked == true)
                    {
                        command = new SqlCommand("SELECT Список_бригад.НомерБригады, Сотрудники.ФИО_Сотрудника FROM Список_бригад, Сотрудники, Информация_о_Бригаде WHERE Сотрудники.Логин=Список_бригад.Логин and Информация_о_Бригаде.НомерБригады=Список_бригад.НомерБригады  and Список_бригад.Отметка_о_Выполнении_плана=0 and Информация_о_Бригаде.Отметка_о_Выходе_на_Смену=1 and Сотрудники.Должность=@Job", connection);
                        command.Parameters.AddWithValue("Job", "Бригадир");
                        SqlDataReader reader = command.ExecuteReader();
                        string[] str = new string[2];
                        while (reader.Read())
                        {
                            for (int i = 0; i < NoBrigad.Count; i++)
                            {
                                if (reader[0].ToString() != NoBrigad[i])
                                {
                                    str[0] = reader[0].ToString();
                                    str[1] = reader[1].ToString();
                                    dataBrigad.Rows.Add(str);
                                }
                            }
                        }
                    }
                    else
                    {
                        command = new SqlCommand("SELECT Список_бригад.НомерБригады, Сотрудники.ФИО_Сотрудника FROM Список_бригад, Сотрудники WHERE Сотрудники.Логин=Список_бригад.Логин and Сотрудники.Должность=@Job", connection);
                        command.Parameters.AddWithValue("Job", "Бригадир");
                        SqlDataReader reader = command.ExecuteReader();
                        string[] str = new string[2];
                        while (reader.Read())
                        {
                            for (int i = 0; i < NoBrigad.Count; i++)
                            {
                                if (reader[0].ToString() != NoBrigad[i])
                                {
                                    str[0] = reader[0].ToString();
                                    str[1] = reader[1].ToString();
                                    dataBrigad.Rows.Add(str);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void dataBrigad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NewOrder newOrder = (NewOrder)this.Owner;
            if (dataBrigad.SelectedRows.Count == 1)
                newOrder.SelectedBrigad(dataBrigad.SelectedCells[0].Value.ToString(), dataBrigad.SelectedCells[1].Value.ToString());
            else
                MessageBox.Show("Выберете только одну бригаду.","Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
               
    }
}
