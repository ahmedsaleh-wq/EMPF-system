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
    public partial class AthleteForm : Form
    {
        private MySqlConnection connection;

        private string ID;
        public AthleteForm(string ID, MySqlConnection connection)
        {
            InitializeComponent();
            this.ID = ID;
            this.connection = connection;


        }

        private void AthleteForm_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM sql2395628.Database WHERE `LocalID` ='"+ID+"'";



            MySqlCommand cmd ;
            MySqlDataReader reader ;
            cmd = new MySqlCommand(sql, connection);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                label1.Text = reader.GetString("LocalID");
                label2.Text = reader.GetString("NAME");
                label3.Text = reader.GetString("DATE OF BIRTH");
                label4.Text = reader.GetString("CLUB");
                label5.Text = reader.GetString("GENDER");
                label6.Text = reader.GetString("UIPM ID");
                label7.Text = reader.GetString("Certified");
            }
            reader.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calender2 calender = new Calender2(ID, connection);
            calender.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login(connection);
            login.Show();
            this.Hide();
        }
    }
}
