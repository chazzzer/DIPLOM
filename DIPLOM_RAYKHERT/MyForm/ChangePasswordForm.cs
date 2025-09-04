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
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += ChangePasswordForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            currentPassTb.UseSystemPasswordChar = !checkBox1.Checked;
            newPassTb.UseSystemPasswordChar = !checkBox1.Checked;
            repeatPassTb.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredPass = currentPassTb.Text;

            if (enteredPass == "")
            {
                MessageBox.Show(
                "Поле не может быть пустым!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            if (enteredPass == AuthorizationForm.password)
            {
                currentPassTb.Text = "";
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                saveBtn.Enabled = true;
                return;
            } else
            {
                MessageBox.Show(
                "Введенный пароль не совпадает с текущим!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                currentPassTb.Text = "";
                return;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string new_pass = newPassTb.Text;
            string repeat_pass = repeatPassTb.Text;

            if ((new_pass == "") || (repeat_pass == ""))
            {
                MessageBox.Show(
                "Заполните поля!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            if (new_pass != repeat_pass)
            {
                MessageBox.Show(
                "Пароли не совпадают!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            if (new_pass == AuthorizationForm.password)
            {
                MessageBox.Show(
                "Новый пароль совпадает с текущим!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            UserClass.ChangePass(new_pass);
            this.Close();
        }

        private void ChangePasswordForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void ChangePasswordForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы изменить свой пароль необходимо:

            1) Ввести свой текущий пароль и нажать кнопку 'Проверить'
            2) Если пароль верный, Вам откроется доступ к смене пароля на новый
            3) После того, как Вы дважды ввели свой новый пароль, нажмите кнопку 'Сохранить'
            
            При необходимости, вы можете на кнопку 'Показать пароль', чтобы посмотреть введенные символы";
        
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

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = System.Drawing.Color.Black;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = System.Drawing.Color.White;
        }
    }
}
