using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketMS
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        DbConn dbconn = new DbConn();
        private void DashBoard_Load(object sender, EventArgs e)
        {
            if (LoginForm.loggedUser == "" || LoginForm.loggedUser == null)
            {
                LoginForm.loggedUser = "Null User";
            }

            if (LoginForm.loggedUser != null)
            {
                dbLoggedUser.Text = "Cashier : " + LoginForm.loggedUser.ToUpper();

            }

            dbTimer.Enabled = true;
            dbTimer.Interval = 1000;
            dbTimer.Tick += new EventHandler(this.tmrDateTime_Tick);


           


            foreach (Form form in dbFrmContainer.Controls.OfType<Form>().ToArray())
            {
                form.Close();
            }
            viewDashboard l = new viewDashboard();
            l.TopLevel = false;
            dbFrmContainer.Controls.Add(l);
            l.Show();

        }


        public void updateCash()
        {
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qr_getProduct = "SELECT totalBill as billAmount from totalbillday;";
            MySqlCommand cm_getProduct = new MySqlCommand(qr_getProduct, dbconn.connection);
            MySqlDataReader dr_getProduct = cm_getProduct.ExecuteReader();

            if (dr_getProduct.HasRows == true)
            {
                while (dr_getProduct.Read())
                {
                    if (dr_getProduct["billAmount"] != null)
                    {
                        totalCash.Text = "In Locker : " + dr_getProduct["billAmount"].ToString();
                    }
                }
            }
        }

        private void tmrDateTime_Tick(object sender, EventArgs e)
        {
            string dtTime = DateTime.Now.ToString("hh:mm:ss");
            string dtDate = DateTime.Now.ToString("yyyy/MM/dd");
            dbTimeNDate.Text = dtDate + " - " + dtTime;
            updateCash();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            foreach (Form form in dbFrmContainer.Controls.OfType<Form>().ToArray())
            {
                form.Close();
            }
            viewDashboard l = new viewDashboard();
            l.TopLevel = false;
            dbFrmContainer.Controls.Add(l);
            l.Show();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            foreach (Form form in dbFrmContainer.Controls.OfType<Form>().ToArray())
            {
                form.Close();
            }
            StockManagement l = new StockManagement();
            l.TopLevel = false;
            dbFrmContainer.Controls.Add(l);
            l.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            foreach (Form form in dbFrmContainer.Controls.OfType<Form>().ToArray())
            {
                form.Close();
            }
            SalesRegister l = new SalesRegister();
            l.TopLevel = false;
            dbFrmContainer.Controls.Add(l);
            l.Show();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            foreach (Form form in dbFrmContainer.Controls.OfType<Form>().ToArray())
            {
                form.Close();
            }
            CashDeals l = new CashDeals();
            l.TopLevel = false;
            dbFrmContainer.Controls.Add(l);
            l.Show();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            foreach (Form form in dbFrmContainer.Controls.OfType<Form>().ToArray())
            {
                form.Close();
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            foreach (Form form in dbFrmContainer.Controls.OfType<Form>().ToArray())
            {
                form.Close();
            }
            BillManagement l = new BillManagement();
            l.TopLevel = false;
            dbFrmContainer.Controls.Add(l);
            l.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm mainForm = new LoginForm();
            mainForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            foreach (Form form in dbFrmContainer.Controls.OfType<Form>().ToArray())
            {
                form.Close();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
