using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.Reflection;
namespace WindowsFormsApplication3
{
        public partial class Form1 : Form
    {     
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Connector"].ConnectionString;
                OdbcConnection con = new OdbcConnection(cs);
                OdbcCommand com = con.CreateCommand();
                com.CommandText = ("Select * From auth WHERE login=\"" + textBox1.Text + "\"" + "AND pass=\"" + textBox2.Text + "\""); 
                try {con.Open();}
                catch {
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    button2.Visible = true;
                    button1.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    label1.Text = "Не удалось подключиться к базе данных.";
                    return;
                }
                
                //запрос в базу данных
                if (com.ExecuteScalar() != null)
                //проверка запроса
                {
                    if (textBox1.Text == "admin") {
                        Form3 frm3 = new Form3();
                        frm3.Show();
                        this.Hide();
                    }
                    else { 
                    Form2 frm2 = new Form2();
                    frm2.Show();
                    this.Hide();
                    }         
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
            finally
            {
                string cs = ConfigurationManager.ConnectionStrings["Connector"].ConnectionString;
                OdbcConnection con = new OdbcConnection(cs);
                con.Close();
            }
        }// условия проверки логина/пароля
        private void button2_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["Connector"].ConnectionString = "Driver={MySQL ODBC 5.3 Unicode Driver};server=" + textBox3.Text + ";uid=" + textBox4.Text + ";database=prop;port=3306;column_size_s32=1;pwd=" + textBox5.Text + "";
            config.Save();
            //изменение подключения к базе данных с сохранением файла конфигурации
            ConfigurationManager.RefreshSection("connectionStrings");
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Connector"].ConnectionString;
                OdbcConnection con = new OdbcConnection(cs);
                con.Open();
                label1.Text = "База данных успешно подключена.";
                button1.Visible = true;
                button2.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
            }
            catch
            {
                label1.Text = "Не удалось подключиться к базе данных.";
                return;
                //возврат при неуспешном подключении
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            //выход из программы
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {   
                string cs = ConfigurationManager.ConnectionStrings["Connector"].ConnectionString;
                OdbcConnection con = new OdbcConnection(cs);
                con.Open();
                //попытка подключения к бд
                label1.Text = "База данных успешно подключена.";
            }
            catch
            {
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                button2.Visible = true;
                button1.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                label1.Text = "Не удалось подключиться к базе данных.";
                return;
                //возврат при неуспешном подключении
            }
        }
        private void label1_TextChanged(object sender, EventArgs e)
        {
            if (label1.Text == "База данных успешно подключена.") {
                button1.Enabled = true;
            }
            else
                button1.Enabled = false;
        }
    }
}
