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
    public partial class SalesEditForm : Form
    {
        string id;
        public SalesEditForm(string id_price, string kurs, string price, string date)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += SalesEditForm_KeyDown;

            KursiClass.GetKursiList();
            comboBox1.DataSource = KursiClass.dtKursi;
            comboBox1.DisplayMember = "название";
            id = id_price;
            comboBox1.Text = kurs;

            string[] parts = price.Split(',');
            textBox1.Text = parts[0];
            maskedTextBox1.Text = parts[1];

            dateTimePicker1.Text = date;
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
            if (Convert.ToInt32(textBox1.Text) == 0)
            {
                System.Windows.Forms.MessageBox.Show(
                "Ошибка при изменении прайса. \r\n\r\nВведите корректный прайс",
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
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            SalesClass.EditSale(id, kurs, price, date);
            this.Close();
        }

        private void SalesEditForm_Load(object sender, EventArgs e)
        {

        }

        private void SalesEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы изменить информацию продажу, нужно:

            1) В выпадающем списке выбрать курс 
            2) Указать цену продажи (рубли и копейки)
            3) Выбрать дату продажи
            4) Нажать на кнопку 'Сохранить'";

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
