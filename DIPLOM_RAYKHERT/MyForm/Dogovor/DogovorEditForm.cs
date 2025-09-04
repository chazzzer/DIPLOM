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

namespace DIPLOM_RAYKHERT.MyForm.Dogovor
{
    public partial class DogovorEditForm : Form
    {
        string id;
        public DogovorEditForm(string id_dogovora, string fio, string data_zakl, string itogo)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += DogovorEditForm_KeyDown;
            id = id_dogovora;

            UserClass.GetUsersListFio();
            comboBox1.DataSource = UserClass.dtUsersFio;
            comboBox1.DisplayMember = "FIO";
            comboBox1.Text = fio;

            dateTimePicker1.Text = data_zakl;

            string[] parts = itogo.Split(',');
            textBox1.Text = parts[0];
            maskedTextBox1.Text = parts[1];
        }

        private void DogovorEditForm_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "0")
            {
                System.Windows.Forms.MessageBox.Show(
                "Ошибка при редактировании договора. \r\n\r\nУкажите корректную сумму к оплате.",
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
            string itogo = rubli + '.' + kopeek;

            string manager = comboBox1.Text;
            string data = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            DogovorClass.EditDogovor(id, manager, data, itogo);
            this.Close();
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

        private void DogovorEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы изменить договор, нужно:

            1) В выпадающем списке выбрать ФИО сотрудника
            2) Указать дату заключения договора
            3) Ввести сумму к оплате (рубли и копейки)
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
