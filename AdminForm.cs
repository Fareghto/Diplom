using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form3 : Form
    {  
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            toolStripButton2.PerformClick();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Text = "Добавление модели";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = rashodBindingSource;
            rashodTableAdapter.Fill(dataSet.rashod);
            toolStripButton4.Visible = false;
            toolStripButton6.Visible = false;
            toolStripButton3.Visible = true;
            toolStripButton7.Visible = true;
            toolStripButton8.Visible = true;
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Text = "Добавление материала";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = umBindingSource;
            umTableAdapter.Fill(dataSet.um);
            dataGridView1.Columns[0].HeaderText = "id";
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Ед. изм.";
            dataGridView1.Columns[3].HeaderText = "Цена за ед.";
            toolStripButton4.Visible = false;
            toolStripButton6.Visible = false;
            toolStripButton3.Visible = true;
            toolStripButton7.Visible = true;
            toolStripButton8.Visible = true;
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (this.Text == "Добавление материала" && textBox1.Visible == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Заполните поля");
                    textBox1.Focus();
                    return;
                }
                else
                {
                    string cs = ConfigurationManager.ConnectionStrings["Connector"].ConnectionString;
                    OdbcConnection con = new OdbcConnection(cs);
                    OdbcCommand com = con.CreateCommand();
                    com.Connection = con;
                    con.Open();
                    com.CommandText = "insert into um(naim1,ed1,cena1) values (?,?,?)";
                    com.Parameters.Add("?", OdbcType.VarChar).Value = textBox1.Text;
                    com.Parameters.Add("?", OdbcType.VarChar).Value = textBox2.Text;
                    com.Parameters.Add("?", OdbcType.VarChar).Value = textBox3.Text;
                    com.ExecuteNonQuery();
                    dataGridView1.DataSource = umBindingSource;
                    umTableAdapter.Fill(dataSet.um);
                }
            }
            if (this.Text == "Добавление материала" && textBox5.Visible == true)
            {
                if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                {
                    MessageBox.Show("Заполните поля");
                    textBox5.Focus();
                    return;
                }
                else
                {
                    string cs = ConfigurationManager.ConnectionStrings["Connector"].ConnectionString;
                    OdbcConnection con = new OdbcConnection(cs);
                    OdbcCommand com = con.CreateCommand();
                    com.Connection = con;
                    con.Open();
                    com.CommandText = "UPDATE `um` SET `naim1`='" + textBox5.Text + "',`ed1`='" + textBox6.Text + "',`cena1`='" + textBox7.Text + "' WHERE id_material= '" + textBox4.Text + "'";
                    com.Parameters.Add("?", OdbcType.VarChar).Value = textBox4.Text;
                    com.Parameters.Add("?", OdbcType.VarChar).Value = textBox5.Text;
                    com.Parameters.Add("?", OdbcType.VarChar).Value = textBox6.Text;
                    com.Parameters.Add("?", OdbcType.VarChar).Value = textBox7.Text;
                    MessageBox.Show("Изменено");
                    com.ExecuteNonQuery();
                    dataGridView1.DataSource = umBindingSource;
                    umTableAdapter.Fill(dataSet.um);
                }
            }
            if (this.Text == "Добавление модели" && textBox5.Visible == true)
            {
                if (textBox5.Text == "")
                {
                    MessageBox.Show("Введите значение");
                    return;
                }
                else
                {
                    string cs = ConfigurationManager.ConnectionStrings["Connector"].ConnectionString;
                    OdbcConnection con = new OdbcConnection(cs);
                    OdbcCommand com = con.CreateCommand();
                    con.Open();
                    com.Connection = con;
                    string col = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText.ToString();
                    string a = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Index.ToString();
                    int b = Convert.ToInt32(a) + 1;
                    com.CommandText = "UPDATE rashod SET `" + col + "` = '" + textBox5.Text + "' WHERE id_material ='" + textBox4.Text + "'";
                    com.ExecuteNonQuery();
                    MessageBox.Show("Изменено");
                    dataGridView1.DataSource = umBindingSource;
                    umTableAdapter.Fill(dataSet.um);
                }
            }
            if (this.Text == "Добавление модели" && textBox1.Visible == true)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите значение");
                    return;
                }
                else
                {
                    string cs = ConfigurationManager.ConnectionStrings["Connector"].ConnectionString;
                    OdbcConnection con = new OdbcConnection(cs);
                    OdbcCommand com = con.CreateCommand();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "ALTER TABLE `rashod` ADD `" + textBox1.Text + "` INT(11) NULL DEFAULT '0' ;";
                    com.ExecuteNonQuery();
                    com.CommandText = "insert into model(model) values (?)";
                    com.Parameters.Add("?", OdbcType.VarChar).Value = textBox1.Text;
                    com.ExecuteNonQuery();
                    MessageBox.Show("Добавлено");
                    dataGridView1.DataSource = umBindingSource;
                    umTableAdapter.Fill(dataSet.um);
                }
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.Text == "Добавление материала")
            {
                toolStripButton4.Visible = true;
                toolStripButton6.Visible = true;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
            }
            if (this.Text == "Добавление модели")
            {
                toolStripButton4.Visible = true;
                toolStripButton6.Visible = true;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                textBox1.Visible = true;
            }
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible == true)
            {
                toolStripButton4.Visible = false;
                toolStripButton6.Visible = false;
                toolStripButton3.Visible = true;
                toolStripButton8.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
            }
            if (textBox4.Visible == true)
            {
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                textBox7.Hide();
                toolStripButton4.Visible = false;
                toolStripButton6.Visible = false;
                toolStripButton3.Visible = true;
                toolStripButton8.Visible = true;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {          
            if (this.Text == "Добавление материала")
            {
                string a = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Index.ToString();// айди строки
                int b = Convert.ToInt32(a);
                textBox4.Text = dataGridView1.Rows[b].Cells[0].Value.ToString();
                textBox5.Text = dataGridView1.Rows[b].Cells[1].Value.ToString();
                textBox6.Text = dataGridView1.Rows[b].Cells[2].Value.ToString();
                textBox7.Text = dataGridView1.Rows[b].Cells[3].Value.ToString();
            }
            if (this.Text == "Добавление модели")
            {
                string a = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Index.ToString();// айди строки
                int b = Convert.ToInt32(a);
                textBox4.Text = dataGridView1.Rows[b].Cells[0].Value.ToString();
                textBox5.Text = dataGridView1.CurrentCell.Value.ToString();               
            }
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (this.Text == "Добавление материала")//comment
            {
                textBox4.Show();
                textBox5.Show();
                textBox6.Show();
                textBox7.Show();
                toolStripButton4.Visible = true;
                toolStripButton6.Visible = true;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
            }
            if (this.Text == "Добавление модели")
            {
                textBox4.Show();
                textBox5.Show();
                toolStripButton4.Visible = true;
                toolStripButton6.Visible = true;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
            }
        }
    }
}
