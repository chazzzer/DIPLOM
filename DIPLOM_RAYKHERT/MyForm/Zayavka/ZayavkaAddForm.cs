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
    public partial class ZayavkaAddForm : Form
    {
        public ZayavkaAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += ZayavkaAddForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ZayavkaAddForm_Load(object sender, EventArgs e)
        {
            KursiClass.GetKursiList();
            kursiCb.DataSource = KursiClass.dtKursi;
            kursiCb.DisplayMember = "название";
            kursiCb.ValueMember = "id_курса";
        }

        private void nameTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) ||
             e.KeyChar == (char)Keys.Back ||
             e.KeyChar == (char)Keys.Space);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameTb.Text;
            string surname = surnameTb.Text;
            string lastName = lastNameTb.Text;
            string phone = phoneMtb.Text;
            string email = emailTb.Text;
            string kurs = kursiCb.Text;

            if ((name == "") || (surname == "") || (lastName == "") ||
                (phone == "") || (email == ""))
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении заявки. Заполните все поля!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (phoneMtb.MaskCompleted)
            {
                // Номер введен полностью
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении заявки. Введите номер телефона полностью!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


            if (MyClass.UserClass.CheckEmail(email) == false)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Введите корректный электронный адрес! Пример: name@gmail.com",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            ZayavkiClass.AddZayavka(name, surname, lastName, kurs, phone, email);
            this.Close();
        }

        private void ZayavkaAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для добавления заявки, необходимо:

            1) Указать фамилию, имя, отчество человека, подавшего заявку
            2) Выбрать в выпадающем списке наименование курса
            3) Заполнить номер телефона и адрес электронной почты
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
                e.Handled = true;
            }
        }
    }
}
