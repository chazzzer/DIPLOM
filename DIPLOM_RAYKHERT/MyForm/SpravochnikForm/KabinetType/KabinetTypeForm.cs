using DIPLOM_RAYKHERT.MyClass.SpravochnikClass;
using DIPLOM_RAYKHERT.MyForm.SpravochnikForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyForm.Spravochnik
{
    public partial class KabinetTypeForm : Form
    {
        public KabinetTypeForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += KabinetTypeForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KabinetTypeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void KabinetTypeForm_Load(object sender, EventArgs e)
        {
            KabinetTypeClass.GetKabinetTypeList();
            dataGridView1.DataSource = KabinetTypeClass.dtKabinetType;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KabinetTypeAddForm ktaf = new KabinetTypeAddForm();
            ktaf.ShowDialog();

            KabinetTypeClass.GetKabinetTypeList();
            dataGridView1.DataSource = KabinetTypeClass.dtKabinetType;
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idx = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string kabinet_type = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            KabinetTypeEditForm ktef = new KabinetTypeEditForm(idx, kabinet_type);
            ktef.ShowDialog();

            KabinetTypeClass.GetKabinetTypeList();
            dataGridView1.DataSource = KabinetTypeClass.dtKabinetType;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idx = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение", 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                KabinetTypeClass.DeleteKabinetType(idx);
            }

            KabinetTypeClass.GetKabinetTypeList();
            dataGridView1.DataSource = KabinetTypeClass.dtKabinetType;
        }

        private void KabinetTypeForm_KeyDown(object sender, KeyEventArgs e)
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
