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

namespace DIPLOM_RAYKHERT.MyForm.SpravochnikForm
{
    public partial class RoliAddForm : Form
    {
        public RoliAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += RoliAddForm_KeyDown;
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
            string role = textBox1.Text;
            if (role == "")
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении роли. Поле не может быть пустым",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            RoliClass.AddRoli(role);
            this.Close();
        }

        private void RoliAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы добавить новую роль, нужно:

            1) Указать роль в поле для ввода
            2) Нажать на кнопку 'Добавить'";

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
