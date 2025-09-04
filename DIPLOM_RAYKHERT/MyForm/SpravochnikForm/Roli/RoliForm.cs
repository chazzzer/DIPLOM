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
    public partial class RoliForm : Form
    {
        public RoliForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += RoliForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RoliForm_Load(object sender, EventArgs e)
        {
            RoliClass.GetRoliList();
            dataGridView1.DataSource = RoliClass.dtRoli;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idx = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                RoliClass.DeleteRole(idx);
            }

            RoliClass.GetRoliList();
            dataGridView1.DataSource = RoliClass.dtRoli;
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoliAddForm raf = new RoliAddForm();
            raf.ShowDialog();

            RoliClass.GetRoliList();
            dataGridView1.DataSource = RoliClass.dtRoli;
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idx = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string role = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            RoliEditForm reff = new RoliEditForm(idx, role);
            reff.ShowDialog();

            RoliClass.GetRoliList();
            dataGridView1.DataSource = RoliClass.dtRoli;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RoliForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы добавить, редактировать или удалить информацию, нужно:

            1) Выбрать строку и нажать по ней правой кнопкой мыши (ПКМ)
            2) В открывшемся контекстном меню выбрать нужное действие и нажать левой кнопкой мыши (ЛКМ)";

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
