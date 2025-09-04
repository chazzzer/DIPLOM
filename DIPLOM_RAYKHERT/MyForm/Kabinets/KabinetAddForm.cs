using DIPLOM_RAYKHERT.MyClass;
using DIPLOM_RAYKHERT.MyClass.SpravochnikClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyForm.Kabinets
{
    public partial class KabinetAddForm : Form
    {
        public KabinetAddForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += KabinetAddForm_KeyDown;
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

        private void KabinetAddForm_Load(object sender, EventArgs e)
        {
            KabinetTypeClass.GetKabinetTypeList();
            comboBox1.DataSource = KabinetTypeClass.dtKabinetType;
            comboBox1.DisplayMember = "тип_кабинета";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Ошибка при редактировании кабинета. \r\n\r\nЗаполните поле!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            int nomer = Convert.ToInt32(textBox1.Text);
            string type = comboBox1.Text;

            if (nomer == 0)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Ошибка при добавлении кабинета. \r\n\r\nУкажите корректный номер кабинета",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            KabinetClass.AddKabinet(nomer, type);
            this.Close();
        }

        private void KabinetAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы добавить новый кабинет, нужно:

            1) Указать номер кабинета в поле для ввода
            2) В соответствующем выпадающем списке выбрать тип кабинета
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
