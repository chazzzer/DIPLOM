using DIPLOM_RAYKHERT.MyForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DIPLOM_RAYKHERT
{
    public partial class AuthorizationForm : Form
    {
        private string hintLogin = "Введите логин";
        private string hintPass = "Введите пароль";
        static public string password = "";
        public AuthorizationForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += AuthorizationForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Application.Exit();
                MyClass.DbConnection.close_Db();
            }
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            loginTb.Text = hintLogin;
            loginTb.ForeColor = System.Drawing.Color.Gray;
            passwordTb.UseSystemPasswordChar = false;
            passwordTb.Text = hintPass;
            passwordTb.ForeColor = System.Drawing.Color.Gray;
        }

        private void humanPb_Click(object sender, EventArgs e)
        {

        }

        private void passwordTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            passwordTb.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string log = loginTb.Text;
            string pass = passwordTb.Text;
            password = pass;

            MyClass.DbConnection.Authorization(log, pass);
            switch(MyClass.DbConnection.role)
            {
                case "Менеджер продаж":
                    MessageBox.Show(
                    $"Добро пожаловать, {MyClass.DbConnection.fio}!",
                    "Приветствие",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    MyForm.MainForm mf = new MyForm.MainForm();
                    mf.Show();
                    this.Hide();
                    break;
                case "Управляющий":
                    MessageBox.Show(
                    $"Добро пожаловать, {MyClass.DbConnection.fio}!",
                    "Приветствие",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    MyForm.MainForm mff = new MyForm.MainForm();
                    mff.Show();
                    this.Hide();
                    break;
                default:
                    MessageBox.Show(
                    "Ошибка при авторизации! Проверьте корректность введенных данных",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    passwordTb.Text = "";
                    break;
            }
        }

        private void loginTb_Enter(object sender, EventArgs e)
        {
            if (loginTb.Text == hintLogin)
            {
                loginTb.Text = "";
                loginTb.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void loginTb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(loginTb.Text))
            {
                loginTb.Text = hintLogin;
                loginTb.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void passwordTb_Enter(object sender, EventArgs e)
        {
            if (passwordTb.Text == hintPass)
            {
                passwordTb.UseSystemPasswordChar = true;
                passwordTb.Text = "";
                passwordTb.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void passwordTb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(passwordTb.Text))
            {
                passwordTb.UseSystemPasswordChar = false;
                passwordTb.Text = hintPass;
                passwordTb.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = System.Drawing.Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = System.Drawing.Color.White;
        }

        private void AuthorizationForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для авторизации необходимо:

            1) Ввести логин в поле напротив иконки с человечком
            2) Ввести пароль в поле напротив иконки с замком
            3) Нажать на кнопку 'Войти'
    
            При необходимости, вы можете на кнопку 'Показать пароль', чтобы посмотреть введенные символы";

            if (e.KeyCode == Keys.F1)
            {
                HelpForm hf = new HelpForm();
                hf.ShowDialog();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    Application.Exit();
                    MyClass.DbConnection.close_Db();
                }
            }
        }
    }
}
