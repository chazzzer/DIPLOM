using DIPLOM_RAYKHERT.MyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyForm.Sales
{
    public partial class SalesAddForm : Form
    {
        public SalesAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += SalesAddForm_KeyDown;

            KursiClass.GetKursiList();
            comboBox1.DataSource = KursiClass.dtKursi;
            comboBox1.DisplayMember = "название";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) ||
                e.KeyChar == (char)Keys.Back);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox1.Text == "0"))
            {
                System.Windows.Forms.MessageBox.Show(
                "Ошибка при добавлении продажи. \r\n\r\nВведите корректную стоимость при продаже",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            string kopeek;
            if (maskedTextBox1.MaskFull)
            {
                kopeek = maskedTextBox1.Text;
            }
            else
            {
                kopeek = "00";
            }
            string rubli = textBox1.Text;
            string price = rubli + '.' + kopeek;

            string kurs = comboBox1.Text;
            SalesClass.AddSale(kurs, price);
            this.Close();
        }

        private void SalesAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы добавить продажу, нужно:

            1) В выпадающем списке выбрать курс 
            2) Указать цену продажи (рубли и копейки)
            3) Нажать на кнопку 'Добавить'";

            if (e.KeyCode == Keys.F1)
            {
                HelpForm hf = new HelpForm();
                hf.ShowDialog();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
