using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SuperMarketMS
{
    public partial class SalesRegister : Form
    {
        DbConn dbconn = new DbConn();
        public SalesRegister()
        {
            InitializeComponent();
            
        }

        private void SalesRegister_Load(object sender, EventArgs e)
        {
            if (LoginForm.loggedUser == "" || LoginForm.loggedUser == null)
            {
                LoginForm.loggedUser = "Null User";
            };

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            pboItemImage.Image = Image.FromFile(@"D:\Resources\ItemImage\default.png");
            //
            string qCurrentBill = "select itemname, qty, rate, disa, net, cmprice from currentbill;";
            MySqlDataAdapter aCurrentBill = new MySqlDataAdapter(qCurrentBill, dbconn.connection);
            DataSet ds = new DataSet();
            aCurrentBill.Fill(ds, "CurrentBill");
            dgvCurrentBill.DataSource = ds.Tables["CurrentBill"];
        }


        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                MessageBox.Show("find product");
            }else if (e.KeyCode.ToString() == "F2")
            {
                button1_Click("",e);
            }else if (e.KeyCode.ToString() == "F5")
            {
                string qaddtobill = "delete from currentbill;";
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                MySqlCommand caddtobill = new MySqlCommand(qaddtobill, dbconn.connection);
                int queryAffected = caddtobill.ExecuteNonQuery();
             
                string qCurrentBill = "select itemname, qty, rate, disa, net, cmprice from currentbill;";
                MySqlDataAdapter aCurrentBill = new MySqlDataAdapter(qCurrentBill, dbconn.connection);
                DataSet ds = new DataSet();
                aCurrentBill.Fill(ds, "CurrentBill");
                dgvCurrentBill.DataSource = ds.Tables["CurrentBill"];
            }
        }

        private void txtItemCode_Leave(object sender, EventArgs e)
        {
    
        }
        public string isWeight = "";
        decimal cmpPrice = 0;
        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            string barCode = "";
            string id = "";
            string name = "";
            cmpPrice = 0;
            decimal selPrice = 0;
            decimal disAmount = 0;
            txtItemName.Clear(); txtSelling.Clear();  txtDisAmount.Clear(); txtNetAmount.Clear();
            pboItemImage.Image = Image.FromFile(@"D:\Resources\ItemImage\default.png");

            if (txtItemCode.Text != "")
            {
                barCode = txtItemCode.Text;
            }
            else
            {
                txtItemCode.Clear();
                txtItemCode.Focus();
            }

            if (barCode != "")
            {
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                string qr_getProduct = "SELECT i.id AS id, i.iname AS name,i.weight as isWeight, "+
                    "s.companyprice AS cmpprice,s.sellingprice as selprice, s.discount AS discount, s.qty FROM" +
                    " stocks AS s JOIN items AS i ON s.itemid = i.id WHERE s.barcode = '" + barCode + "';";
                MySqlCommand cm_getProduct = new MySqlCommand(qr_getProduct, dbconn.connection);
                    MySqlDataReader dr_getProduct = cm_getProduct.ExecuteReader();

                if (dr_getProduct.HasRows == true)
                {
                    while (dr_getProduct.Read())
                    {
                        id = dr_getProduct["id"].ToString();
                        name = dr_getProduct["name"].ToString();
                        cmpPrice = decimal.Parse(dr_getProduct["cmpprice"].ToString());
                        selPrice = decimal.Parse(dr_getProduct["selprice"].ToString());
                        disAmount = decimal.Parse(dr_getProduct["discount"].ToString());
                        isWeight = dr_getProduct["isWeight"].ToString();
                    }
                    dbconn.CloseConnection();
                    txtItemName.Text = name;
                    txtSelling.Text = selPrice.ToString();
                    
                    if (disAmount > 0)
                    {
                        //discountPercentage = discountPercentage / 100;
                        //decimal disAmount = Math.Round(decimal.Multiply(selPrice, discountPercentage), 2);
                        txtDisAmount.Text = disAmount.ToString();
                        txtNetAmount.Text = (selPrice - disAmount).ToString();
                    }
                    else
                    {
                        txtDisAmount.Text = "0";
                        txtNetAmount.Text = selPrice.ToString();
                    }
                    bool n = File.Exists(@"D:\Resources\ItemImage\" + id + ".jpg")? true : false;
                    pboItemImage.Image = n ? Image.FromFile(@"D:\Resources\ItemImage\" + id + ".jpg") : Image.FromFile(@"D:\Resources\ItemImage\default.png");
                }
            }
        }

     

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode  == Keys.Enter)
            {
                txtQty_Leave(sender, e);
            }

        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus();
            }

        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if(txtItemName.Text != "" && txtItemName.Text != null)
            {
                txtQty.Focus();
            }
            else
            {
                txtItemCode.Focus();
            }
                   
        }
        
        private void txtQty_Leave(object sender, EventArgs e)
        {
            if(txtQty.Text == null || txtQty.Text == "")
            {
                txtQty.Text = "0";
            }

            if (txtItemName.Text != "" && txtQty.Text != "" && txtItemCode.Text != "" && txtQty.Text != null && txtQty.Text != "0")
            {
                if(decimal.Parse(txtQty.Text) > 0)
                {
              
                    string itemcode = txtItemCode.Text;
                    string itemName = txtItemName.Text;
                    decimal qty = Math.Round(decimal.Parse(txtQty.Text), 3);
       

                    decimal rate = Math.Round(decimal.Parse(txtSelling.Text), 2);
                    //string discount = txtDisPercentage.Text;
                    
                    decimal disAmount = Math.Round(decimal.Parse(txtDisAmount.Text),2)* qty;
                    decimal netAmount = Math.Round(decimal.Parse(txtNetAmount.Text), 2);
                    //if(isWeight == "true")
                    //{
                    //    decimal netTotal = Math.Round((qty * netAmount), 2);
                    //}
                    //else
                    //{
                        decimal netTotal = Math.Round((qty * netAmount), 2);
                    //}


                    string qAddToBill = "INSERT INTO currentbill values('" + itemcode + "','" + itemName + "'," + qty +
                        "," + rate + ", " + disAmount + ", " + netTotal + ", "+ cmpPrice*qty +");";
                    dbconn.CloseConnection();
                    dbconn.OpenConnection();
                    MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
                    int queryAffected = cAddToBill.ExecuteNonQuery();
                }

                dbconn.CloseConnection();
                dbconn.OpenConnection();
                string qCurrentBill = "select itemname, qty, rate, disa, net, cmprice from currentbill;";
                MySqlDataAdapter aCurrentBill = new MySqlDataAdapter(qCurrentBill, dbconn.connection);
                DataSet ds = new DataSet();
                aCurrentBill.Fill(ds, "CurrentBill");
                dgvCurrentBill.DataSource = ds.Tables["CurrentBill"];
                txtItemCode.Clear();
                txtQty.Clear();
                txtItemCode.Focus();

                dbconn.CloseConnection();
                dbconn.OpenConnection();
                string qr_getProduct = "SELECT sum(disa) AS dis, sum(net) AS net FROM sm.currentbill;";
                MySqlCommand cm_getProduct = new MySqlCommand(qr_getProduct, dbconn.connection);
                MySqlDataReader dr_getProduct = cm_getProduct.ExecuteReader();

                if (dr_getProduct.HasRows == true)
                {
                    while (dr_getProduct.Read())
                    {
                        if (dr_getProduct["dis"] != null)
                        {
                            lblGross.Text = (decimal.Parse(dr_getProduct["dis"].ToString()) + decimal.Parse(dr_getProduct["net"].ToString())).ToString();
                            lblDiscount.Text = dr_getProduct["dis"].ToString();
                            lblTotal.Text = dr_getProduct["net"].ToString();
                        }

                        //totalDis = decimal.Parse(dr_getProduct["dis"]);
                        //totalNet = decimal.Parse(dr_getProduct["net"]);
                    }
                }
            }
            
            }

        private void SalesRegister_Leave(object sender, EventArgs e)
        {
            //dbconn.OpenConnection();
            //dbconn.CloseConnection();
            //string qAddToBill = "delete from currentbill;";
            //dbconn.CloseConnection();
            //dbconn.OpenConnection();
            //MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
            //int queryAffected = cAddToBill.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dgvCurrentBill.RowCount > 0)
            {

                PayOption po = new PayOption();
                po.Show();
            }
            else
            {
                MessageBox.Show("There is no items to pay!");
            }
           
        }

        private void dgvCurrentBill_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //MessageBox.Show("");
        }

        private void dgvCurrentBill_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if(dgvCurrentBill.Rows.Count > 0)
            {
                int rowIndex = dgvCurrentBill.CurrentRow.Index;
                MessageBox.Show(rowIndex.ToString());
            }
            
            //MessageBox.Show(dgvCurrentBill.SelectedRows());
            //MessageBox.Show(rowIndex);
            //MessageBox.Show(dgvCurrentBill.[e.Row].Cells["itemname"].ToString());
        }

        private void dgvCurrentBill_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(dgvCurrentBill.SelectedRows[-1].Cells["itemname"].ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string delItemCode = dgvCurrentBill.SelectedRows[0].Cells[0].Value.ToString();
            string delQty = dgvCurrentBill.SelectedRows[0].Cells[1].Value.ToString();
            //MessageBox.Show(delItemCode + delQty); 
            string qaddtobill = "delete from currentbill where itemname = '" + delItemCode +"' and qty=" + delQty + ";";
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            MySqlCommand caddtobill = new MySqlCommand(qaddtobill, dbconn.connection);
            int queryAffected = caddtobill.ExecuteNonQuery();
            if(queryAffected > 0)
            {
                //MessageBox.Show("ok");
            }
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qCurrentBill = "select itemname, qty, rate, disa, net, cmprice from currentbill;";
            MySqlDataAdapter aCurrentBill = new MySqlDataAdapter(qCurrentBill, dbconn.connection);
            DataSet ds = new DataSet();
            aCurrentBill.Fill(ds, "CurrentBill");
            dgvCurrentBill.DataSource = ds.Tables["CurrentBill"];
            txtItemCode.Clear();
            txtQty.Clear();
            txtItemCode.Focus();
            
        }

        private void SalesRegister_Enter(object sender, EventArgs e)
        {
            dbconn.OpenConnection();
            dbconn.CloseConnection();
            string qAddToBill = "delete from currentbill;";
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
            int queryAffected = cAddToBill.ExecuteNonQuery();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');

        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
