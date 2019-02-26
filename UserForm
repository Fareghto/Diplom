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
    public partial class Form2 : Form
    {          
        public Form2()
        {
            InitializeComponent();
        }
        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {
            ////////////////////////////////////////////
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();     
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (this.Text == "Учёт клиентов" || this.Text == "Учёт затрат")
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Заполните поля");
                    textBox1.Focus();
                    return;
                }
                else
                {
                    {
                        string cs = ConfigurationManager.ConnectionStrings["Connector"].ConnectionString;
                        OdbcConnection con = new OdbcConnection(cs);
                        OdbcCommand com = con.CreateCommand();
                        con.Open();
                        com.Connection = con;                     
                        com.CommandText = "insert into `uk`(id_client,F,I,O,bdate,pol,contact) values (?,?,?,?,?,?,?)";
                        //запрос в бд
                        try
                        {
                            string id = dataGridView1["id_client", dataGridView1.Rows.Count - 1].Value.ToString();
                            int x = Convert.ToInt32(id);
                            int g = x + 1;
                            com.Parameters.Add("?", OdbcType.Int).Value = g.ToString();
                        }
                        catch
                        {
                            int g = 1;
                            com.Parameters.Add("?", OdbcType.Int).Value = g.ToString();
                        }
                        com.Parameters.Add("?", OdbcType.VarChar).Value = textBox1.Text;
                        com.Parameters.Add("?", OdbcType.VarChar).Value = textBox2.Text;
                        com.Parameters.Add("?", OdbcType.VarChar).Value = textBox3.Text;
                        com.Parameters.Add("?", OdbcType.VarChar).Value = textBox4.Text;
                        if (radioButton1.Checked ==true)
                        { com.Parameters.Add("?", OdbcType.VarChar).Value = radioButton1.Text; };
                        if (radioButton2.Checked  == true)
                        { com.Parameters.Add("?", OdbcType.VarChar).Value = radioButton2.Text; };
                        com.Parameters.Add("?", OdbcType.VarChar).Value = textBox5.Text;
                        com.ExecuteNonQuery();
                        //объявление переменных и выполнение запроса
                    }
                    {
                        DateTime localDate = DateTime.Now;
                        string cs = ConfigurationManager.ConnectionStrings["Connector"].ConnectionString;
                        OdbcConnection con = new OdbcConnection(cs); 
                        OdbcCommand com = con.CreateCommand();
                        con.Open();
                        com.Connection = con;
                        com.CommandText = " SELECT sum(rashod." + comboBox2.Text + " * um.cena1) FROM rashod, um WHERE rashod.id_material = um.id_material";
                        object o = com.ExecuteScalar();
                        com.CommandText = "insert into uz(id_client,model,s,cena,prim,time) values (?,?,?,?,?,?)";
                          try
                          {
                              string id = dataGridView1["id_client", dataGridView1.Rows.Count - 1].Value.ToString();
                              int x = Convert.ToInt32(id);
                              int g = x + 1;
                              com.Parameters.Add("?", OdbcType.Int).Value = g.ToString();
                          }
                          catch
                          {
                              int g = 1;
                              com.Parameters.Add("?", OdbcType.Int).Value = g.ToString();
                          }                                       
                        com.Parameters.Add("?", OdbcType.VarChar).Value = comboBox2.Text;
                        com.Parameters.Add("?", OdbcType.VarChar).Value = comboBox1.Text;                                          
                        com.Parameters.Add("?", OdbcType.VarChar).Value = o.ToString();                        
                        com.Parameters.Add("?", OdbcType.VarChar).Value = textBox6.Text;
                        com.Parameters.Add("?", OdbcType.VarChar).Value = localDate;
                        com.ExecuteNonQuery();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox1.Hide();
                        textBox2.Hide();
                        textBox3.Hide();
                        textBox4.Hide();
                        textBox5.Hide();
                        textBox6.Hide();
                        label1.Visible = false;
                        label2.Visible = false;
                        label3.Visible = false;
                        label4.Visible = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label8.Visible = false;
                        radioButton1.Visible = false;
                        radioButton2.Visible = false;
                        comboBox1.Visible = false;
                        comboBox2.Visible = false;
                        toolStripButton8.Visible = false;
                        toolStripButton5.Visible = false;
                        toolStripButton7.Visible = true;
                        if (this.Text == "Учёт клиентов")
                        {
                            dataGridView1.DataSource = ukBindingSource;
                            ukTableAdapter.Fill(dataSet.uk);
                        }
                        if (this.Text == "Учёт затрат")
                        {
                            dataGridView1.DataSource = uzBindingSource;
                            uzTableAdapter.Fill(dataSet.uz);
                        }
                        MessageBox.Show("Клиент добавлен");
                    }
                }
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Text = "Учёт материалов";
            dataGridView1.DataSource = umBindingSource;
            umTableAdapter.Fill(dataSet.um);
            dataGridView1.Columns[0].HeaderText = "id";
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Ед. изм.";
            dataGridView1.Columns[3].HeaderText = "Цена за ед.";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            toolStripButton8.Visible = false;
            toolStripButton5.Visible = false;  
            toolStripButton7.Visible = false;
            toolStripButton9.Visible = false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.model". При необходимости она может быть перемещена или удалена.
            this.modelTableAdapter.Fill(this.dataSet.model);
            toolStripButton2.PerformClick();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
           
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (this.Text == "Учёт клиентов" || this.Text == "Учёт затрат")
            {
                textBox1.Show();
                textBox2.Show();
                textBox3.Show();
                textBox4.Show();
                textBox5.Show();
                textBox6.Show();
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                toolStripButton8.Visible = true;
                toolStripButton5.Visible = true;
                toolStripButton7.Visible = false;                     
            }
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            toolStripButton8.Visible = false;
            toolStripButton5.Visible = false;
            toolStripButton7.Visible = true;
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Text = "Учёт затрат";
            dataGridView1.DataSource = uzBindingSource;
            uzTableAdapter.Fill(dataSet.uz);
            dataGridView1.Columns[0].HeaderText = "id";
            dataGridView1.Columns[1].HeaderText = "Модель";
            dataGridView1.Columns[2].HeaderText = "Сезон";
            dataGridView1.Columns[3].HeaderText = "Цена";
            dataGridView1.Columns[4].HeaderText = "Примечание";
            dataGridView1.Columns[5].HeaderText = "Время заказа";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            toolStripButton8.Visible = false;
            toolStripButton9.Visible = true;
            toolStripButton5.Visible = false;
            toolStripButton7.Visible = true;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Text = "Учёт клиентов";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = ukBindingSource;
            ukTableAdapter.Fill(dataSet.uk);
            dataGridView1.Columns[0].HeaderText = "id";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Дата рождения";
            dataGridView1.Columns[5].HeaderText = "Пол";
            dataGridView1.Columns[6].HeaderText = "Контактные данные";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            toolStripButton8.Visible = false;
            toolStripButton5.Visible = false;
            toolStripButton7.Visible = true;
            toolStripButton9.Visible = true;
        }
        private void toolStripButton9_Click(object sender, EventArgs e)
        {           
            if (this.Text == "Учёт клиентов")
            {
                try
                {
                    dataGridView1.CurrentCell.Value.ToString();
                }    
                catch { return; }
                    string s = dataGridView1.CurrentCell.Value.ToString();
                    string cs = ConfigurationManager.ConnectionStrings["Connector"].ConnectionString;
                    OdbcConnection con = new OdbcConnection(cs);
                    OdbcCommand com = con.CreateCommand();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "DELETE FROM uk WHERE uk.id_client = " + s + "";
                    com.ExecuteNonQuery();
                    com.CommandText = "DELETE FROM uz WHERE uz.id_client = " + s + "";
                    com.ExecuteNonQuery();
                    dataGridView1.DataSource = ukBindingSource;
                    ukTableAdapter.Fill(dataSet.uk);                      
            }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.Text == "Учёт затрат")
            {
                DataTable mat = dataSet.Tables[1];
                DataView dv = new DataView(mat);
                dv.RowFilter = "id client LIKE '%" + toolStripTextBox1 + "%'";
                dataGridView1.DataSource = dv;
                if (toolStripTextBox1.Text == "")
                {
                    dataGridView1.DataSource = uzBindingSource;
                    uzTableAdapter.Fill(dataSet.uz);
                }
            }
            if (this.Text == "Учёт клиентов")
            {
                DataTable mat = dataSet.Tables[0];
                DataView dv = new DataView(mat);
                dv.RowFilter = "F LIKE '%" + toolStripTextBox1 + "%'";
                dataGridView1.DataSource = dv;
                dataGridView1.Refresh();
                if (toolStripTextBox1.Text == "")
                {
                    dataGridView1.DataSource = ukBindingSource;
                    ukTableAdapter.Fill(dataSet.uk);
                }
            }
            if (this.Text == "Учёт материалов")
            {
                DataTable mat = dataSet.Tables[2];
                DataView dv = new DataView(mat);
                dv.RowFilter = "naim1 LIKE '%" + toolStripTextBox1 + "%'";
                dataGridView1.DataSource = dv;
                if (toolStripTextBox1.Text == "")
                {
                    dataGridView1.DataSource = umBindingSource;
                    umTableAdapter.Fill(dataSet.um);
                }
            }
        }    
    }
}
