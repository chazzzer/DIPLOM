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

namespace DIPLOM_RAYKHERT.MyForm.Price
{
    public partial class PriceAddForm : Form
    {
        public PriceAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += PriceAddForm_KeyDown;

            KursiClass.GetKursiList();
            comboBox1.DataSource = KursiClass.dtKursi;
            comboBox1.DisplayMember = "название";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kopeek;
            if ((textBox1.Text == "") || (textBox1.Text == "0"))
            {
                System.Windows.Forms.MessageBox.Show(
                "Ошибка при установке прайса. \r\n\r\nВведите корректный прайс",
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
            PriceClass.AddPrice(kurs, price);
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) ||
                e.KeyChar == (char)Keys.Back);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PriceAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы установить новый прайс, нужно:

            1) В выпадающем списке выбрать курс, цену на который Вы устанавливаете
            2) Указать цену (рубли и копейки)
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
