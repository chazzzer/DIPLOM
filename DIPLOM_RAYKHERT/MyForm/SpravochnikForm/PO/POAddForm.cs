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

namespace DIPLOM_RAYKHERT.MyForm.SpravochnikForm.PO
{
    public partial class POAddForm : Form
    {
        public POAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += POAddForm_KeyDown;
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
            string po = textBox1.Text;
            if (po == "")
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении программного обеспечения. Поле не может быть пустым",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            POClass.AddPO(po);
            this.Close();
        }

        private void POAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы добавить новое программное обеспечение, нужно:

            1) Указать новое программное обеспечение в поле для ввода
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
