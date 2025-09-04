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

namespace DIPLOM_RAYKHERT.MyForm
{
    public partial class KursForm : Form
    {
        public KursForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += KursForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KursForm_Load(object sender, EventArgs e)
        {
            KursiClass.GetKursiListFormatted(flowLayoutPanel1);

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KursAddForm kaf = new KursAddForm();
            kaf.ShowDialog();

            KursiClass.GetKursiListFormatted(flowLayoutPanel1);
        }

        private void KursForm_Activated(object sender, EventArgs e)
        {
            KursiClass.GetKursiListFormatted(flowLayoutPanel1);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = System.Drawing.Color.Black;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.ForeColor = System.Drawing.Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = System.Drawing.Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = System.Drawing.Color.White;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) ||
             e.KeyChar == (char)Keys.Back ||
             e.KeyChar == (char)Keys.Space ||
             e.KeyChar == ':' || e.KeyChar == '-' || e.KeyChar == '#' || e.KeyChar == ',' || e.KeyChar == '&' ||
             char.IsDigit(e.KeyChar));

            string kurs_name = textBox2.Text;
            string hours_ot = textBox4.Text;
            string hours_do = textBox3.Text;
            string sort_mode = comboBox1.Text;

            if (hours_ot == "" || hours_do == "")
            {
                hours_ot = "0";
                hours_do = "1000";
            }

            KursiClass.GetKursiListFormattedSorted(flowLayoutPanel1, kurs_name, hours_ot, hours_do, sort_mode);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ОЧИСТИТЬ ПОЛЕ НАЗВАНИЯ КУРСА

            textBox2.Clear();

            string kurs_name = textBox2.Text;
            string hours_ot = textBox4.Text;
            string hours_do = textBox3.Text;
            string sort_mode = comboBox1.Text;

            if (hours_ot == "" || hours_do == "")
            {
                hours_ot = "0";
                hours_do = "1000";
            }

            KursiClass.GetKursiListFormattedSorted(flowLayoutPanel1, kurs_name, hours_ot, hours_do, sort_mode);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //КНОПКА ПРИМЕНИТЬ В ДИАПАЗОНЕ

            string kurs_name = textBox2.Text;
            string hours_ot = textBox4.Text;
            string hours_do = textBox3.Text;
            string sort_mode = comboBox1.Text;

            if (hours_ot == "" || hours_do == "")
            {
                hours_ot = "0";
                hours_do = "1000";
            }

            KursiClass.GetKursiListFormattedSorted(flowLayoutPanel1, kurs_name, hours_ot, hours_do, sort_mode);

            // Проверка состояния FlowLayoutPanel
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                // Вывод сообщения пользователю
                MessageBox.Show("Ничего не найдено по вашему запросу.", 
                    "Информация", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                textBox4.Clear();
                textBox3.Clear();

                kurs_name = textBox2.Text;
                hours_ot = textBox4.Text;
                hours_do = textBox3.Text;
                sort_mode = comboBox1.Text;

                if (hours_ot == "" || hours_do == "")
                {
                    hours_ot = "0";
                    hours_do = "1000";
                }

                KursiClass.GetKursiListFormattedSorted(flowLayoutPanel1, kurs_name, hours_ot, hours_do, sort_mode);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //КНОПКА СБРОСИТЬ В ДИАПАЗОНЕ

            textBox4.Clear();
            textBox3.Clear();

            string kurs_name = textBox2.Text;
            string hours_ot = textBox4.Text;
            string hours_do = textBox3.Text;
            string sort_mode = comboBox1.Text;

            if (hours_ot == "" || hours_do == "")
            {
                hours_ot = "0";
                hours_do = "1000";
            }

            KursiClass.GetKursiListFormattedSorted(flowLayoutPanel1, kurs_name, hours_ot, hours_do, sort_mode);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kurs_name = textBox2.Text;
            string hours_ot = textBox4.Text;
            string hours_do = textBox3.Text;
            string sort_mode = comboBox1.Text;

            if (hours_ot == "" || hours_do == "")
            {
                hours_ot = "0";
                hours_do = "1000";
            }

            KursiClass.GetKursiListFormattedSorted(flowLayoutPanel1, kurs_name, hours_ot, hours_do, sort_mode);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void KursForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для получения списка курсов по цене, необходимо:
            1) Выбрать порядок в соответствующем выпадающем списке

            Для получения списка курсов, чья длительность попадает в период, нужно:
            1) Указать начальное количество часов
            2) Указать конечное количество часов
            3) Нажать на кнопку 'Применить'
            4) Для получения общего списка курсов, нажмите 'Сбросить'

            Для получения списка курсов по их наименованию, требуется:
            1) Ввести в поле для ввода название курса
            2) Для получения общего списка курсов, нажмите 'Очистить поле'";

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
