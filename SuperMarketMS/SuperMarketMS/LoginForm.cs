using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketMS
{
    public partial class LoginForm : Form
    {
        public static string loggedUser= "Null User";
        DbConn dbconn = new DbConn();
        public LoginForm()
        {
            InitializeComponent();
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (loggedUser == "" || loggedUser == null)
            {
                loggedUser = "Null User";
                    };

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click_1("", e);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            dbconn.CloseConnection();
            dbconn.OpenConnection();

            string isDateAvailable = "SELECT * FROM totalbillday where day='"+ DateTime.Now.ToString("yyyy-MM-dd") +"';";
            MySqlCommand cmdisDateAvailable = new MySqlCommand(isDateAvailable, dbconn.connection);
            MySqlDataReader drisDateAvailable = cmdisDateAvailable.ExecuteReader();

            if (drisDateAvailable.HasRows)
            {
              

            }
            else
            {
                string qAddToBill1 = "INSERT INTO totalbillday VALUES ('"+ DateTime.Now.ToString("yyyy-MM-dd") +"', 0);";
                MySqlCommand cAddToBill1 = new MySqlCommand(qAddToBill1, dbconn.connection);
                int queryAffected1 = cAddToBill1.ExecuteNonQuery();
            }






            dbconn.CloseConnection();
            dbconn.OpenConnection();
            bool isExecute = true;
            if (txtUserName.Text.Equals("") || txtPassword.Text.Equals(""))
            {
                MessageBox.Show("User name or password can't be Empty !!!");
                isExecute = false;
            }
            if (dbconn.OpenConnection() == false)
            {
                MessageBox.Show("Cant connect to the database contact system Administrator.");
                isExecute = false;
            }

            if (isExecute == true)
            {
                string qr_getUserDetails = "SELECT * FROM users WHERE BINARY username = '" + txtUserName.Text + "' && userpw ='"
                    + txtPassword.Text + "';";
                MySqlCommand cm_getUserDetails = new MySqlCommand(qr_getUserDetails, dbconn.connection);
                MySqlDataReader dr_getUserDetails = cm_getUserDetails.ExecuteReader();

                if (dr_getUserDetails.HasRows)
                {
                    //MessageBox.Show("Success!!");
                    loggedUser = txtUserName.Text;
                    deleteOldbills();
                    this.Hide();
                    DashBoard mainForm = new DashBoard();
                    mainForm.Show();

                }
                else
                {
                    MessageBox.Show("Username and Password are not Matched !!!");
                    txtUserName.Clear();
                    txtPassword.Clear();
                    txtUserName.Focus();
                }

                dbconn.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void deleteOldbills()
        {
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qAddToBill = "delete from storedbills where buydate < '"+ 
                DateTime.Now.AddDays(3).ToString("yyyy-MM-ddd")  +"'";
            MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
            int queryAffected = cAddToBill.ExecuteNonQuery();
            if (queryAffected > 0)
            {
            }
        }

    }
}
