using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace EMPF
{
    public partial class Form5 : Form
    {
        private MySqlConnection connection;
        public Form5(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }


        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Main dashboard = new Main(connection);
            dashboard.Show();
            this.Hide();
        }
    }
}
