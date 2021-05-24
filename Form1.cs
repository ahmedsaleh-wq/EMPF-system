using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using MySql.Data.MySqlClient;

namespace EMPF
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        public string tableName;
        decimal swimmingM, swimmingS, swimmingMi, swimmingPts = 0;
        int fencingPTS, fencingTF = 0, athletes, touch, ridingTP, ridingM, ridingS, down, refusal, ridingPTS = 0, LRM, LRS, LRPTS ; 
        string  LRT;

        public Form1(string tableName, MySqlConnection connection)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.connection = connection;
            showGrid1();
            showGrid2();
            showGrid3();
            showGrid4();
            showGrid5();
            athletes = dataGridView2.Rows.Count;
            victoryPoint();
            numericUpDown5.Maximum = dataGridView2.Rows.Count - 1;
            numericUpDown4.Maximum = dataGridView2.Rows.Count - 1;          
            R_PTS();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        void showGrid1() {

              MySqlDataAdapter adapter1 = new MySqlDataAdapter("SELECT `ID`,`Q`, `NAME`, `DOB`, `CLUB`, `SWIM_TIME`, `SWIM_PTS` FROM sql2395628." + tableName, connection);
              DataSet ds1 = new DataSet();
              adapter1.Fill(ds1, tableName);
              dataGridView1.DataSource = ds1.Tables[tableName];
        }
        void showGrid2()
        {
            MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT `ID`,`Q`, `NAME`, `DOB`, `CLUB`, `V`, `PTS`, `B`, `TF` FROM sql2395628." + tableName, connection);
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2, tableName);
            dataGridView2.DataSource = ds2.Tables[tableName];
        }

        void showGrid3()
        {
            MySqlDataAdapter adapter3 = new MySqlDataAdapter("SELECT `ID`,`Q`, `NAME`, `DOB`, `CLUB`, `RIDING`,`SUB_TOT` FROM sql2395628." + tableName, connection);
            DataSet ds3 = new DataSet();
            adapter3.Fill(ds3, tableName);
            dataGridView3.DataSource = ds3.Tables[tableName];
        }
        void showGrid4()
        {
            MySqlDataAdapter adapter4 = new MySqlDataAdapter("SELECT `ID`,`Q`, `NAME`, `DOB`, `CLUB`, `HCT`, `LR_TIME`, `LR_PTS` FROM sql2395628." + tableName, connection);
            DataSet ds4 = new DataSet();
            adapter4.Fill(ds4, tableName);
            dataGridView4.DataSource = ds4.Tables[tableName];
        }

        void showGrid5()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM sql2395628." + tableName, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, tableName);
            dataGridView5.DataSource = ds.Tables[tableName];
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {

        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            swimmingM = (4 - numericUpDown1.Value)*120;
            swimmingPts = swimmingMi + swimmingM + swimmingS;
            textBox8.Text = swimmingPts.ToString() ;
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            swimmingS = (35 - numericUpDown2.Value) * 2;
            swimmingPts = swimmingMi + swimmingM + swimmingS;
            textBox8.Text = swimmingPts.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            
            if (numericUpDown3.Value >= 50)
            {
                swimmingMi = 1;
            }
            else
            {
                swimmingMi = 0;
            }
            swimmingPts = swimmingMi + swimmingM + swimmingS;
            textBox8.Text = swimmingPts.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd1;
            MySqlCommand cmd2;
            MySqlDataReader reader1;

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("select athlete!!");
            }
            else {

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(numericUpDown1.Value + ":" + numericUpDown2.Value + ":" + numericUpDown3.Value);
                string Query = "update sql2395628." + tableName + " set SWIM_TIME='" + sb + "' where ID='" + int.Parse(textBox1.Text) + "';";
                string Query2 = "update sql2395628." + tableName + " set SWIM_PTS='" + Convert.ToInt32(swimmingPts) + "' where ID='" + int.Parse(textBox1.Text) + "';";
                cmd1 = new MySqlCommand(Query, connection);
                cmd2 = new MySqlCommand(Query2, connection);
                reader1 = cmd1.ExecuteReader();
                
                    while (reader1.Read())
                    {
                    }
                    reader1.Close();
                    reader1 = cmd2.ExecuteReader();
                    while (reader1.Read())
                    {
                    }
                    reader1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }     
            }
            showGrid1();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = dgvr.Cells[0].Value.ToString();
            textBox2.Text = dgvr.Cells[2].Value.ToString();
            textBox3.Text = dgvr.Cells[3].Value.ToString();
            textBox4.Text = dgvr.Cells[4].Value.ToString();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            showGrid5();

        }

        void victoryPoint() {

            if (athletes > 47)
                touch = 4;
            else if (athletes > 39)
                touch = 5;
            else if (athletes > 33)
                touch = 6;
            else if (athletes > 29)
                touch = 7;
            else if (athletes > 22)
                touch = 8;
            else
                touch = 9;
        }

        private void numericUpDown13_Click(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            fencingPTS = Convert.ToInt32(numericUpDown5.Value) * touch;
            textBox13.Text = fencingPTS.ToString();
            fencingTF = Convert.ToInt32(numericUpDown4.Value) + fencingPTS;
            textBox15.Text = fencingTF.ToString();
        }

       

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            R_PTS();
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            R_PTS();
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            R_PTS();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd1;
            MySqlCommand cmd2;
            MySqlDataReader reader1;

            if (string.IsNullOrEmpty(textBox35.Text) || string.IsNullOrEmpty(textBox34.Text) || string.IsNullOrEmpty(textBox33.Text) || string.IsNullOrEmpty(textBox32.Text))
            {
                MessageBox.Show("select athlete!!");
            }
            else
            {

                try
                {

                    string Query = "update sql2395628." + tableName + " set LR_TIME ='" + LRT + "' where ID='" + int.Parse(textBox35.Text) + "';";
                    string Query2 = "update sql2395628." + tableName + " set LR_PTS ='" + LRPTS + "' where ID='" + int.Parse(textBox35.Text) + "';";
                    cmd1 = new MySqlCommand(Query, connection);
                    cmd2 = new MySqlCommand(Query2, connection);
                    reader1 = cmd1.ExecuteReader();

                    while (reader1.Read())
                    {
                    }
                    reader1.Close();
                    reader1 = cmd2.ExecuteReader();
                    while (reader1.Read())
                    {
                    }
                    reader1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            showGrid4();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd1;
            MySqlCommand cmd2;
            MySqlDataReader reader1;
            int sub_total = Convert.ToInt32(swimmingPts + fencingPTS + ridingPTS);
            if (string.IsNullOrEmpty(textBox24.Text) || string.IsNullOrEmpty(textBox23.Text) || string.IsNullOrEmpty(textBox22.Text) || string.IsNullOrEmpty(textBox21.Text))
            {
                MessageBox.Show("select athlete!!");
            }
            else
            {

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(numericUpDown1.Value + ":" + numericUpDown2.Value + ":" + numericUpDown3.Value);
                    string Query = "update sql2395628." + tableName + " set RIDING ='" + ridingPTS +  "' where ID='" + int.Parse(textBox24.Text) + "';";
                    string Query2 = "update sql2395628." + tableName + " set SUB_TOT ='" + sub_total + "' where ID='" + int.Parse(textBox24.Text) + "';";
                    cmd1 = new MySqlCommand(Query, connection);
                    cmd2 = new MySqlCommand(Query2, connection);
                    reader1 = cmd1.ExecuteReader();

                    while (reader1.Read())
                    {
                    }
                    reader1.Close();
                    reader1 = cmd2.ExecuteReader();
                    while (reader1.Read())
                    {
                    }
                    reader1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            showGrid3();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Boolean nullity = false;
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                if (string.IsNullOrEmpty(row.Cells[12].Value.ToString())|| string.IsNullOrEmpty(row.Cells[15].Value.ToString()))
                {
                    MessageBox.Show("Enter all records first!!!");
                    nullity = true;

                }
            }

            if (!nullity) {
                getHCT();
                getTotal();
            }
        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            LRM = Convert.ToInt32(numericUpDown14.Value);
            LRS = Convert.ToInt32(numericUpDown13.Value);
            int LRMIL = Convert.ToInt32(numericUpDown12.Value);
            LRT = LRM.ToString() + ":" + LRS.ToString() + ":" + LRMIL.ToString();
            LRPTS = (21 - LRM) * 60 + (40 - LRS);
            textBox17.Text = LRPTS.ToString();


        }

        private void button12_Click(object sender, EventArgs e)
        {
            Main main = new Main(connection);
            main.Show();
            this.Hide();
        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            LRM = Convert.ToInt32(numericUpDown14.Value);
            LRS = Convert.ToInt32(numericUpDown13.Value);
            int LRMIL = Convert.ToInt32(numericUpDown12.Value);
            LRT = LRM.ToString() + ":" + LRS.ToString() + ":" + LRMIL.ToString();
            LRPTS = (21 - LRM) * 60 + (40 - LRS);
            textBox17.Text = LRPTS.ToString();

        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            R_PTS();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            fencingPTS = Convert.ToInt32(numericUpDown5.Value) * touch;
            textBox13.Text = fencingPTS.ToString();
            fencingTF = Convert.ToInt32(numericUpDown4.Value) + fencingPTS;
            textBox15.Text = fencingTF.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd1;
            MySqlDataReader reader1;

            if (string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(textBox11.Text) || string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("select athlete!!");
            }
            else
            {

                try
                {

                    string Query = "update sql2395628." + tableName + " set V ='"+ Convert.ToInt32(numericUpDown5.Value) + "', PTS ='"+fencingPTS+"', B ='"+ Convert.ToInt32(numericUpDown4.Value) + "', TF ='"+fencingTF+"' where ID='" + int.Parse(textBox12.Text) + "';";

                    cmd1 = new MySqlCommand(Query, connection);

                    reader1 = cmd1.ExecuteReader();

                    while (reader1.Read())
                    {
                    }
                    reader1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            showGrid2();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = dataGridView2.Rows[e.RowIndex];
            textBox12.Text = dgvr.Cells[0].Value.ToString();
            textBox11.Text = dgvr.Cells[2].Value.ToString();
            textBox10.Text = dgvr.Cells[3].Value.ToString();
            textBox9.Text = dgvr.Cells[4].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = dataGridView3.Rows[e.RowIndex];
            textBox24.Text = dgvr.Cells[0].Value.ToString();
            textBox23.Text = dgvr.Cells[2].Value.ToString();
            textBox22.Text = dgvr.Cells[3].Value.ToString();
            textBox21.Text = dgvr.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = tableName;
            printer.SubTitle = "SWIMMING";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "EMPF";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = tableName;
            printer.SubTitle = "FENCING";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "EMPF";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = tableName;
            printer.SubTitle = "RIDDING";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "EMPF";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = tableName;
            printer.SubTitle = "LASER-RUN";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "EMPF";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView4);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = tableName;
            printer.SubTitle = "FINAL";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "EMPF";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView5);
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = dataGridView4.Rows[e.RowIndex];
            textBox35.Text = dgvr.Cells[0].Value.ToString();
            textBox34.Text = dgvr.Cells[2].Value.ToString();
            textBox33.Text = dgvr.Cells[3].Value.ToString();
            textBox32.Text = dgvr.Cells[4].Value.ToString();

        }

        void R_PTS() {
            ridingM = Convert.ToInt32(numericUpDown9.Value);
            ridingS = Convert.ToInt32(numericUpDown8.Value);
            ridingTP = (Convert.ToInt32(numericUpDown6.Value) * 60 + Convert.ToInt32(numericUpDown7.Value)) - (ridingM * 60 + ridingS);
            down = (0-Convert.ToInt32(numericUpDown10.Value) * 7);
            refusal = (0-Convert.ToInt32(numericUpDown11.Value) * 10);
            if (refusal >= 40)
            {
                ridingPTS = 0;
                textBox18.Text = "Elimination";
            }
            else
            {
                if (ridingTP <= 0)
                {
                    ridingPTS = 300 + down + refusal + ridingTP;
                }
                else {
                    ridingPTS = 300 + down + refusal;
                }
                textBox18.Text = ridingPTS.ToString();
            }
        }
        void getHCT() {
            MySqlCommand cmd1;
            MySqlDataReader reader1;
            int value=0;

            foreach (DataGridViewRow row in dataGridView3.Rows) {
                if (string.IsNullOrEmpty(row.Cells[6].Value.ToString()))
                {

                }
                else {
                    if (Convert.ToInt32(row.Cells[6].Value) > value)
                    {
                        value = Convert.ToInt32(row.Cells[6].Value);
                    }
                }
                
                
            }
            int i = 0;
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    int temp = value - Convert.ToInt32(dataGridView3.Rows[i].Cells[6].Value);
                    if (temp >= 120)
                    {
                        sb.Append("0" + 2 + ":00:00");

                    }
                    else if (temp >= 60)
                    {

                        sb.Append("0" + 1 + ":" + (temp - 60) + ":00");
                    }
                    else
                    {
                        sb.Append("00:" + temp + ":00");
                    }

                    string Query = "update sql2395628." + tableName + " set HCT ='" + sb + "' where ID='" + dataGridView4.Rows[i].Cells[0].Value + "';";

                    cmd1 = new MySqlCommand(Query, connection);

                    reader1 = cmd1.ExecuteReader();

                    while (reader1.Read())
                    {
                    }
                    reader1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                i++;
            }
            showGrid4();
            showGrid5();
        }

        void getTotal(){
            MySqlCommand cmd1;
            MySqlDataReader reader1;
            int i = 0;
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                try
                {
                    
                    int total = Convert.ToInt32(dataGridView5.Rows[i].Cells[12].Value) + Convert.ToInt32(dataGridView5.Rows[i].Cells[15].Value);

                    string Query = "update sql2395628." + tableName + " set TOTAL ='" + total + "' where ID='" + dataGridView5.Rows[i].Cells[0].Value + "';";

                    cmd1 = new MySqlCommand(Query, connection);

                    reader1 = cmd1.ExecuteReader();

                    while (reader1.Read())
                    {
                    }
                    reader1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                i++;
            }
            showGrid5();
        }
    }
}
