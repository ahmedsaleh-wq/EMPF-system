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
    public partial class Competitions : Form
    {
        private MySqlConnection connection;
        public Competitions(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void Competitions_Load(object sender, EventArgs e)
        {

            string query = "SELECT * FROM sql2395628.Calender";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = dgvr.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main(connection);
            main.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Select Competition");
            }
            else {
                Form1 competition = new Form1(textBox1.Text, connection);
                competition.Show();
                this.Hide();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
