﻿using System;
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
    public partial class Calender : Form
    {
        private MySqlConnection connection;
        public Calender(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main(connection);
            main.Show();
            this.Hide();
        }

        private void Calender_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM sql2395628.Calender", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Database");
            dataGridView1.DataSource = ds.Tables["Database"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
