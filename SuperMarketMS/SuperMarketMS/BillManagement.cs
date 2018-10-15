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
    public partial class BillManagement : Form
    {
        public BillManagement()
        {
            InitializeComponent();
        }

        private void BillManagement_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        DbConn dbconn = new DbConn();
        private void csSalesDate_ValueChanged(object sender, EventArgs e)
        {
            //load  data grid view
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qGetStocks = "select distinct billid, buydate from storedbills where buydate  = '" + csSalesDate.Value.ToString("yyyy-MM-dd") + "';";
            MySqlDataAdapter aGetStocks = new MySqlDataAdapter(qGetStocks, dbconn.connection);
            DataSet ds = new DataSet();
            aGetStocks.Fill(ds, "sto");
            dgvAllBills.DataSource = ds.Tables["sto"];

        }

        private void dgvAllBills_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //load another dgv
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qGetStocksa = "select itemcode, itemname, qty, net from storedbills where billid  = '" + dgvAllBills.Rows[e.RowIndex].Cells[0].Value.ToString() + "';";
            MySqlDataAdapter aGetStocksa = new MySqlDataAdapter(qGetStocksa, dbconn.connection);
            DataSet dsa = new DataSet();
            aGetStocksa.Fill(dsa, "stoa");
            dgvSelectedBills.DataSource = dsa.Tables["stoa"];


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qGetStocksa = "select itemcode, itemname, qty, net from storedbills where billid  = '" + this.Text + "';";
            MySqlDataAdapter aGetStocksa = new MySqlDataAdapter(qGetStocksa, dbconn.connection);
            DataSet dsa = new DataSet();
            aGetStocksa.Fill(dsa, "stoa");
            dgvSelectedBills.DataSource = dsa.Tables["stoa"];
        }
    }
}
