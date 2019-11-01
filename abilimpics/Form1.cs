using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abilimpics
{
    public partial class Form1 : Form
    {
        public static int userId;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=PC12;Initial Catalog=abilimpics;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT *FROM[User] WHERE Логин='" + textBox1.Text + "'and Пароль='" + textBox2.Text + "'", connection);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                userId = dr.GetInt32(0);
                if (dr.GetValue(1).ToString() == "Admin")
                {
                    Hide();
                    Form3 frm = new Form3();
                    frm.Show();
                    MessageBox.Show("Вы авторизованы как администратор");
                }
                else
                {
                    Hide();
                    Form4 frm = new Form4();
                    frm.Show();
                    MessageBox.Show("Вы авторизованы как пользователь");
                }

            }
            else
            {
                if (textBox1.Text == "" | textBox2.Text == "")
                {
                    MessageBox.Show("Заполните все поля");
                }
                else
                {
                    MessageBox.Show("Не правильный логин или пароль");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 frm = new Form2();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
