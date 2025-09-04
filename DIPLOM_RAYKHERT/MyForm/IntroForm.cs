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
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += IntroForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectForm cf = new ConnectForm();
            cf.Show();
            this.Hide();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = System.Drawing.Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = System.Drawing.Color.White;
        }

        private void IntroForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }
    }
}
