namespace SuperMarketMS
{
    partial class PayOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.poBillDiscount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.poBillDisPer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.poBillDisCash = new System.Windows.Forms.TextBox();
            this.dgvFinalStocks = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.poItemSavings = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.poGross = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.poBalance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.poTotalBill = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.poCash = new System.Windows.Forms.TextBox();
            this.cmbCardType = new System.Windows.Forms.ComboBox();
            this.cmbLoanAccount = new System.Windows.Forms.ComboBox();
            this.cmbLoanName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.loanAmount = new System.Windows.Forms.TextBox();
            this.loanSettle = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.loanUpdateCre = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRevenue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalStocks)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(474, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 60);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cash";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(474, 436);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 59);
            this.button2.TabIndex = 9;
            this.button2.Text = "Loan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(474, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 59);
            this.button3.TabIndex = 5;
            this.button3.Text = "Card";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // poBillDiscount
            // 
            this.poBillDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poBillDiscount.Location = new System.Drawing.Point(169, 208);
            this.poBillDiscount.Name = "poBillDiscount";
            this.poBillDiscount.Size = new System.Drawing.Size(140, 29);
            this.poBillDiscount.TabIndex = 1;
            this.poBillDiscount.Text = "0";
            this.poBillDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.poBillDiscount.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.poBillDiscount.Enter += new System.EventHandler(this.poBillDiscount_Enter);
            this.poBillDiscount.Leave += new System.EventHandler(this.poBillDiscount_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Bill Discount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "%";
            // 
            // poBillDisPer
            // 
            this.poBillDisPer.Enabled = false;
            this.poBillDisPer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poBillDisPer.Location = new System.Drawing.Point(125, 243);
            this.poBillDisPer.Name = "poBillDisPer";
            this.poBillDisPer.Size = new System.Drawing.Size(51, 29);
            this.poBillDisPer.TabIndex = 4;
            this.poBillDisPer.Text = "0";
            this.poBillDisPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(182, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rs";
            // 
            // poBillDisCash
            // 
            this.poBillDisCash.Enabled = false;
            this.poBillDisCash.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poBillDisCash.Location = new System.Drawing.Point(215, 243);
            this.poBillDisCash.Name = "poBillDisCash";
            this.poBillDisCash.Size = new System.Drawing.Size(94, 29);
            this.poBillDisCash.TabIndex = 6;
            this.poBillDisCash.Text = "0";
            this.poBillDisCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvFinalStocks
            // 
            this.dgvFinalStocks.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvFinalStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinalStocks.Location = new System.Drawing.Point(37, 32);
            this.dgvFinalStocks.Name = "dgvFinalStocks";
            this.dgvFinalStocks.Size = new System.Drawing.Size(272, 10);
            this.dgvFinalStocks.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Item Savings";
            // 
            // poItemSavings
            // 
            this.poItemSavings.Enabled = false;
            this.poItemSavings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poItemSavings.Location = new System.Drawing.Point(169, 103);
            this.poItemSavings.Name = "poItemSavings";
            this.poItemSavings.Size = new System.Drawing.Size(140, 29);
            this.poItemSavings.TabIndex = 9;
            this.poItemSavings.Text = "0";
            this.poItemSavings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Gross Bill";
            // 
            // poGross
            // 
            this.poGross.Enabled = false;
            this.poGross.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poGross.Location = new System.Drawing.Point(169, 68);
            this.poGross.Name = "poGross";
            this.poGross.Size = new System.Drawing.Size(140, 29);
            this.poGross.TabIndex = 11;
            this.poGross.Text = "0";
            this.poGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(466, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 21);
            this.label6.TabIndex = 14;
            this.label6.Text = "Balance";
            // 
            // poBalance
            // 
            this.poBalance.Enabled = false;
            this.poBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poBalance.Location = new System.Drawing.Point(535, 48);
            this.poBalance.Name = "poBalance";
            this.poBalance.Size = new System.Drawing.Size(140, 29);
            this.poBalance.TabIndex = 13;
            this.poBalance.Text = "0";
            this.poBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "Total Bill";
            // 
            // poTotalBill
            // 
            this.poTotalBill.Enabled = false;
            this.poTotalBill.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poTotalBill.Location = new System.Drawing.Point(169, 278);
            this.poTotalBill.Name = "poTotalBill";
            this.poTotalBill.Size = new System.Drawing.Size(140, 29);
            this.poTotalBill.TabIndex = 15;
            this.poTotalBill.Text = "0";
            this.poTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.poTotalBill.TextChanged += new System.EventHandler(this.poTotalBill_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(466, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 21);
            this.label8.TabIndex = 18;
            this.label8.Text = "Cash";
            // 
            // poCash
            // 
            this.poCash.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poCash.Location = new System.Drawing.Point(535, 13);
            this.poCash.Name = "poCash";
            this.poCash.Size = new System.Drawing.Size(140, 29);
            this.poCash.TabIndex = 2;
            this.poCash.Text = "0";
            this.poCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.poCash.TextChanged += new System.EventHandler(this.poCash_TextChanged);
            this.poCash.Enter += new System.EventHandler(this.poCash_Enter);
            this.poCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.poCash_KeyPress);
            // 
            // cmbCardType
            // 
            this.cmbCardType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCardType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCardType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCardType.FormattingEnabled = true;
            this.cmbCardType.Items.AddRange(new object[] {
            "Sampath",
            "Seylan",
            "Commercial",
            "HNB",
            "MCB",
            "BOC",
            "Peoples Bank"});
            this.cmbCardType.Location = new System.Drawing.Point(474, 152);
            this.cmbCardType.Name = "cmbCardType";
            this.cmbCardType.Size = new System.Drawing.Size(201, 29);
            this.cmbCardType.TabIndex = 4;
            // 
            // cmbLoanAccount
            // 
            this.cmbLoanAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLoanAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLoanAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoanAccount.FormattingEnabled = true;
            this.cmbLoanAccount.Items.AddRange(new object[] {
            "Sampath",
            "Seylan",
            "Commercial",
            "HNB",
            "MCB",
            "BOC",
            "Peoples Bank"});
            this.cmbLoanAccount.Location = new System.Drawing.Point(474, 257);
            this.cmbLoanAccount.Name = "cmbLoanAccount";
            this.cmbLoanAccount.Size = new System.Drawing.Size(201, 29);
            this.cmbLoanAccount.TabIndex = 6;
            this.cmbLoanAccount.SelectedIndexChanged += new System.EventHandler(this.cmbLoanAccount_SelectedIndexChanged);
            // 
            // cmbLoanName
            // 
            this.cmbLoanName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLoanName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLoanName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoanName.FormattingEnabled = true;
            this.cmbLoanName.Items.AddRange(new object[] {
            "Sampath",
            "Seylan",
            "Commercial",
            "HNB",
            "MCB",
            "BOC",
            "Peoples Bank"});
            this.cmbLoanName.Location = new System.Drawing.Point(474, 292);
            this.cmbLoanName.Name = "cmbLoanName";
            this.cmbLoanName.Size = new System.Drawing.Size(201, 29);
            this.cmbLoanName.TabIndex = 7;
            this.cmbLoanName.SelectedIndexChanged += new System.EventHandler(this.cmbLoanName_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(375, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 21);
            this.label9.TabIndex = 22;
            this.label9.Text = "NIC No";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(375, 295);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 21);
            this.label10.TabIndex = 23;
            this.label10.Text = "Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(375, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 21);
            this.label11.TabIndex = 24;
            this.label11.Text = "Card Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(375, 330);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 21);
            this.label12.TabIndex = 25;
            this.label12.Text = "Credit";
            // 
            // loanAmount
            // 
            this.loanAmount.Enabled = false;
            this.loanAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanAmount.Location = new System.Drawing.Point(474, 327);
            this.loanAmount.Name = "loanAmount";
            this.loanAmount.Size = new System.Drawing.Size(201, 29);
            this.loanAmount.TabIndex = 26;
            this.loanAmount.Text = "0";
            this.loanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // loanSettle
            // 
            this.loanSettle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanSettle.Location = new System.Drawing.Point(535, 362);
            this.loanSettle.Name = "loanSettle";
            this.loanSettle.Size = new System.Drawing.Size(140, 29);
            this.loanSettle.TabIndex = 8;
            this.loanSettle.Text = "0";
            this.loanSettle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.loanSettle.TextChanged += new System.EventHandler(this.loanSettle_TextChanged);
            this.loanSettle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loanSettle_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(375, 365);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 21);
            this.label13.TabIndex = 27;
            this.label13.Text = "Settle";
            // 
            // loanUpdateCre
            // 
            this.loanUpdateCre.Enabled = false;
            this.loanUpdateCre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanUpdateCre.Location = new System.Drawing.Point(491, 397);
            this.loanUpdateCre.Name = "loanUpdateCre";
            this.loanUpdateCre.Size = new System.Drawing.Size(184, 29);
            this.loanUpdateCre.TabIndex = 30;
            this.loanUpdateCre.Text = "0";
            this.loanUpdateCre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(375, 400);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 21);
            this.label14.TabIndex = 29;
            this.label14.Text = "Update Credit";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(21, 141);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 21);
            this.label15.TabIndex = 32;
            this.label15.Text = "Revenue";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // txtRevenue
            // 
            this.txtRevenue.Enabled = false;
            this.txtRevenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevenue.Location = new System.Drawing.Point(169, 138);
            this.txtRevenue.Name = "txtRevenue";
            this.txtRevenue.Size = new System.Drawing.Size(140, 29);
            this.txtRevenue.TabIndex = 31;
            this.txtRevenue.Text = "0";
            this.txtRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PayOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 507);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtRevenue);
            this.Controls.Add(this.loanUpdateCre);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.loanSettle);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.loanAmount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbLoanName);
            this.Controls.Add(this.cmbLoanAccount);
            this.Controls.Add(this.cmbCardType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.poCash);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.poTotalBill);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.poBalance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.poGross);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.poItemSavings);
            this.Controls.Add(this.dgvFinalStocks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.poBillDisCash);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.poBillDisPer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.poBillDiscount);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PayOption";
            this.Text = "PayOption";
            this.Load += new System.EventHandler(this.PayOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalStocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox poBillDiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox poBillDisPer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox poBillDisCash;
        private System.Windows.Forms.DataGridView dgvFinalStocks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox poItemSavings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox poGross;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox poBalance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox poTotalBill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox poCash;
        private System.Windows.Forms.ComboBox cmbCardType;
        private System.Windows.Forms.ComboBox cmbLoanAccount;
        private System.Windows.Forms.ComboBox cmbLoanName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox loanAmount;
        private System.Windows.Forms.TextBox loanSettle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox loanUpdateCre;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRevenue;
    }
}