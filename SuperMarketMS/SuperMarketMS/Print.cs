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
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            string[] a = { "Apple", "Ornage", "Test" };
            int lineChar = 31;
            for (int i=0; i < 2; i++)
            {
                int spacePrint = lineChar - a[i].Length;
                
                s = s + a[i];
                for (int j = 0; j < spacePrint; j++)
                {
                    s += " ";
                }
            }
            //string s = "Test Print Hello World";

            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(s, new Font("Seqoe ui", 10), new SolidBrush(Color.Black),
                    new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width,
                    p.DefaultPageSettings.PrintableArea.Height));
            };
            p.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //textBox1.Text = String.Format("{0:#,0.000}", 12);
            MessageBox.Show(DateTime.Now.ToString("yyMMddhhmmssMs"));
        }
    }
}
