using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abilimpics
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void ProfileBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.profileBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.abilimpicsDataSet);
            profileBindingNavigator.Enabled = false;
            profileDataGridView.Enabled = false;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "abilimpicsDataSet.Profile". При необходимости она может быть перемещена или удалена.
            this.profileTableAdapter.Fill(this.abilimpicsDataSet.Profile);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            profileDataGridView.Enabled = true;
            profileBindingNavigator.Enabled = true;
            MessageBox.Show("Данные успешно сохранены");
        }
    }
}
