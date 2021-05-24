using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace EMPF
{
    public partial class Login : Form
    {
        private MySqlConnection connection;

        public Login(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
           

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String username = textBox1.Text;
            String password = textBox2.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM sql2395628.Database WHERE `LocalID` = @usn", connection);

            cmd.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = cmd;

            adapter.Fill(table);


            if (table.Rows.Count > 0 && username == password)
            {
                AthleteForm dashboard = new AthleteForm(username, connection);
                dashboard.Show();
                this.Hide();

            } else if (username == "hossam45" && password=="055177"){
                Form5 dashboardList = new Form5(connection);
                dashboardList.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Wrong username or password!!");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
