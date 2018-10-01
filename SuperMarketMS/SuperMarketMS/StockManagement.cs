using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SuperMarketMS
{
    public partial class StockManagement : Form
    {
        DbConn dbconn = new DbConn();

        public StockManagement()
        {
            InitializeComponent();
        }


        //stocks tap
        private void tpcStock_Enter(object sender, EventArgs e)
        {
            cmbStoksItemCat.Items.Clear();
            cmbStoksItemCat.Items.Add("ALL");
            cmbStoksItemCat.SelectedItem = "ALL";

            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qCmbCatFill = "SELECT DISTINCT category FROM items;";
            MySqlDataAdapter aCmbCatFill = new MySqlDataAdapter(qCmbCatFill, dbconn.connection);
            DataTable dt = new DataTable();
            aCmbCatFill.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                cmbStoksItemCat.Items.Add(row[0].ToString());
            }

        }
        private void cmbItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbconn.CloseConnection();
            dbconn.OpenConnection();

            if (cmbStoksItemCat.Text == "ALL")
            {
                cmbStocksItem.Enabled = false;
                string qGetStocks = "SELECT " +
                    "s.barcode AS 'Bar Code', i.iname AS 'Item Name', i.category AS " +
                    "'Item Category', s.qty AS 'Quantity ', s.companyPrice, s.sellingPrice " +
                    "FROM items AS i JOIN stocks AS s ON i.id = s.itemid; ";
                MySqlDataAdapter aGetStocks = new MySqlDataAdapter(qGetStocks, dbconn.connection);
                DataSet ds = new DataSet();
                aGetStocks.Fill(ds, "Stocks");
                dgvStocks.DataSource = ds.Tables["Stocks"];
            }
            else
            {
                cmbStocksItem.Enabled = true;
                cmbStocksItem.Items.Clear();
                cmbStocksItem.Items.Add("ALL");
                cmbStocksItem.SelectedItem = "ALL";
                string selectedCategory = cmbStoksItemCat.Text;
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                string qCmbItemFill = "SELECT iname FROM items WHERE category = '" + selectedCategory + "';";
                MySqlDataAdapter aCmbItemFill = new MySqlDataAdapter(qCmbItemFill, dbconn.connection);
                DataTable dt = new DataTable();
                aCmbItemFill.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    cmbStocksItem.Items.Add(row[0].ToString());
                }

                string qGetStocks = "SELECT s.barcode, i.iname, i.category, s.qty, s.companyPrice, s.sellingPrice FROM items AS i JOIN stocks " +
               "AS s ON i.id = s.itemid WHERE i.category = '" + cmbStoksItemCat.Text + "'; ";
                MySqlDataAdapter aGetStocks = new MySqlDataAdapter(qGetStocks, dbconn.connection);
                DataSet ds = new DataSet();
                aGetStocks.Fill(ds, "Stocks2");
                dgvStocks.DataSource = ds.Tables["Stocks2"];

            }

        }
        private void cmbStocksItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (msCmbMgStocksItem.Text == "ALL")
            {
                MessageBox.Show("ok");
                //  string qGetStocks = "SELECT s.barcode, i.name, i.category, s.qty FROM items AS i JOIN stocks " +
                //"AS s ON i.id = s.itemid WHERE i.category = '" + cmbStoksItemCat.Text + "'; ";
                //  MySqlDataAdapter aGetStocks = new MySqlDataAdapter(qGetStocks, dbconn.connection);
                //  DataSet ds = new DataSet();
                //  aGetStocks.Fill(ds, "Stocks3");
                //  dgvStocks.DataSource = ds.Tables["Stocks3"];
            }
            else
            {
                string qGetStocks = "SELECT s.barcode, i.iname, i.category, s.qty, s.companyPrice, s.sellingPrice FROM items AS i JOIN stocks " +
                "AS s ON i.id = s.itemid WHERE i.category = '" + cmbStoksItemCat.Text + "' && i.iname = '" +
                cmbStocksItem.Text + "'; ";
                MySqlDataAdapter aGetStocks = new MySqlDataAdapter(qGetStocks, dbconn.connection);
                DataSet ds = new DataSet();
                aGetStocks.Fill(ds, "Stocks");
                dgvStocks.DataSource = ds.Tables["Stocks"];
            }

        }





























        private void tpcStocks_Click(object sender, EventArgs e)
        {

        }

        private void tpcManageStock_Enter(object sender, EventArgs e)
        {
            msBarCode.Focus();


        }



        private void tpcStock_Click(object sender, EventArgs e)
        {

        }

        private void txtStocks_ValueChanged(object sender, EventArgs e)
        {
            msStockTotal.Text = (decimal.Parse(msQuantity.Text) + decimal.Parse(msInHand.Text)).ToString();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            msDiscountPer.Text = "0";
            msDiscountFinal.Text = "0";
            if (msSellingPrice.Text != "" && msSellingPrice.Text != "0" && msSellingPrice.Text != "0.00")
            {
                if (msDiscount.Text != "" || msDiscount.Text != null || msDiscount.Text != "0" || msDiscount.Text != "0%")
                {
                    Decimal disCash = 0;
                    decimal disPer = 0;
                    string disValue = msDiscount.Text;
                    if (disValue.Length >= 1)
                    {
                        if (disValue.Substring(disValue.Length - 1) == "%")
                        {
                            if (decimal.Parse(disValue.Remove(disValue.Length - 1)) >= 100 || decimal.Parse(disValue.Remove(disValue.Length - 1)) < 0)
                            {
                                MessageBox.Show("Wrong Discount Percentage!!!");
                                msDiscount.Text = "0";
                            }
                            else
                            {
                                disCash = Math.Round(decimal.Parse(msSellingPrice.Text) * decimal.Parse(disValue.Remove(disValue.Length - 1)) / 100, 2);
                                msDiscountFinal.Text = disCash.ToString();
                                msDiscountPer.Text = msDiscount.Text;
                            }
                        }
                        else if (disValue.Substring(disValue.Length - 1) != "%" && disValue != "0")
                        {
                            if (decimal.Parse(disValue) < 0)
                            {
                                MessageBox.Show("Wrong Discount Amount!!!");
                                msDiscount.Text = "0";
                            }
                            else
                            {
                                disPer = Math.Round(decimal.Parse(disValue) / decimal.Parse(msSellingPrice.Text) * 100, 2);
                                msDiscountFinal.Text = msDiscount.Text;
                                msDiscountPer.Text = disPer.ToString();
                            }
                        }
                    }
                }
                else
                {
                    msDiscountFinal.Text = "0";
                    msDiscountPer.Text = "0%";
                }
            }

        }

        private void tpcProducts_Click(object sender, EventArgs e)
        {

        }

        private void msAddToStock_Click(object sender, EventArgs e)
        {
            string barcode = "", itemCategory = "", item = "", expiryDate = "";
            decimal companyPrice = 0, sellingPrice = 0, quantity = 0;
            decimal discountP = 0;

            if (msBarCode.Text != "" || msCmbMgStocksItemCat.Text != "" || msCmbMgStocksItem.Text != ""
                || msCompanyPrice.Text != "" || msSellingPrice.Text != "")
            {
                barcode = msBarCode.Text;
                itemCategory = msCmbMgStocksItemCat.Text;
                item = msCmbMgStocksItem.Text;
                companyPrice = Math.Round(decimal.Parse(msCompanyPrice.Text), 2);
                sellingPrice = Math.Round(decimal.Parse(msSellingPrice.Text), 2);
                discountP = Math.Round(decimal.Parse(msDiscountFinal.Text), 2);
                quantity = Math.Round(decimal.Parse(msStockTotal.Text), 3);
                expiryDate = msExpiryDate.Text;

                //MessageBox.Show("Not Completed Details!!!!");

                string itemId = "";
                MySqlCommand cmd = new MySqlCommand("SELECT id FROM items WHERE iname='" + item + "'", dbconn.connection);
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    itemId = reader.GetString(0);
                }
                reader.Close();
                string qAddToBill = "INSERT INTO stocks VALUES (" + barcode + "," + itemId +
               ", " + companyPrice + ", " + sellingPrice + ", " + discountP + ", " + quantity + ", '" +
               expiryDate + "');";
                MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
                int queryAffected = cAddToBill.ExecuteNonQuery();
                if (queryAffected > 0)
                {
                    MessageBox.Show("Stock Added!!!");
                    msClear_Click("", e);
                }
                msBarCode.Focus();
            }
        }

        private void msCompanyPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void msSellingPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void StockManagement_Load(object sender, EventArgs e)
        {
            msBarCode.Focus();
            msEditStock.Enabled = false;
            msDeleteStock.Enabled = false;
            if (LoginForm.loggedUser == "admin")
            {
                msEditStock.Enabled = true;
                msUpdateStock.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tpcProducts_Enter(object sender, EventArgs e)
        {
            uiUpdate.Enabled = false;

            iIsWeight.SelectedIndex = 1;

            uiItemCategory.Items.Clear();
            uiItemName.Items.Clear();
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qCmbItemFill = "SELECT DISTINCT category FROM items;";
            MySqlDataAdapter aCmbItemFill = new MySqlDataAdapter(qCmbItemFill, dbconn.connection);
            DataTable dt1 = new DataTable();
            aCmbItemFill.Fill(dt1);
            foreach (DataRow row in dt1.Rows)
            {
                uiItemCategory.Items.Add(row[0].ToString());
            }

            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qCmbItemFill1 = "SELECT DISTINCT iname FROM items;";
            MySqlDataAdapter aCmbItemFill1 = new MySqlDataAdapter(qCmbItemFill1, dbconn.connection);
            DataTable dt11 = new DataTable();
            aCmbItemFill1.Fill(dt11);
            foreach (DataRow row in dt11.Rows)
            {
                uiItemName.Items.Add(row[0].ToString());
            }
        }

        private void tpcManageStock_Enter_1(object sender, EventArgs e)
        {
            //MessageBox.Show("ok");
            msEditStock.Enabled = true;
            msDeleteStock.Enabled = true;
            if (LoginForm.loggedUser != "admin")
            {
                msEditStock.Enabled = false;
                msDeleteStock.Enabled = false;
            }

            msCmbMgStocksItemCat.Items.Clear();
            msCmbMgStocksItemCat.Items.Add("-SELECT-");
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qcmbcatfill = "select distinct category from items;";
            MySqlDataAdapter acmbcatfill = new MySqlDataAdapter(qcmbcatfill, dbconn.connection);
            DataTable dt = new DataTable();
            acmbcatfill.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                msCmbMgStocksItemCat.Items.Add(row[0].ToString());
            }
            msCmbMgStocksItemCat.SelectedIndex = 0;


        }

        private void cmbMgStocksItemCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (msCmbMgStocksItemCat.Text == "-SELECT-")
            {
                msCmbMgStocksItem.Enabled = false;
            }
            else
            {
                msCmbMgStocksItem.Enabled = true;
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                msCmbMgStocksItem.Items.Clear();
                msCmbMgStocksItem.Items.Add("-SELECT-");
                msCmbMgStocksItem.SelectedIndex = 0;
                string selectedCat = msCmbMgStocksItemCat.Text;
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                string qCmbItemFill = "SELECT iname FROM items WHERE category = '" + selectedCat + "';";
                MySqlDataAdapter aCmbItemFill = new MySqlDataAdapter(qCmbItemFill, dbconn.connection);
                DataTable dt = new DataTable();
                aCmbItemFill.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    msCmbMgStocksItem.Items.Add(row[0].ToString());
                }
            }
        }

        private void msClear_Click(object sender, EventArgs e)
        {
            msBarCode.Clear();
            msCmbMgStocksItem.Items.Add("-SELECT-");
            msCmbMgStocksItemCat.Items.Add("-SELECT-");
            msCmbMgStocksItem.SelectedIndex = 0;
            msCmbMgStocksItemCat.SelectedIndex = 0;
            msCompanyPrice.Text = "0.00";
            msSellingPrice.Text = "0.00";
            msDiscount.Text = "0";
            msQuantity.Text = "0";
            msStockTotal.Text = "0";
            msInHand.Text = "0";
            msDiscountFinal.Text = "0";
            msDiscountPer.Text = "0%";
            msExpiryDate.Value = DateTime.Now;



        }



        private void tpcManageStock_Click(object sender, EventArgs e)
        {

        }

        private void msBarCode_TextChanged(object sender, EventArgs e)
        {
            msAddToStock.Enabled = true;
            string itemCat = "";
            string item = "";
            string compPrice = "";
            string selPrice = "";
            string discount = "";
            string qty = "";
            string expDate_M = "0";
            string expDate_D = "0";
            string expDate_Y = "0";
            msDiscount.Text = "0";

            MySqlCommand cmd = new MySqlCommand("select i.iname, i.category, s.companyPrice, s.sellingPrice, s.discount, s.qty," +
                "EXTRACT(MONTH FROM s.expiry) as expMonth, EXTRACT(DAY FROM s.expiry) as expDay, EXTRACT(YEAR FROM s.expiry) as expYear" +
                " from items as i join stocks as s on i.id = s.itemid WHERE s.barcode = '" + msBarCode.Text + "';", dbconn.connection);
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    item = reader.GetString(0);
                    itemCat = reader.GetString(1);
                    compPrice = reader.GetString(2);
                    selPrice = reader.GetString(3);
                    discount = reader.GetString(4);
                    qty = reader.GetString(5);
                    expDate_M = reader.GetString(6);
                    expDate_D = reader.GetString(7);
                    expDate_Y = reader.GetString(8);

                }

            }
            else
            {
                msCmbMgStocksItemCat.SelectedItem = "-SELECT-";
                msCompanyPrice.Text = "0.00";
                msSellingPrice.Text = "0.00";
                msDiscount.Text = "0";
                msInHand.Text = "0";
                msStockTotal.Text = "0";
                msAddToStock.Enabled = true;
            }
            reader.Close();
            msAddToStock.Enabled = true;
            if (item != "" || item != null)
            {
                //MessageBox.Show(item);
                // msAddToStock.Enabled = false;    ithu ipadiae irukatimnaan enaduthala deug pannitjhcommit panran ver ena plauthu da sollu
                msCmbMgStocksItemCat.SelectedItem = itemCat;
                msCmbMgStocksItem.SelectedItem = item;
                msCompanyPrice.Text = compPrice;
                msSellingPrice.Text = selPrice;
                msDiscount.Text = discount;
                msInHand.Text = qty;
                msStockTotal.Text = msInHand.Text;
                if (expDate_D != "" && expDate_D != "0")
                {
                    msExpiryDate.Value = new DateTime(int.Parse(expDate_Y), int.Parse(expDate_M), int.Parse(expDate_D));
                }

                //int yr = int.Parse(expDate.Substring(0, 4)), mo = int.Parse(expDate.Substring(5, 2)), da = int.Parse(expDate.Substring(8, 2));
                //msExpiryDate.Value = new DateTime(yr, mo, da);
            }
        }

        private void msCompanyPrice_Enter(object sender, EventArgs e)
        {
            msCompanyPrice.Clear();
        }

        private void msSellingPrice_Enter(object sender, EventArgs e)
        {
            msSellingPrice.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qAddToBill = "delete from stocks where barcode = '" + msBarCode.Text + "'";
            MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
            int queryAffected = cAddToBill.ExecuteNonQuery();
            if (queryAffected > 0)
            {
                MessageBox.Show("Items Deleted!!!");
                msClear_Click("", e);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string barcode = "", itemCategory = "", item = "", expiryDate = "";
            decimal companyPrice = 0, sellingPrice = 0, quantity = 0;
            decimal discountP = 0;

            if (msBarCode.Text != "" || msCmbMgStocksItemCat.Text != "" || msCmbMgStocksItem.Text != ""
                || msCompanyPrice.Text != "" || msSellingPrice.Text != "")
            {
                barcode = msBarCode.Text;
                itemCategory = msCmbMgStocksItemCat.Text;
                item = msCmbMgStocksItem.Text;
                companyPrice = Math.Round(decimal.Parse(msCompanyPrice.Text), 2);
                sellingPrice = Math.Round(decimal.Parse(msSellingPrice.Text), 2);
                discountP = Math.Round(decimal.Parse(msDiscount.Text), 2);
                quantity = Math.Round(decimal.Parse(msStockTotal.Text), 3);
                expiryDate = msExpiryDate.Text;

                //MessageBox.Show("Not Completed Details!!!!");

                string itemId = "";
                MySqlCommand cmd = new MySqlCommand("SELECT id FROM items WHERE iname='" + item + "'", dbconn.connection);
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    itemId = reader.GetString(0);
                }
                reader.Close();
                string qAddToBill = "UPDATE stocks SET itemid='" + itemId + "', companyPrice=" + companyPrice + ", sellingPrice = " +
                    sellingPrice + ", discount = " + discountP + ", qty = " + quantity + ", expiry= '" + expiryDate +
                    "' WHERE barcode = '" + barcode + "';";
                MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
                int queryAffected = cAddToBill.ExecuteNonQuery();
                if (queryAffected > 0)
                {
                    MessageBox.Show("Stock Updated!!!");
                    msClear_Click("", e);
                }

            }
        }

        private void msInHand_TextChanged(object sender, EventArgs e)
        {
            //msStockTotal.Text = (decimal.Parse(msQuantity.Text) + decimal.Parse(msInHand.Text)).ToString();
        }

        private void msDiscount_Enter(object sender, EventArgs e)
        {
            msDiscount.Clear();
        }

        private void msDiscount_Leave(object sender, EventArgs e)
        {

            if (msDiscount.Text == "" || msDiscount.Text == "%" || msDiscount.Text == "0%")
            {
                msDiscount.Text = "0";
            }


        }

        private void msQuantity_Enter(object sender, EventArgs e)
        {
            //msQuantity.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }



        private void msDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void iItemName_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            iItemCategory.Text = "-SELECT-";
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string itemId = "";
            MySqlCommand cmd = new MySqlCommand("SELECT id, category FROM items WHERE iname='" + iItemName.Text + "'", dbconn.connection);
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    itemId = reader.GetString(0);
                    iItemCategory.Text = reader.GetString(1);
                }
                miItemId.Text = itemId.ToString();

            }
        }

        private void tpcManageProducts_Enter(object sender, EventArgs e)
        {


            //Add Items form load event
            iIsWeight.SelectedIndex = 1;

            iItemCategory.Items.Clear();
            iItemName.Items.Clear();
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qCmbItemFill = "SELECT DISTINCT category FROM items;";
            MySqlDataAdapter aCmbItemFill = new MySqlDataAdapter(qCmbItemFill, dbconn.connection);
            DataTable dt1 = new DataTable();
            aCmbItemFill.Fill(dt1);
            foreach (DataRow row in dt1.Rows)
            {
                iItemCategory.Items.Add(row[0].ToString());
            }

            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qCmbItemFill1 = "SELECT DISTINCT iname FROM items;";
            MySqlDataAdapter aCmbItemFill1 = new MySqlDataAdapter(qCmbItemFill1, dbconn.connection);
            DataTable dt11 = new DataTable();
            aCmbItemFill1.Fill(dt11);
            foreach (DataRow row in dt11.Rows)
            {
                iItemName.Items.Add(row[0].ToString());
            }
            button2_Click_1("", e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dbconn.CloseConnection();
            dbconn.OpenConnection();

            string itemName = iItemName.Text;
            string itemCat = iItemCategory.Text;
            string isWeight = iIsWeight.Text;

            string qAddToBill = "INSERT INTO items(iname, category, weight) VALUES ('" + itemName + "','" + itemCat +
                "', " + isWeight + ");";
            MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
            int queryAffected = cAddToBill.ExecuteNonQuery();
            if (queryAffected > 0)
            {
                MessageBox.Show("Items Added!!!");
                button2_Click_1("", e);
                tpcProducts_Enter("", e);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            iItemName.Text = "-SELECT-";
            iItemCategory.Text = "-SELECT-";
            miItemId.Clear();

            iIsWeight.SelectedIndex = 1;
        }

        private void miItemUpdate_Click(object sender, EventArgs e)
        { dbconn.CloseConnection();
            dbconn.OpenConnection();

            string qAddToBill = "UPDATE items SET iname='" + iItemName.Text + "', category='" + iItemCategory.Text + "', weight = '" +
                    iIsWeight.Text + "' where id=" + miItemId.Text + ";";
            MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
            int queryAffected = cAddToBill.ExecuteNonQuery();
            if (queryAffected > 0)
            {
                MessageBox.Show("Item Updated!!!");
                button2_Click_1("", e);
            }
        }

        private void msQuantity_TextChanged(object sender, EventArgs e)
        {

            if (msInHand.Text != "0" && msInHand.Text != "" && msQuantity.Text != "")
            {
                msStockTotal.Text = (decimal.Parse(msQuantity.Text) + decimal.Parse(msInHand.Text)).ToString();
            }
            else
            {
                msStockTotal.Text = msQuantity.Text;
            }
            //
        }

        private void msQuantity_Enter_1(object sender, EventArgs e)
        {

        }

        private void msEditStock_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tpcManageProducts_Click(object sender, EventArgs e)
        {

        }

        private void msCompanyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');
        }

        private void msSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');
        }

        private void msQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');
        }

        private void iItemName_TextChanged(object sender, EventArgs e)
        {
            itemTextChanged();



        }

        public void itemTextChanged()
        {
            miItemId.Clear();
            iItemCategory.Text = "-SELECT-";
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string itemId = "";
            MySqlCommand cmd = new MySqlCommand("SELECT id, category FROM items WHERE iname='" + iItemName.Text + "'", dbconn.connection);
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    itemId = reader.GetString(0);
                    iItemCategory.Text = reader.GetString(1);
                }
                miItemId.Text = itemId.ToString();

            }
        }

        private void button4_Click_2(object sender, EventArgs e)
        {

        }

        private void iItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemTextChanged();
        }

        private void uiItemCode_TextChanged(object sender, EventArgs e)
        {
            uiUpdate.Enabled = false;
            uiDelete.Enabled = false;
            if (uiItemCode.Text != "" && uiItemCode.Text != null)
            {
                uiUpdate.Enabled = true;
                uiDelete.Enabled = true;
            }
        }

        private void uiItemName_SelectedIndexChanged(object sender, EventArgs e)
        {

            updateItemTextChanged();
        }

        public void updateItemTextChanged()
        {
            
            uiItemCategory.Text = "-SELECT-";
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string itemId = "";
            string itemCat ="";
            MySqlCommand cmd = new MySqlCommand("SELECT id, category FROM items WHERE iname='" + uiItemName.Text +
                "'", dbconn.connection);
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    itemId = reader.GetString(0);
                    uiItemCode.Clear();
                    itemCat = reader.GetString(1);
                }
                uiItemCode.Text = itemId.ToString();
                uiItemCategory.Text = itemCat.ToString();
                uiUpdate.Enabled = true;
                uiDelete.Enabled = true;
            }
        }

        private void uiUpdate_Click(object sender, EventArgs e)
        {
            dbconn.CloseConnection();
            dbconn.OpenConnection();

            string qAddToBill = "UPDATE items SET iname='" + uiItemName.Text + "', category='" + uiItemCategory.Text + "', weight = '" +
                    uiItemIsWeight.Text + "' where id=" + uiItemCode.Text + ";";
            MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
            int queryAffected = cAddToBill.ExecuteNonQuery();
            if (queryAffected > 0)
            {
                MessageBox.Show("Item Updated!!!");
            }
        }

        private void uiDelete_Click(object sender, EventArgs e)
        {
            if(uiItemCode.Text != ""  && uiItemCode.Text != null)
            {
                dbconn.CloseConnection();
                dbconn.OpenConnection();

                string qAddToBill = "delete from items where id=" + uiItemCode.Text + ";";
                MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
                int queryAffected = cAddToBill.ExecuteNonQuery();
                if (queryAffected > 0)
                {
                    MessageBox.Show("Item Deleted!!!");
                }
            }
        }

        private void miItemId_TextChanged(object sender, EventArgs e)
        {
            miUpdateAdd.Enabled = true;
            if(miItemId.Text != null && miItemId.Text != "")
            {
                miUpdateAdd.Enabled = false;
            }
        }

        private void uiItemName_TextChanged(object sender, EventArgs e)
        {
            updateItemTextChanged();
        }
    }
}
