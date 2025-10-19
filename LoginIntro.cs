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

namespace SportCLUB
{
    public partial class LoginIntro : Form
    {
        public LoginIntro()
        {
            InitializeComponent();
        }

        private void LoginIntro_Load(object sender, EventArgs e)
        {

        }



        // Показ пароля
        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            if (cb.Checked)
            {
                tb_password.PasswordChar = '\0';
            }
            else
            {
                tb_password.PasswordChar = '•';
            }
        }

        private void but_enter_Click(object sender, EventArgs e)
        {
            string log = tb_login.Text;
            string pass = tb_password.Text;
            try
            {
                DataBase t = new DataBase(log, pass);
                DataTable tt = GetDataFromDB("SELECT * FROM dbo.Admins");
                tb_message.Text = "Подключение выполнено успешно!";
                tb_message.ForeColor = Color.Green;
                ti.Enabled = true;
            }
            catch (Exception ex)
            {
                tb_message.Text = ex.Message;
                tb_message.ForeColor = Color.Red;
            }
        }

        private void t_Tick(object sender, EventArgs e)
        {
            ti.Enabled = false;
            Form1 frm = new Form1();
            Hide();
            frm.Show();
        }

        // Функция получения данных из SQL-запроса к БД
        public DataTable GetDataFromDB(string query)
        {
            DataBase db = new DataBase();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            db.CloseCon();

            return dt;
        }
    }
}
