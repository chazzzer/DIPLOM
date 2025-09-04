using DIPLOM_RAYKHERT.MyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyForm.Price
{
    public partial class PriceEditForm : Form
    {
        string id;
        public PriceEditForm(string id_price, string kurs, string price, string date)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += PriceEditForm_KeyDown;

            KursiClass.GetKursiList();
            comboBox1.DataSource = KursiClass.dtKursi;
            comboBox1.DisplayMember = "название";
            id = id_price;
            comboBox1.Text = kurs;

            string[] parts = price.Split(',');
            textBox1.Text = parts[0];
            maskedTextBox1.Text= parts[1];

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
            string kopeek;
            if (Convert.ToInt32(textBox1.Text) == 0)
            {
                System.Windows.Forms.MessageBox.Show(
                "Ошибка при изменении прайса. \r\n\r\nВведите корректный прайс",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

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
            PriceClass.EditPrice(id, kurs, price, date);
            this.Close();
        }

        private void PriceEditForm_Load(object sender, EventArgs e)
        {

        }

        private void PriceEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы изменить прайс, нужно:

            1) В выпадающем списке выбрать курс, цену на который Вы устанавливаете
            2) Указать цену (рубли и копейки)
            3) Выбрать дату установки прайса
            4) Нажать на кнопку 'Добавить'";

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
