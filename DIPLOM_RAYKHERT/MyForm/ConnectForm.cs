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
    public partial class ConnectForm : Form
    {
        static public string server_address = "";
        static public string database = "";
        public ConnectForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += ConnectForm_KeyDown;

            serverTb.Text = "localhost";
            databaseTb.Text = "raykhert_korund";
            userTb.Text = "root";
            passTb.Text = "qwerty";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((serverTb.Text == "") || (databaseTb.Text == "")
                || (userTb.Text == "") || (passTb.Text == ""))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            server_address = serverTb.Text;
            database = databaseTb.Text;
            string user = userTb.Text;
            string password = passTb.Text;

            if (MyClass.DbConnection.connect_Db(server_address, database, user, password) == false)
            {
                return;
            }

            System.Windows.Forms.MessageBox.Show(
                "Успешное подключение к базе данных!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            AuthorizationForm af = new AuthorizationForm();
            af.Show();
            this.Hide();
        }

        private void ConnectForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы подключиться к базе данных необходимо:

            1) Указать адрес сервера в соответствующее поле (например: localhost)
            2) Указать название базы данных в соответствующее поле (например: raykhert_korund)
            3) Указать имя пользователя сервера в соответствующее поле (например: root)
            4) Указать пароль в соответствующее поле (например: qwerty)
            5) Нажать на кнопку 'Подключиться'
    
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

        private void ConnectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IntroForm iff = new IntroForm();
            iff.Show();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {

        }
    }
}
