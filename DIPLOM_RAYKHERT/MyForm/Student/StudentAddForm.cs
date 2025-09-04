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

namespace DIPLOM_RAYKHERT.MyForm.Student
{
    public partial class StudentAddForm : Form
    {
        public StudentAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += StudentAddForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void surnameTb_KeyPress(object sender, KeyPressEventArgs e)
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

            if ((name == "") || (surname == "") || (lastName == "") ||
                (phone == "") || (email == ""))
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении обучающегося. Заполните все поля!",
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
                    "Ошибка при добавлении обучающегося. Введите номер телефона полностью!",
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

            if (StudentClass.AddStudent(name, surname, lastName, phone, email))
            {
                return;
            }
            
            this.Close();
        }

        private void StudentAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для добавления нового обучающегося, необходимо:

            1) Указать фамилию, имя, отчество
            2) Заполнить номер телефона и адрес электронной почты
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
