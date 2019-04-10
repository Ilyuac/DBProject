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
using System.IO;

namespace sql
{
    public partial class Transaction : Form
    {
       string NOMBER;         

       public Transaction()
       {
           InitializeComponent();           
       }

        public void Clic_butEnter(string InterfaceID, string Nomber, string loginuser)
        {
            NOMBER = Nomber;            
            //MessageBox.Show(InterfaceID+" "+NOMBER+" "+LoginUser, "Проверка");
            //InterfaceID; какую форму открыть
            #region FormForemen
            if(InterfaceID=="Бригадир")
            {
                Foremen FormForeman = new Foremen(NOMBER,loginuser);
                FormForeman.Show();
            }
            #endregion

            #region FormHeadliner
            if (InterfaceID == "Начальник")
            {
                Headliner FormHeadliner = new Headliner(loginuser);
                FormHeadliner.Show();
            }
            #endregion

            #region CallManager
            if(InterfaceID == "Диспетчер")
            {
                CallManager callManager = new CallManager(loginuser);
                callManager.Show();
            }                
            #endregion
        }

        SqlConnection sqlConnection;

        public SqlConnection Connection()
        {
            StreamReader reader =new StreamReader(@"G:\Sql\SQL\sql\Library\Path.txt");
            string text = reader.ReadToEnd(),path="";
            List<string> Text=new List<string>();
            Text.AddRange(text.Split('\n'));
            for(int i=0;i<Text.Count;i++)
            {
                if (Text[i].Split('=')[0]== "PathDB")
                    path=Text[i].Split('=')[1];
            }
            reader.Close();

            string StrConnect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Sql\SQL\sql\SQL.mdf" /*+ path*/ + ";Integrated Security=True;Connect Timeout=30";
            sqlConnection = new SqlConnection(StrConnect);
            sqlConnection.Open();
            return sqlConnection;            
        }

        public void CloseConnect()
        {           
            if(sqlConnection!=null)
               sqlConnection.Close();
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            Initilizate FormEnter = new Initilizate();
            FormEnter.Show();
        }

        public void CloseApp(string loginuser)
        {
            //MessageBox.Show(loginuser, "Проверка");
            #region Сброс статуса пользователя
            sqlConnection = Connection();
            SqlCommand Upsql = new SqlCommand("UPDATE [Сотрудники] SET [Статус]=0 WHERE Логин=@Login", sqlConnection);
            Upsql.Parameters.AddWithValue("Login", loginuser);
            Upsql.ExecuteNonQuery();
            CloseConnect();
            #endregion
            Application.Exit();
        }

        private void checkDB_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDB.Checked == true)
                butPathDB.Enabled = true;
            else
                butPathDB.Enabled = false;
        }

        private void checkAct_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAct.Checked == true)
                butPathAct.Enabled = true;
            else
                butPathAct.Enabled = false;
        }

        private void checkCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCheck.Checked == true)
                butPathCheck.Enabled = true;
            else
                butPathCheck.Enabled = false;
        }

        private string Path()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();          
               
            return open.FileName;
        }

        private void butPathDB_Click(object sender, EventArgs e)
        {
            textPathDB.Text = Path();
        }

        private void butPathAct_Click(object sender, EventArgs e)
        {
            textPathAct.Text = Path();
        }

        private void butPathCheck_Click(object sender, EventArgs e)
        {
            textPathCheck.Text = Path();
        }

        private void butWriteFile_Click(object sender, EventArgs e)
        {
            //if (textSavePathAct.Text != "" && textSavePathCheck.Text != "" && textPathDB.Text != "" && textPathAct.Text != "" && textPathCheck.Text != "")
            {
                try
                {
                    File.Delete(@"G:\Sql\SQL\sql\Library\Path.txt");
                }
                catch (Exception) { }

                StreamWriter writer = new StreamWriter(@"G:\Sql\SQL\sql\Library\Path.txt");
                if (checkDB.Checked == true)
                    writer.WriteLine("PathDB=" + textPathDB.Text);
                if (checkAct.Checked == true)
                    writer.WriteLine("PathAct=" + textPathAct.Text);
                if (checkCheck.Checked == true)
                    writer.WriteLine("PathCheck=" + textPathCheck.Text);
                if (checkSaveAct.Checked == true)
                    writer.WriteLine("SaveAct=" + textSavePathAct.Text);
                if (checkSaveCheck.Checked == true)
                    writer.WriteLine("SaveCheck=" + textSavePathCheck.Text);

                writer.Close();
                MessageBox.Show("Подключение прошло успешно.", "Сообщение");
            }
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSaveAct.Checked == true)
                butSaveAct.Enabled = true;
            else
                butSaveAct.Enabled = false;
        }

        private void checkSaveCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSaveCheck.Checked == true)
                butSaveCheck.Enabled = true;
            else
                butSaveCheck.Enabled = false;
        }

        private void butSaveAct_Click(object sender, EventArgs e)
        {
            textSavePathAct.Text = Path();
        }

        private void butSaveCheck_Click(object sender, EventArgs e)
        {
            textSavePathCheck.Text = Path();
        }
    }
}
