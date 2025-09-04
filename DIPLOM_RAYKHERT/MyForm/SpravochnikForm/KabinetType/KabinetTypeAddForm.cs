using DIPLOM_RAYKHERT.MyClass.SpravochnikClass;
using DIPLOM_RAYKHERT.MyForm.Spravochnik;
using Org.BouncyCastle.Asn1.Mozilla;
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
    public partial class KabinetTypeAddForm : Form
    {
        public KabinetTypeAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += KabinetTypeAddForm_KeyDown;
        }

        private void KabinetTypeAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) ||
             e.KeyChar == (char)Keys.Back ||
             e.KeyChar == (char)Keys.Space || e.KeyChar == '-');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kabinet_type = textBox1.Text;
            if (kabinet_type == "")
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении типа кабинета. Поле не может быть пустым",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            KabinetTypeClass.AddKabinetType(kabinet_type);
            this.Close();
        }

        private void KabinetTypeAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы добавить новый тип кабинета, нужно:

            1) Указать новый тип кабинета в поле для ввода
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
