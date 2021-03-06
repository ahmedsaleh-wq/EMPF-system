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
    public partial class Main : Form
    {
        private MySqlConnection connection;

        private string search;
        public Main(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            loadData();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        { 
        }

        void loadData() {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT `LocalID`, `NAME`, `DATE OF BIRTH`, `CLUB`, `GENDER`, `UIPM ID`,  `Riding liscense` FROM sql2395628.Database", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Database");
            dataGridView1.DataSource = ds.Tables["Database"];
        }




        private void button2_Click_1(object sender, EventArgs e)
        {
            Form4 insertPanel = new Form4();
            insertPanel.Show();
            connection.Close();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            Create createComp = new Create(connection);
            createComp.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Competitions view = new Competitions(connection);
            view.Show();
            this.Hide();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
 
            string query = "SELECT `LocalID`, `NAME`, `DATE OF BIRTH`, `CLUB`, `GENDER`, `UIPM ID`,  `Riding liscense` FROM sql2395628.Database  WHERE CONCAT (`NAME`, `LocalID`, `UIPM ID`) LIKE '%" + bunifuTextbox1.text+"%'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = dataGridView1.Rows[e.RowIndex];
            textBox2.Text = dgvr.Cells[0].Value.ToString();
            textBox1.Text = dgvr.Cells[1].Value.ToString();
            textBox3.Text = dgvr.Cells[2].Value.ToString();
            textBox4.Text = dgvr.Cells[3].Value.ToString();
            comboBox2.Text = dgvr.Cells[4].Value.ToString();
            textBox6.Text = dgvr.Cells[5].Value.ToString();
            comboBox1.Text = dgvr.Cells[6].Value.ToString();
            search = textBox2.Text;

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
            { MessageBox.Show("Select an athlete from the table"); }
            else { 
                DialogResult res = MessageBox.Show("Are you sure you want to Delete ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "delete from sql2395628.Database where `LocalID`='" + textBox2.Text + "';";
                    cmd.ExecuteNonQuery();
                    loadData();
                }
                if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("Cancelled");
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string name, localID, dob, gender, club, uipmID, LR;
            name = textBox1.Text;
            localID = textBox2.Text;
            dob = textBox3.Text;
            club = textBox4.Text;
            gender = comboBox2.Text;
            uipmID = textBox6.Text;
            LR = comboBox1.Text;
            
            MySqlCommand cmd;
            MySqlDataReader reader;
            DialogResult res = MessageBox.Show("Are you sure you want to update athlete info ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
                {
                    MessageBox.Show("Select an athlete from the table");
                }
                else
                {
                    
                    string query = "update sql2395628.Database set `LocalID`='" + localID + "',`NAME`='" + name + "',  `DATE OF BIRTH` ='" + dob + "',`CLUB` ='" + club + "', `GENDER` ='" + gender + "',`UIPM ID` ='" + uipmID + "',  `Riding liscense` ='" + LR + "'  where `LocalID` ='" + search + "'; "; 
                    try
                    {
                        cmd = new MySqlCommand(query, connection);
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    loadData();
                }

            }
            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("Cancelled");
                
            }
    

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Select an athlete from the table");
            }
            else {
                IDcard idcard = new IDcard(textBox2.Text, textBox1.Text, textBox3.Text, textBox4.Text, comboBox2.Text);
                idcard.Show();
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Calender calender = new Calender(connection);
            calender.Show();
            this.Hide();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Login login = new Login(connection);
            login.Show();
            this.Hide();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Form5 dashboardList = new Form5(connection);
            dashboardList.Show();
            this.Hide();
        }
    }
}
