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

namespace DIPLOM_RAYKHERT.MyForm
{
    public partial class UserEditForm : Form
    {
        int id = 0;
        string old_phone;
        string old_email;
        string old_login;
        public UserEditForm(string idx, string surname, string name, string lastName, 
            string role, string phone, string email, string login)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += UserEditForm_KeyDown;

            old_phone = phone;
            old_email = email;
            old_login = login;

            RoliClass.GetRoliList();
            roleCb.DataSource = RoliClass.dtRoli;
            roleCb.DisplayMember = "роль";
            roleCb.ValueMember = "id_роли";

            id = Convert.ToInt32(idx);
            nameTb.Text = name;
            surnameTb.Text = surname;
            lastNameTb.Text = lastName;
            roleCb.Text = role;
            phoneMtb.Text = phone;
            emailTb.Text = email;
            loginTb.Text = login;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = nameTb.Text;
            string surname = surnameTb.Text;
            string lastName = lastNameTb.Text;
            string role = roleCb.Text;
            string phone = phoneMtb.Text;
            string email = emailTb.Text;
            string login = loginTb.Text;

            if ((name == "") || (surname == "") || (lastName == "") ||
                (phone == "") || (email == "") || (login == ""))
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при редактировании пользователя. Заполните все поля!",
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
                    "Ошибка при редактировании пользователя. Введите номер телефона полностью!",
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

            if (UserClass.EditUser(id, name, surname, lastName, role, phone, email, login,
                        old_phone, old_email, old_login) == false)
            {
                return;
            }
            
            this.Close();
        }

        private void surnameTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) ||
             e.KeyChar == (char)Keys.Back ||
             e.KeyChar == (char)Keys.Space);
        }

        private void UserEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для добавления пользователя, необходимо:

            1) Указать фамилию, имя, отчество и занимаемую должность
            2) Заполнить номер телефона и адрес электронной почты
            3) Указать логин для авторизации
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
