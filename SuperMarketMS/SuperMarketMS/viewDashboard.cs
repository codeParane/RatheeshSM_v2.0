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
    public partial class viewDashboard : Form
    {
        public viewDashboard()
        {
            InitializeComponent();
        }
        DbConn dbconn = new DbConn();
        private void viewDashboard_Load(object sender, EventArgs e)
        {
            loadExpireGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadExpireGrid();
        }
        public void loadExpireGrid() {

           


            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qGetStocks = "select i.iname, i.category, s.qty from stocks as s join " +
                "items as i on s.itemid = i.id where s.qty < 5 group by s.itemid order by s.qty";
            MySqlDataAdapter aGetStocks = new MySqlDataAdapter(qGetStocks, dbconn.connection);
            DataSet ds = new DataSet();
            aGetStocks.Fill(ds, "sto");
            dgvLowStocks.DataSource = ds.Tables["sto"];


            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qGetStocks1 = "select i.iname, i.category, s.expiry from stocks as s join items" +
                " as i on s.itemid = i.id where s.expiry < DATE_ADD(CURDATE(), INTERVAL 5 DAY);";
            MySqlDataAdapter aGetStocks1 = new MySqlDataAdapter(qGetStocks1, dbconn.connection);
            DataSet ds1 = new DataSet();
            aGetStocks1.Fill(ds1, "stoc");
            dgvNearExpiry.DataSource = ds1.Tables["stoc"];
        }
    }
}
