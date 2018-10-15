namespace SuperMarketMS
{
    partial class BillManagement
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAllBills = new System.Windows.Forms.DataGridView();
            this.dgvSelectedBills = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.csSalesDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedBills)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.90027F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.09972F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 642F));
            this.tableLayoutPanel1.Controls.Add(this.dgvAllBills, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvSelectedBills, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.csSalesDate, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 374F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1114, 442);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // dgvAllBills
            // 
            this.dgvAllBills.AllowUserToAddRows = false;
            this.dgvAllBills.AllowUserToDeleteRows = false;
            this.dgvAllBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllBills.Location = new System.Drawing.Point(63, 71);
            this.dgvAllBills.Name = "dgvAllBills";
            this.dgvAllBills.ReadOnly = true;
            this.dgvAllBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllBills.Size = new System.Drawing.Size(405, 368);
            this.dgvAllBills.TabIndex = 0;
            this.dgvAllBills.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllBills_RowEnter);
            // 
            // dgvSelectedBills
            // 
            this.dgvSelectedBills.AllowUserToAddRows = false;
            this.dgvSelectedBills.AllowUserToDeleteRows = false;
            this.dgvSelectedBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectedBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSelectedBills.Location = new System.Drawing.Point(474, 71);
            this.dgvSelectedBills.Name = "dgvSelectedBills";
            this.dgvSelectedBills.ReadOnly = true;
            this.dgvSelectedBills.Size = new System.Drawing.Size(637, 368);
            this.dgvSelectedBills.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(474, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(358, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // csSalesDate
            // 
            this.csSalesDate.CustomFormat = "yyyy-MM-dd";
            this.csSalesDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.csSalesDate.Location = new System.Drawing.Point(63, 3);
            this.csSalesDate.Name = "csSalesDate";
            this.csSalesDate.Size = new System.Drawing.Size(185, 25);
            this.csSalesDate.TabIndex = 8;
            this.csSalesDate.ValueChanged += new System.EventHandler(this.csSalesDate_ValueChanged);
            // 
            // BillManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 442);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BillManagement";
            this.Text = "BillManagement";
            this.Load += new System.EventHandler(this.BillManagement_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedBills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvAllBills;
        private System.Windows.Forms.DataGridView dgvSelectedBills;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker csSalesDate;
    }
}