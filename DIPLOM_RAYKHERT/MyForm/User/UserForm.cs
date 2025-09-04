using DIPLOM_RAYKHERT.MyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyForm
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += UserForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            UserClass.GetUsersList();
            dataGridView1.DataSource = UserClass.dtUsers;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для удаления.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;

            }
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    int idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    UserClass.DeleteUser(idx);
                    UserClass.GetUsersList();
                    dataGridView1.DataSource = UserClass.dtUsers;
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось удалить пользователя.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserAddForm uaf = new UserAddForm();
            uaf.ShowDialog();

            UserClass.GetUsersList();
            dataGridView1.DataSource = UserClass.dtUsers;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string surname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string name = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string lastName = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string role = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string phone = dataGridView1.CurrentRow.Cells["Phone"].Value.ToString();
                string email = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                string login = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                UserEditForm uef = new UserEditForm(id, surname, name, lastName, role, phone, email, login);
                uef.ShowDialog();

                UserClass.GetUsersList();
                dataGridView1.DataSource = UserClass.dtUsers;
            }
            catch
            {
                MessageBox.Show(
                "Не удалось отредактировать пользователя.\r\n\r\n" +
                "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void UserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
