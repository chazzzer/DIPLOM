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
    public partial class StatusForm : Form
    {
        public StatusForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += StatusForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StatusForm_Load(object sender, EventArgs e)
        {
            StatusClass.GetStatusList();
            dataGridView1.DataSource = StatusClass.dtStatus;
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
                StatusClass.DeleteStatus(idx);
            }

            StatusClass.GetStatusList();
            dataGridView1.DataSource = StatusClass.dtStatus;
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatusAddForm saf = new StatusAddForm();
            saf.ShowDialog();

            StatusClass.GetStatusList();
            dataGridView1.DataSource = StatusClass.dtStatus;
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idx = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string status = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            StatusEditForm sef = new StatusEditForm(idx, status);
            sef.ShowDialog();

            StatusClass.GetStatusList();
            dataGridView1.DataSource = StatusClass.dtStatus;
        }

        private void StatusForm_KeyDown(object sender, KeyEventArgs e)
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
