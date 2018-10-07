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
    public partial class CashDeals : Form
    {
        public CashDeals()
        {
            InitializeComponent();
        }
        DbConn dbconn = new DbConn();
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //load  data grid view
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qGetStocks = "select * from sales where billDate  = '" + csSalesDate.Value.ToString("yyyy-MM-dd") + "';";
            MySqlDataAdapter aGetStocks = new MySqlDataAdapter(qGetStocks, dbconn.connection);
            DataSet ds = new DataSet();
            aGetStocks.Fill(ds, "sto");
            dgvStocks.DataSource = ds.Tables["sto"];


            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qr_getProduct = "SELECT sum(amount) AS amount, sum(revenue)  AS revenue FROM sm.sales where billDate='" +
                csSalesDate.Value.ToString("yyyy-MM-dd") + "';";
            MySqlCommand cm_getProduct = new MySqlCommand(qr_getProduct, dbconn.connection);
            MySqlDataReader dr_getProduct = cm_getProduct.ExecuteReader();

            if (dr_getProduct.HasRows == true)
            {
                while (dr_getProduct.Read())
                {
                    if (dr_getProduct["amount"] != null && dr_getProduct["revenue"] != null && dr_getProduct["revenue"].ToString() != "" && dr_getProduct["revenue"].ToString() != "" )
                    {
                        csTotalRevenue.Text = decimal.Parse(dr_getProduct["revenue"].ToString()).ToString();
                        csTotalSales.Text = decimal.Parse(dr_getProduct["amount"].ToString()).ToString();
                    }
                }
            }
            
        }

        private void CashDeals_Load(object sender, EventArgs e)
        {

        }
    }
}
