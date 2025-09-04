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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DIPLOM_RAYKHERT.MyForm
{
    public partial class UserAddForm : Form
    {
        public UserAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += UserAddForm_KeyDown;
        }

        private void nameTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) ||
             e.KeyChar == (char)Keys.Back ||
             e.KeyChar == (char)Keys.Space);
        }

        private void surnameTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) ||
             e.KeyChar == (char)Keys.Back ||
             e.KeyChar == (char)Keys.Space);
        }

        private void lastNameTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) ||
             e.KeyChar == (char)Keys.Back ||
             e.KeyChar == (char)Keys.Space);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            string pass = passTb.Text;

            if ((name == "") || (surname == "") || (lastName == "") || 
                (phone == "") || (email == "") || (login == "") || (pass == ""))
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении пользователя. Заполните все поля!",
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
                    "Ошибка при добавлении пользователя. Введите номер телефона полностью!",
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

            if (UserClass.AddUser(name, surname, lastName, role, phone, email, login, pass) == false)
            {
                return;
            }
            
            this.Close();
        }

        private void UserAddForm_Load(object sender, EventArgs e)
        {
            RoliClass.GetRoliList();
            roleCb.DataSource = RoliClass.dtRoli;
            roleCb.DisplayMember = "роль";
            roleCb.ValueMember = "id_роли";
        }

        private void phoneMtb_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void UserAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для добавления пользователя, необходимо:

            1) Указать фамилию, имя, отчество и занимаемую должность
            2) Заполнить номер телефона и адрес электронной почты
            3) Указать логин и пароль для авторизации
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
