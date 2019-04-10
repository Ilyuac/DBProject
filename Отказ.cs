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
    public partial class Refusal : Form
    {
        Transaction transaction = new Transaction();
        SqlConnection connection;
        string NomberOrder;
        
        public Refusal(string nomberorder)
        {
            NomberOrder = nomberorder;
            InitializeComponent();

            FillingList();
        }

        private void butProof_Click(object sender, EventArgs e)
        {
            connection = transaction.Connection();
            SqlCommand command = new SqlCommand("UPDATE [Заявки] SET [Код_Отказа]=@Code WHERE НомерЗаявки=@Nomber",connection);
            command.Parameters.AddWithValue("Nomber",NomberOrder);
            SqlCommand Refusal = new SqlCommand("SELECT * FROM Отказы", connection);
            SqlDataReader reader = Refusal.ExecuteReader();
            while(reader.Read())
            {
                if(RefusalBox.SelectedText.ToString()==reader["Код_Отказа"].ToString())
                    command.Parameters.AddWithValue("Code", RefusalBox.SelectedText.ToString());
            }
            reader.Close();
            command.ExecuteNonQuery();
            transaction.CloseConnect();
            Close();
        }

        protected void FillingList()
        {
            connection = transaction.Connection();
            SqlCommand command = new SqlCommand("SELECT * FROM Отказы", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                RefusalBox.Items.Add(reader["Причина"]);
            }
            reader.Close();
            connection = null;
        }
    }
}
