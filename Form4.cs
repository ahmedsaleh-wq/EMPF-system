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
    public partial class Form4 : Form
    {
        private MySqlConnection connection;
        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;
        public Form4()
        {
            InitializeComponent();
            connect();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        void addAthlete()
        {
            string sql = "INSERT INTO sql2395628.Database VALUES (@LocalID, @Name, @DateOfBirth, @Club, @Gender, @UIPMID, NULL, NULL, @RidingLiscense, NULL, NULL)";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@LocalID", MySqlDbType.VarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@DateOfBirth", MySqlDbType.VarChar).Value = dateTimePicker1.Text;
            cmd.Parameters.Add("@Club", MySqlDbType.VarChar).Value = textBox4.Text;
            cmd.Parameters.Add("@Gender", MySqlDbType.VarChar).Value = comboBox1.Text.ToString();
            cmd.Parameters.Add("@UIPMID", MySqlDbType.VarChar).Value = textBox6.Text;
            cmd.Parameters.Add("@RidingLiscense", MySqlDbType.VarChar).Value = comboBox2.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch {
                MessageBox.Show("connection fail");
            }
            

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Fill required informations");
            }
            else
            {
                addAthlete();
                connection.Close();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void connect() {
            try
            {
                server = "sql2.freemysqlhosting.net";
                database = "sql2395628";
                uid = "sql2395628";
                password = "qS6*iH5*";
                port = "3306";
                string connectionString;
                connectionString = "Server=" + server + ";" + "port=" + port + ";" + "Database=" +
                database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";";

                connection = new MySqlConnection(connectionString);
                connection.Open();

            }
            catch
            {
                MessageBox.Show("Error connection");
            }
        }
    }

    

}
