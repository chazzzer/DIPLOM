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
    public partial class StatusEditForm : Form
    {
        int id = 0;
        string old_status;
        public StatusEditForm(string idx, string status)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += StatusEditForm_KeyDown;

            old_status = status;
            id = Convert.ToInt32(idx);
            textBox1.Text = status;
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
            string new_status = textBox1.Text;
            if (new_status == "")
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при редактировании статуса. Поле не может быть пустым",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            MyClass.SpravochnikClass.StatusClass.EditStatus(id, new_status, old_status);
            this.Close();
        }

        private void StatusEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы изменить статус, нужно:

            1) Указать новый статус в поле для ввода
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
