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
    public partial class Initilizate : Form
    {
        SqlConnection connection;
        string InterfaceID = null;
        Transaction transaction = new Transaction();
        bool fl = false;

        public Initilizate()
        {
            InitializeComponent();
        }

        private void butEnter_Click(object sender, EventArgs e)
        {
            if (Login.Text == "connect" && Password.Text == "connect")
            {
                transaction.Visible = true;
                transaction.Opacity=100;
                transaction.ShowInTaskbar = true;
                fl = true;
                Close();
            }
            else
            if (Login.Text != null && Password.Text != null)
            {                
                connection = transaction.Connection();
                SqlCommand command = new SqlCommand("SELECT Сотрудники.Логин, Должность, Пароль, Статус FROM Сотрудники", connection);
                SqlDataReader reader = command.ExecuteReader();
                bool ExitUser=false;
                while (reader.Read())
                {
                    if (reader["Логин"].ToString() == Login.Text && reader["Пароль"].ToString() == Password.Text && reader["Должность"].ToString() != "Бригадир")
                    {
                        if (Convert.ToBoolean(reader["Статус"]) == false )
                        {
                            InterfaceID = reader["Должность"].ToString();
                            transaction.Clic_butEnter(InterfaceID, null,Login.Text);
                            ExitUser = true;
                        }
                        else
                            MessageBox.Show("Пользователь уже вошел в систему.Если это были не вы обратитесь к Системному администратору.","Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                reader.Close();
                
                if (InterfaceID == null)
                {
                    SqlCommand commandForemen = new SqlCommand("SELECT Сотрудники.Логин, Должность, Пароль, Статус, НомерБригады FROM Сотрудники, Список_бригад WHERE Сотрудники.Логин = Список_бригад.Логин", connection);
                    SqlDataReader readePerson = commandForemen.ExecuteReader();
                    while (readePerson.Read())
                    {
                        if (readePerson["Логин"].ToString() == Login.Text && readePerson["Пароль"].ToString() == Password.Text)
                        {
                            if (Convert.ToBoolean(readePerson["Статус"]) == false)
                            {
                                InterfaceID = readePerson["Должность"].ToString();
                                transaction.Clic_butEnter(InterfaceID, readePerson["НомерБригады"].ToString(),Login.Text);
                                ExitUser = true;
                            }
                            else
                                MessageBox.Show("Пользователь уже вошел в систему.Если это были не вы обратитесь к Системному администратору.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    readePerson.Close();

                    #region ИЗменение статуса пользователя в системе
                    if (ExitUser == true)
                    {
                        SqlCommand Upsql = new SqlCommand("UPDATE [Сотрудники] SET [Статус]=1 WHERE Логин=@Login", connection);
                        Upsql.Parameters.AddWithValue("Login", Login.Text);
                        Upsql.ExecuteNonQuery();
                    }
                    #endregion
                }               

                transaction.CloseConnect();
                if (InterfaceID == null)
                    MessageBox.Show("Проверте правильность ввода Логина/Пароля", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    Close();
            }
            else
            {
                transaction.CloseApp(Login.Text);
            }
        }

        private void Initilizate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fl == false)
            {
                if (InterfaceID == null)
                    transaction.CloseApp(Login.Text);
            }
        }
    }
    
}
