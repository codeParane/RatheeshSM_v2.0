using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketMS
{
    public partial class PayOption : Form
    {
        DbConn dbconn = new DbConn();
        public PayOption()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (poBillDiscount.Text != "" && poBillDiscount.Text != null)
            {
                decimal gross = Math.Round(decimal.Parse(poGross.Text), 2);
                decimal itemSaving = Math.Round(decimal.Parse(poItemSavings.Text), 2);
                decimal gross_itemSaving = gross - itemSaving;
                if (poBillDiscount.Text != "")
                {
                    decimal disCash = 0;
                    decimal disPer = 0;



                    string disValue = poBillDiscount.Text;
                    decimal disValueDecimal = 0;

                    if (disValue.Substring(disValue.Length - 1) == "%" && disValue != "0")
                    {
                        disValueDecimal = decimal.Parse(disValue.Remove(disValue.Length - 1));
                        if (decimal.Parse(disValue.Remove(disValue.Length - 1)) >= 100 || decimal.Parse(disValue.Remove(disValue.Length - 1)) < 0)
                        {
                            MessageBox.Show("Wrong Discount Percentage!!!");
                            poBillDiscount.Text = "0"; poBillDisPer.Text = "0"; poBillDisCash.Text = "0";
                        }
                        else
                        {
                            disCash = Math.Round(gross_itemSaving * (disValueDecimal / 100), 2);
                            poBillDisCash.Text = disCash.ToString();
                            poBillDisPer.Text = poBillDiscount.Text;
                            poTotalBill.Text = Math.Round(gross_itemSaving - decimal.Parse(poBillDisCash.Text), 2).ToString();
                        }
                    }
                    else if (disValue.Substring(disValue.Length - 1) != "%" && disValue != "0")
                    {
                        disValueDecimal = decimal.Parse(disValue);
                        if (disValueDecimal < 0)
                        {
                            MessageBox.Show("Wrong Discount Amount!!!");
                            poBillDiscount.Text = "0"; poBillDisPer.Text = "0"; poBillDisCash.Text = "0";
                        }
                        else if (disValueDecimal > 0)
                        {
                            decimal div = 0;
                            div = disValueDecimal / gross_itemSaving;
                            disPer = Math.Round(div * 100, 2);
                            poBillDisCash.Text = poBillDiscount.Text;
                            poBillDisPer.Text = disPer.ToString();
                            poTotalBill.Text = Math.Round(gross_itemSaving - decimal.Parse(poBillDisCash.Text), 2).ToString();
                        }
                    }
                }
                else
                {
                    poBillDisPer.Text = "0%";
                    poBillDisCash.Text = "0";
                    poTotalBill.Text = gross_itemSaving.ToString();
                }
            }
            if (poCash.Text != "0" && poCash.Text != "" && poCash.Text != null)
            {
                poBalance.Text = Math.Round(decimal.Parse(poCash.Text) - decimal.Parse(poTotalBill.Text), 2).ToString();

            }
            else
            {
                poBalance.Text = poTotalBill.Text;
            }
        }
        decimal comp = 0;

        private void PayOption_Load(object sender, EventArgs e)
        {
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qGetStocks = "select itemcode, itemname, qty, rate, disa, net, cmprice from currentbill; ";
            MySqlDataAdapter aGetStocks = new MySqlDataAdapter(qGetStocks, dbconn.connection);
            DataSet ds = new DataSet();
            aGetStocks.Fill(ds, "sto");
            dgvFinalStocks.DataSource = ds.Tables["sto"];

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            comp = 0;
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qr_getProduct = "SELECT sum(disa) AS dis, sum(net)  AS net, sum(cmprice) AS cmp FROM sm.currentbill;";
            MySqlCommand cm_getProduct = new MySqlCommand(qr_getProduct, dbconn.connection);
            MySqlDataReader dr_getProduct = cm_getProduct.ExecuteReader();

            if (dr_getProduct.HasRows == true)
            {
                while (dr_getProduct.Read())
                {
                    if(dr_getProduct["dis"] != null)
                    {
                        poGross.Text = (decimal.Parse(dr_getProduct["dis"].ToString()) + decimal.Parse(dr_getProduct["net"].ToString())).ToString();
                        poItemSavings.Text = dr_getProduct["dis"].ToString();
                        poTotalBill.Text = dr_getProduct["net"].ToString();
                        comp = Math.Round(decimal.Parse(dr_getProduct["cmp"].ToString()), 2);
                    }
                }
                decimal revenue = Math.Round(decimal.Parse(dr_getProduct["net"].ToString()) - comp, 2);
            }
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }else if (e.KeyCode == Keys.Enter)
            {
                DialogResult dialogResult = MessageBox.Show("Do You Want Print Bill?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    finalSale("cash", true);
                }
                else if (dialogResult == DialogResult.No)
                {
                    finalSale("cash", false);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Want Print Bill?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                finalSale("cash", true);
            }
            else if (dialogResult == DialogResult.No)
            {
                finalSale("cash", false);
            }
           
        }

       

        private void poCash_TextChanged(object sender, EventArgs e)
        {
            if (poBillDiscount.Text != "" && poBillDiscount.Text != null)
            {
                decimal gross = Math.Round(decimal.Parse(poGross.Text), 2);
                decimal itemSaving = Math.Round(decimal.Parse(poItemSavings.Text), 2);
                decimal gross_itemSaving = gross - itemSaving;
                if (poBillDiscount.Text != "")
                {
                    decimal disCash = 0;
                    decimal disPer = 0;



                    string disValue = poBillDiscount.Text;
                    decimal disValueDecimal = 0;

                    if (disValue.Substring(disValue.Length - 1) == "%" && disValue != "0")
                    {
                        disValueDecimal = decimal.Parse(disValue.Remove(disValue.Length - 1));
                        if (decimal.Parse(disValue.Remove(disValue.Length - 1)) >= 100 || decimal.Parse(disValue.Remove(disValue.Length - 1)) < 0)
                        {
                            MessageBox.Show("Wrong Discount Percentage!!!");
                            poBillDiscount.Text = "0"; poBillDisPer.Text = "0"; poBillDisCash.Text = "0";
                        }
                        else
                        {
                            disCash = Math.Round(gross_itemSaving * (disValueDecimal / 100), 2);
                            poBillDisCash.Text = disCash.ToString();
                            poBillDisPer.Text = poBillDiscount.Text;
                            poTotalBill.Text = Math.Round(gross_itemSaving - decimal.Parse(poBillDisCash.Text), 2).ToString();
                        }
                    }
                    else if (disValue.Substring(disValue.Length - 1) != "%" && disValue != "0")
                    {
                        disValueDecimal = decimal.Parse(disValue);
                        if (disValueDecimal < 0)
                        {
                            MessageBox.Show("Wrong Discount Amount!!!");
                            poBillDiscount.Text = "0"; poBillDisPer.Text = "0"; poBillDisCash.Text = "0";
                        }
                        else if (disValueDecimal > 0)
                        {
                            decimal div = 0;
                            div = disValueDecimal / gross_itemSaving;
                            disPer = Math.Round(div * 100, 2);
                            poBillDisCash.Text = poBillDiscount.Text;
                            poBillDisPer.Text = disPer.ToString();
                            poTotalBill.Text = Math.Round(gross_itemSaving - decimal.Parse(poBillDisCash.Text), 2).ToString();
                        }
                    }
                }
                else
                {
                    poBillDisPer.Text = "0%";
                    poBillDisCash.Text = "0";
                    poTotalBill.Text = gross_itemSaving.ToString();
                }
            }

            if (poCash.Text != "0" && poCash.Text != "" && poCash.Text  != null)
            {
                poBalance.Text = Math.Round(decimal.Parse(poCash.Text) - decimal.Parse(poTotalBill.Text), 2).ToString();

            }
            else
            {
                poBalance.Text = poTotalBill.Text;
            }
        }

        private void poCash_Enter(object sender, EventArgs e)
        {
            poCash.Clear();
        }

        private void poBillDiscount_Enter(object sender, EventArgs e)
        {
            poBillDiscount.Clear();
        }

        private void poBillDiscount_Leave(object sender, EventArgs e)
        {
            if(poBillDiscount.Text == "")
            {
                poBillDiscount.Text = "0";
            }
        }



        public void finalSale(string payType, Boolean isPrint)
        {

            string printString = "";
            PrintDocument p = new PrintDocument();


            //headerPrint
            string header =
               "      SHATTHVEES SUPERMART" +
              "\n       Main Street, Kommathurai." +
                "\n                  065-2050369";


            //"\n-------------------------------------------\n";
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(header, new Font("Cooper std black", 10), new SolidBrush(Color.Black),
                    new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width,
                    p.DefaultPageSettings.PrintableArea.Height));
            };
            //----------------------------------


            string title =
                "\n----------------------------------------------------------" +
                "\n No Item Qty\t Price \t Dis\t Amount" +
                "\n----------------------------------------------------------";


            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qr_getProducta = "select itemcode, itemname, qty, rate, disa, net, cmprice from currentbill;";
            MySqlCommand cm_getProducta = new MySqlCommand(qr_getProducta, dbconn.connection);
            MySqlDataReader dr_getProducta = cm_getProducta.ExecuteReader();

            String billId = DateTime.Now.ToString("yyMMddhhmmssMs");

            //ItemList
            string itemList = "";
            if (dr_getProducta.HasRows == true)
            {
                int num = 1;
                while (dr_getProducta.Read())
                {
                    string barCode = dr_getProducta["itemcode"].ToString();
                    string itemName = dr_getProducta["itemname"].ToString();
                    decimal qty = Math.Round(decimal.Parse(dr_getProducta["qty"].ToString()), 3);
                    decimal rate = Math.Round(decimal.Parse(dr_getProducta["rate"].ToString()), 2);
                    decimal dis = Math.Round(decimal.Parse(dr_getProducta["disa"].ToString()), 2);
                    decimal net = Math.Round(decimal.Parse(dr_getProducta["net"].ToString()), 2);

                        
                    decimal qtyValue = qty;

                    dbconn.CloseConnection();
                    dbconn.OpenConnection();
                    string qAddToBill = "insert into storedbills values("+ billId +","
                        + DateTime.Now.ToString("yyyy-MM-dd") +","+ barCode +",'"+ itemName +"',"
                        + qty +","+ net +")";
                    MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
                    int queryAffected = cAddToBill.ExecuteNonQuery();
                    if (queryAffected > 0)
                    {
                    }






                    itemList += "\n   " + num + " - " + itemName;
                    itemList += "\n                 " + String.Format("{0:#,0.000}", qty) + "\t" + String.Format("{0:N}", rate) + "\t" +
                        String.Format("{0:N}", dis) + "\t" + String.Format("{0:N}", net);
                    num++;
                }
            }


            for(int i =0; i < dgvFinalStocks.RowCount; i++)
            {
                string barCode = dgvFinalStocks.Rows[0].Cells[0].Value.ToString();
                decimal qty = decimal.Parse(dgvFinalStocks.Rows[0].Cells[2].Value.ToString());

                dbconn.CloseConnection();
                dbconn.OpenConnection();
                string qAddToBill = "update stocks set qty=qty-" + qty + " where barcode='" + barCode + "';";
                MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
                int queryAffected = cAddToBill.ExecuteNonQuery();
                if (queryAffected > 0)
                {

                }

            }
            string payTypeBill = "";
          
         


            if (payType == "cash")
            {
                decimal revenue = Math.Round(decimal.Parse(poTotalBill.Text) - comp, 2);
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                string qAddToBill1 = "INSERT INTO sales(billId, billDate, amount, revenue, payType)  VALUES ('" 
                    + billId + "'," + poTotalBill.Text + "," + revenue + ", 'cash');delete from currentbill;";
                MySqlCommand cAddToBill1 = new MySqlCommand(qAddToBill1, dbconn.connection);
                int queryAffected1 = cAddToBill1.ExecuteNonQuery();

                payTypeBill =
                    "\n\t\tPaid By\t: Cash   " + 
                    "\n\t\tCash\t: " + String.Format("{0:N}", decimal.Parse(poCash.Text)) +
                    "\n\t\tBalance\t: " + String.Format("{0:N}", decimal.Parse(poBalance.Text));
            }
            else if (payType == "card")
            {
                decimal revenue = Math.Round(decimal.Parse(poTotalBill.Text) - comp, 2);
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                string qAddToBill1 = "INSERT INTO sales(billId, billDate, amount, revenue, payType)  VALUES ('" 
                    + billId + "'," + poTotalBill.Text + "," + revenue + ", 'card');delete from currentbill;";
                MySqlCommand cAddToBill1 = new MySqlCommand(qAddToBill1, dbconn.connection);
                int queryAffected1 = cAddToBill1.ExecuteNonQuery();

                payTypeBill =
                    "\n\t\tPaid By\t : Credit Card" + 
                    "\n\t\tBank\t   : " + cmbCardType.Text +
                    "\n\t\tDeducted : " + String.Format("{0:N}", decimal.Parse(poTotalBill.Text));
            }
            else if (payType == "loan")
            {
                decimal revenue = Math.Round(decimal.Parse(poTotalBill.Text) - comp, 2);
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                string qAddToBill1 = "INSERT INTO sales(billId, billDate, amount, revenue, payType)  VALUES ('"
                    + billId + "'," + poTotalBill.Text + "," + revenue + ", 'loan');delete from currentbill;";
                MySqlCommand cAddToBill1 = new MySqlCommand(qAddToBill1, dbconn.connection);
                int queryAffected1 = cAddToBill1.ExecuteNonQuery();

                payTypeBill =
                    "\n\t\tPaid By\t: Loan" + 
                    "\n\t\tAccount\t: " + cmbLoanAccount.Text +
                    "\n\t\tPerson\t: " + cmbLoanName.Text +
                    "\n\t\tSettle\t: " + String.Format("{0:N}", decimal.Parse(loanSettle.Text)) +
                    "\n\t\tTotal Credit: " + String.Format("{0:N}", decimal.Parse(loanSettle.Text));
            }

            //SELECT fields FROM table ORDER BY id DESC LIMIT 1;
            //int lastBillid = 0;
            //dbconn.CloseConnection();
            //dbconn.OpenConnection();
            //string qr_getProducta2 = "select id from sales order by id desc limit 1;";
            //MySqlCommand cm_getProducta2 = new MySqlCommand(qr_getProducta2, dbconn.connection);
            //MySqlDataReader dr_getProducta2 = cm_getProducta2.ExecuteReader();

            //if (dr_getProducta2.HasRows == true)
            //{
            //    while (dr_getProducta2.Read())
            //    {
            //        lastBillid = int.Parse(dr_getProducta2["id"].ToString());
            //    }
            //}

            string billDiscount = "";
            if (poBillDiscount.Text == "" || poBillDiscount.Text == "0" || poBillDiscount.Text == null)
            {
                billDiscount = String.Format("{0:N}", 0.00);
            }
            else
            {
                billDiscount = String.Format("{0:N}", decimal.Parse(poBillDiscount.Text));
            }


            string totalBill =
               "\n---------------------------------------------------------" +
                "\n\n\t\tGross \t : " + String.Format("{0:N}", decimal.Parse(poGross.Text)) +
                "\n\t\tItems Discount : "  + String.Format("{0:N}", decimal.Parse(poItemSavings.Text)) +
                "\n\t\tBill Discount : " + billDiscount +
                "\n\t\tTotal \t : " + String.Format("{0:N}", decimal.Parse(poTotalBill.Text));

            string bestBuy = 
                "\n\n  * Best Buy Discount\t : " + String.Format("{0:N}", (decimal.Parse(poBillDiscount.Text) + decimal.Parse(poItemSavings.Text)));
         
            string title2 =
                "\n " + DateTime.Now.ToString("yyyy / MM / dd") + " | " + DateTime.Now.ToString("hh:mm:ss")
                + " | No: " + billId + " | " + LoginForm.loggedUser;
                
            string footer =
                "\n----------------------------------------------------------" +
                "\n         --------IMPORTANT NOTICE--------" +
                "\n        In case of a price discrepancy, return" +
                "\n             the item & bill within 3 days to" +
                "\n                  refund the difference." +
                "\n        <<<<  Thank You, Come Again... >>>>";


            printString += title2;
            printString += title;
            printString += itemList;
            printString += totalBill;
            printString += payTypeBill;
            printString += bestBuy;
            printString += footer;

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(printString, new Font("Seqoe ui", 10), new SolidBrush(Color.Black),
                    new RectangleF(0, 80, p.DefaultPageSettings.PrintableArea.Width,
                    p.DefaultPageSettings.PrintableArea.Height));
            };
            if (isPrint)
            {
                p.Print();
            }
           
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Want Print Bill?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                finalSale("card", true);
            }
            else if (dialogResult == DialogResult.No)
            {
                finalSale("card", false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Want Print Bill?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                finalSale("loan", true);
            }
            else if (dialogResult == DialogResult.No)
            {
                finalSale("loan", false);
            }
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qAddToBill = "UPDATE customers SET loan= loan + " + poTotalBill.Text +
                "WHERE nic = '" + cmbLoanAccount.Text + "';";
            MySqlCommand cAddToBill = new MySqlCommand(qAddToBill, dbconn.connection);
            int queryAffected = cAddToBill.ExecuteNonQuery();
            if (queryAffected > 0)
            {
                MessageBox.Show("Loan Updated!!!");
            }
            if (decimal.Parse(poTotalBill.Text) > decimal.Parse(loanSettle.Text))
            {
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                string qAddToBill4 = "insert into loan(nic, method, amount, dateNtime) values('" +
                cmbLoanAccount.Text + "', 'Settled', " + (decimal.Parse(loanSettle.Text) - 
                decimal.Parse(poTotalBill.Text)) + ", '" + DateTime.Now + "');"; 
                MySqlCommand cAddToBill4 = new MySqlCommand(qAddToBill4, dbconn.connection);
                int queryAffected4 = cAddToBill4.ExecuteNonQuery();
            } else if (decimal.Parse(poTotalBill.Text) < decimal.Parse(loanSettle.Text))
            {
                dbconn.CloseConnection();
                dbconn.OpenConnection();
                string qAddToBill5 = "insert into loan(nic, method, amount, dateNtime) values('" +
                cmbLoanAccount.Text + "', 'Credited', " + (decimal.Parse(poTotalBill.Text) - 
                decimal.Parse(loanSettle.Text)) + ", '" + DateTime.Now + "');";
                MySqlCommand cAddToBill5 = new MySqlCommand(qAddToBill5, dbconn.connection);
                int queryAffected5 = cAddToBill5.ExecuteNonQuery();
            }
            
        }

        private void cmbLoanName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loanAmount.Text = "0";
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qr_getProducta2 = "select nic,loan from customers where nic='" + cmbLoanName.Text + "';";
            MySqlCommand cm_getProducta2 = new MySqlCommand(qr_getProducta2, dbconn.connection);
            MySqlDataReader dr_getProducta2 = cm_getProducta2.ExecuteReader();

            if (dr_getProducta2.HasRows == true)
            {
                while (dr_getProducta2.Read())
                {
                    cmbLoanAccount.Text = dr_getProducta2["nic"].ToString();
                    loanAmount.Text = dr_getProducta2["loan"].ToString();
                }
            }

        }

        private void cmbLoanAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            loanAmount.Text = "0";
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            string qr_getProducta2 = "select name, loan from customers where nic='" + cmbLoanAccount.Text +"';";
            MySqlCommand cm_getProducta2 = new MySqlCommand(qr_getProducta2, dbconn.connection);
            MySqlDataReader dr_getProducta2 = cm_getProducta2.ExecuteReader();

            if (dr_getProducta2.HasRows == true)
            {
                while (dr_getProducta2.Read())
                {
                    cmbLoanName.Text = dr_getProducta2["name"].ToString();
                    loanAmount.Text = dr_getProducta2["loan"].ToString();
                }
            }

           
        }

        private void poTotalBill_TextChanged(object sender, EventArgs e)
        {
            if(cmbLoanAccount.Text != "-SELECT-" && cmbLoanName.Text != "-SELECT-")
            {
                loanUpdateCre.Text = (decimal.Parse(loanAmount.Text) + decimal.Parse(poTotalBill.Text) - 
                    decimal.Parse(loanSettle.Text)).ToString();
            }
        }

        private void loanSettle_TextChanged(object sender, EventArgs e)
        {
            if (cmbLoanAccount.Text != "-SELECT-" && cmbLoanName.Text != "-SELECT-")
            {
                loanUpdateCre.Text = (decimal.Parse(loanAmount.Text) + decimal.Parse(poTotalBill.Text) -
                    decimal.Parse(loanSettle.Text)).ToString();
            }
        }

        private void poCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');
        }

        private void loanSettle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.');
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
