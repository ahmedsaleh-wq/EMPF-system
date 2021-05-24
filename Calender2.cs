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
    public partial class Calender2 : Form
    {
        MySqlConnection connection;
        string id;
        public Calender2(string id, MySqlConnection connection)
        {
            InitializeComponent();
            this.id = id;
            this.connection = connection;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AthleteForm athlete = new AthleteForm(id, connection);
            athlete.Show();
            this.Hide();
        }

        private void Calender2_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM sql2395628.Calender", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Database");
            dataGridView1.DataSource = ds.Tables["Database"];
        }
    }
}
