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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(LoginForm.loggedUser != null)
            {
                lblUserName.Text = "Cashier : " + LoginForm.loggedUser.ToUpper();

            }

            tmrDateTime.Enabled = true;
            tmrDateTime.Interval = 1000;
            tmrDateTime.Tick += new EventHandler(this.tmrDateTime_Tick);
        }
        //Clock Display
        private void tmrDateTime_Tick(object sender, EventArgs e)
        {
            string dtTime = DateTime.Now.ToString("hh:mm:ss");
            string dtDate = DateTime.Now.ToString("yyyy/mm/dd");
            lblDateTime.Text = dtDate + " - " + dtTime;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginForm.loggedUser = "";
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesRegister salesRegister = new SalesRegister();
            salesRegister.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockManagement stockManagement = new StockManagement();
            stockManagement.Show();
        }
    }
}
