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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=PC12;Initial Catalog=abilimpics;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT *FROM[Profile] WHERE UserID='"+Form1.userId+"'",connection);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                for (int i=1;i<dr.FieldCount -1; i++)
                {
                    this.label1.Text += dr.GetName(i) + ":" + dr.GetValue(i).ToString()+ "\n";
                }
            }
            dr.Close();

            command = new SqlCommand("SELECT * FROM[Life_status] WHERE UserID='" + Form1.userId+"'",connection);
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                for (int i=1;i<dr.FieldCount - 1; i++)
                {
                    this.label2.Text += dr.GetName(i) + ":" + dr.GetValue(i).ToString() + "\n";
                }
            }
        }
    }
}
