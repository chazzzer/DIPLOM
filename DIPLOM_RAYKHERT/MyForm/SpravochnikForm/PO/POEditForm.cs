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
    public partial class POEditForm : Form
    {
        int id = 0;
        string old_po;
        public POEditForm(string idx, string po)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += POEditForm_KeyDown;

            old_po = po;
            id = Convert.ToInt32(idx);
            textBox1.Text = po;
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
            string new_po = textBox1.Text;
            if (new_po == "")
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при редактировании программного обеспечения. Поле не может быть пустым",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            MyClass.SpravochnikClass.POClass.EditPO(id, new_po, old_po);
            this.Close();
        }

        private void POEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы изменить программное обеспечение, нужно:

            1) Указать новое программное обеспечение в поле для ввода
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
