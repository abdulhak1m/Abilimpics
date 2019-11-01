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
    public partial class Form2 : Form
    {
        public void Proverka()
        {
            if (textBox2.Text==""
                |textBox3.Text==""
                |textBox4.Text==""
                |textBox5.Text==""
                |textBox6.Text==""
                |comboBox2.Text==""
                |textBox10.Text==""|
                maskedTextBox1.Text.Length != 6|
                textBox11.Text==""|
                maskedTextBox2.Text.Length !=16|
                maskedTextBox3.Text.Length !=12|
                maskedTextBox4.Text.Length !=10|
                maskedTextBox5.Text.Length != 10|
                maskedTextBox6.Text.Length != 10)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                Connecting();
                Hide();
                Form1 frm = new Form1();
                frm.Show();
                MessageBox.Show("Вы успешно авторизованы");
            }
        }
        public async void Connecting()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=PC12;Initial Catalog=abilimpics;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO[User](ID,Тип_аккаунта,Логин,Пароль)VALUES(@ID,@Тип_аккаунта,@Логин,@Пароль)", connection);
            command.Parameters.AddWithValue("ID", textBox1.Text);
            command.Parameters.AddWithValue("Тип_аккаунта", "User");
            command.Parameters.AddWithValue("Логин", textBox2.Text);
            command.Parameters.AddWithValue("Пароль", textBox3.Text);
            await command.ExecuteNonQueryAsync();
            SqlCommand command1 = new SqlCommand("INSERT INTO [Profile](UserID,Фамилия,Имя,Отчество,Место_работы,Место_учебы,Должность,Регион,Город,Почтовый_индекс,Адрес,Контактный_телефон,Адрес_электронной_почты)VALUES(@UserID,@Фамилия,@Имя,@Отчество,@Место_работы,@Место_учебы,@Должность,@Регион,@Город,@Почтовый_индекс,@Адрес,@Контактный_телефон,@Адрес_электронной_почты)", connection);
            command1.Parameters.AddWithValue("UserID", textBox1.Text);
            command1.Parameters.AddWithValue("Фамилия", textBox4.Text);
            command1.Parameters.AddWithValue("Имя", textBox5.Text);
            command1.Parameters.AddWithValue("Отчество", textBox6.Text);
            command1.Parameters.AddWithValue("Место_работы", textBox7.Text);
            command1.Parameters.AddWithValue("Место_учебы", textBox8.Text);
            command1.Parameters.AddWithValue("Должность", textBox9.Text);
            command1.Parameters.AddWithValue("Регион", comboBox1.Text);
            command1.Parameters.AddWithValue("Город", textBox10.Text);
            command1.Parameters.AddWithValue("Почтовый_индекс", maskedTextBox1.Text);
            command1.Parameters.AddWithValue("Адрес", textBox11.Text);
            command1.Parameters.AddWithValue("Контактный_телефон", maskedTextBox2.Text);
            command1.Parameters.AddWithValue("Адрес_электронной_почты", maskedTextBox3.Text);
           await command1.ExecuteNonQueryAsync();
            SqlCommand command2 = new SqlCommand("INSERT INTO [Life_status](UserID,Компетенция,Статус_участия,Дата_поступления_заявки,Вид_нозологии,Дата_приезда,Дата_отъезда,Потребность_в_гостинице,Потребность_в_транспорте)VALUES(@UserID,@Компетенция,@Статус_участия,@Дата_поступления_заявки,@Вид_нозологии,@Дата_приезда,@Дата_отъезда,@Потребность_в_гостинице,@Потребность_в_транспорте)", connection);
            command2.Parameters.AddWithValue("UserID",textBox1.Text);
            command2.Parameters.AddWithValue("Компетенция", comboBox3.Text);
            command2.Parameters.AddWithValue("Статус_участия", comboBox4.Text);
            command2.Parameters.AddWithValue("@Дата_поступления_заявки", maskedTextBox4.Text);
            command2.Parameters.AddWithValue("Вид_нозологии", comboBox5.Text);
            command2.Parameters.AddWithValue("Дата_приезда", maskedTextBox5.Text);
            command2.Parameters.AddWithValue("Дата_отъезда", maskedTextBox6.Text);
            command2.Parameters.AddWithValue("Потребность_в_гостинице", comboBox6.Text);
            command2.Parameters.AddWithValue("Потребность_в_транспорте", comboBox7.Text);
            await command2.ExecuteNonQueryAsync();
        }
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private  void Button1_Click(object sender, EventArgs e)
        {
            Proverka();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            textBox1.Text = random.Next(1,9999999).ToString();
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >'А' && e.KeyChar < 'я')
            {

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Ввод только русских букв");
            }
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 'А' && e.KeyChar < 'я')
            {

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Ввод только русских букв");
            }
        }

        private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 'А' && e.KeyChar < 'я')
            {

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Ввод только русских букв");
            }
        }

        private void MaskedTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 'A' && e.KeyChar < 'z')
            {

            }
            else
            {
                e.Handled = true;
                MessageBox.Show(@"Ввод только английских букв.заполните это поле полностью") ;
                
            }
        }
    }
}
