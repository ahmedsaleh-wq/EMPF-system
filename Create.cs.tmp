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
using System.Collections;

namespace EMPF
{

    public partial class Create : Form
    {
        private MySqlConnection connection;


        public Create(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void Create_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT `LocalID`, `NAME`, `DATE OF BIRTH`, `CLUB`, `UIPM ID` FROM sql2395628.Database", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Database");
            dataGridView1.DataSource = ds.Tables["Database"];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = dataGridView1.Rows[e.RowIndex];
            label15.Text = dgvr.Cells[0].Value.ToString();
            label14.Text = dgvr.Cells[1].Value.ToString();
            label13.Text = dgvr.Cells[2].Value.ToString();
            label12.Text = dgvr.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(label15.Text) || string.IsNullOrEmpty(label14.Text) || string.IsNullOrEmpty(label13.Text) || string.IsNullOrEmpty(label12.Text))
            {
                MessageBox.Show("Select athete!!");
            }
            else {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (label15.Text.ToString() == dataGridView2.Rows[i].Cells[0].Value.ToString())
                    {
                        MessageBox.Show("Already exist");
                        return;
                    }
                    
                }
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = label15.Text;
                dataGridView2.Rows[n].Cells[1].Value = label14.Text;
                dataGridView2.Rows[n].Cells[2].Value = label13.Text;
                dataGridView2.Rows[n].Cells[3].Value = label12.Text;
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string table = textBox1.Text;
            if (string.IsNullOrEmpty(table)|| string.IsNullOrEmpty(textBox2.Text)|| string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Enter Competition details");
            }
            else
            {

                try
                {
                    MySqlCommand Create_table = connection.CreateCommand();
                    Create_table.CommandText = @"CREATE TABLE `" + table + "` (ID INT NOT NULL, Q INT NOT NULL, NAME VARCHAR(35) NOT NULL , DOB VARCHAR(15) NOT NULL, CLUB VARCHAR(15) , V INT , PTS INT , B INT , TF INT , SWIM_TIME VARCHAR(35) , SWIM_PTS INT , RIDING INT , SUB_TOT INT , HCT VARCHAR(35) , LR_TIME VARCHAR(35) , LR_PTS INT , TOTAL INT , PRIMARY KEY (ID)) COLLATE='utf8_unicode_ci' ENGINE=InnoDB;";
                    Create_table.ExecuteNonQuery();
                    addAthlete(textBox1.Text);
                }
                catch { MessageBox.Show("Error!!!"); }
               
                MessageBox.Show("Competition created!!  " + table);
                string sql = "INSERT INTO sql2395628.Calender VALUES (@Cometition, @Date, @Location)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Cometition", MySqlDbType.VarChar).Value = table;
                cmd.Parameters.Add("@Date", MySqlDbType.VarChar).Value = textBox2.Text;
                cmd.Parameters.Add("@Location", MySqlDbType.VarChar).Value = textBox3.Text;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("connection fail");
                }
                connection.Close();
                Form1 competition = new Form1(table, connection);
                competition.Show();
                this.Hide();
            }

           
        }

        void addAthlete(string table)
        {
            string sql = "INSERT INTO sql2395628."+table+ " VALUES (@LocalID, @Q, @Name, @DateOfBirth, @Club, NULL, NULL, NULL, NULL,  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)";
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                if (row.IsNewRow) continue;
                cmd.Parameters.Add("@LocalID", MySqlDbType.VarChar).Value = row.Cells["LocalID"].Value;
                cmd.Parameters.Add("@Q", MySqlDbType.VarChar).Value = i;
                cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = row.Cells["athleteName"].Value;
                cmd.Parameters.Add("@DateOfBirth", MySqlDbType.VarChar).Value = row.Cells["DOB"].Value;
                cmd.Parameters.Add("@Club", MySqlDbType.VarChar).Value = row.Cells["Club"].Value;
                i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("connection fail");
                }
                
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = dataGridView2.Rows[e.RowIndex];
            label3.Text = dgvr.Cells[0].Value.ToString();
            label2.Text = dgvr.Cells[1].Value.ToString();
            label4.Text = dgvr.Cells[2].Value.ToString();
            label5.Text = dgvr.Cells[3].Value.ToString();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            string query = "SELECT `LocalID`, `NAME`, `DATE OF BIRTH`, `CLUB`, `UIPM ID` FROM sql2395628.Database  WHERE CONCAT (`NAME`, `LocalID`, `UIPM ID`) LIKE '%" + bunifuTextbox1.text + "%'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main main = new Main(connection);
            main.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
