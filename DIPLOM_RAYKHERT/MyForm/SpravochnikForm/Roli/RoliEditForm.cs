using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyForm.SpravochnikForm
{
    public partial class RoliEditForm : Form
    {
        int id = 0;
        string old_role;
        public RoliEditForm(string idx, string role)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += RoliEditForm_KeyDown;

            old_role = role;
            id = Convert.ToInt32(idx);
            textBox1.Text = role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) ||
             e.KeyChar == (char)Keys.Back ||
             e.KeyChar == (char)Keys.Space);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string new_role = textBox1.Text;
            if (new_role == "")
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при редактировании роли. Поле не может быть пустым",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            MyClass.SpravochnikClass.RoliClass.EditRole(id, new_role, old_role);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RoliEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы изменить роль, нужно:

            1) Указать новую роль в поле для ввода
            2) Нажать на кнопку 'Сохранить'";

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
