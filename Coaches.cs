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
    public partial class Coaches : Form
    {
        private MySqlConnection connection;
        public Coaches(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Form5 dashboardList = new Form5(connection);
            dashboardList.Show();
            this.Hide();
        }
    }
}
