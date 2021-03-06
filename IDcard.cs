using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMPF
{
    
    public partial class IDcard : Form
    {
        public IDcard(string id, string name, string dob, string club, string gender)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(id)) {
                id = "000000";
            }

            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode =
                Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox2.Image = brCode.Draw(id, 60);
            }
            catch (Exception)
            {

            }
            label2.Text = name;
            label3.Text = id;
            label4.Text = gender;
            label5.Text = dob;
            label6.Text = club;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        Bitmap bitmap;
        private void IDcard_Load(object sender, EventArgs e)
        {
            
        }


        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to print ID card ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                label7.Visible = false;
                Panel panel = new Panel();
                this.Controls.Add(panel);
                Graphics grp = panel.CreateGraphics();
                Size formSize = this.ClientSize;
                bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
                grp = Graphics.FromImage(bitmap);
                Point panelLocation = PointToScreen(panel.Location);
                grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
            }
            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("Cancelled");

            }
            this.Hide();
        }
    }
}
