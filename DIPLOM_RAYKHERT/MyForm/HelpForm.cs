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
    public partial class HelpForm : Form
    {
        public static string hint;
        public HelpForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += HelpForm_KeyDown;
            helpLbl.Text = hint;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
