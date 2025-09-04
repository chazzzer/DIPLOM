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
    public partial class StudentEditForm : Form
    {
        int id = 0;
        string old_phone;
        string old_email;
        public StudentEditForm(string idx, string surname, string name, string lastName, 
            string phone, string email)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += StudentEditForm_KeyDown;

            old_phone = phone;
            old_email = email;

            id = Convert.ToInt32(idx);
            nameTb.Text = name;
            surnameTb.Text = surname;
            lastNameTb.Text = lastName;
            phoneMtb.Text = phone;
            emailTb.Text = email;
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
                    "Ошибка при редактировании обучающегося. Заполните все поля!",
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
                    "Ошибка при редактировании обучающегося. Введите номер телефона полностью!",
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

            if (StudentClass.EditStudent(id, name, surname, lastName, phone, email,
                        old_phone, old_email) == false)
            {
                return;
            }
            this.Close();
        }

        private void StudentEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для редактирования обучающегося, необходимо:

            1) Указать фамилию, имя, отчество
            2) Заполнить номер телефона и адрес электронной почты
            3) Нажать на кнопку 'Сохранить'";

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
