using DIPLOM_RAYKHERT.MyClass.SpravochnikClass;
using DIPLOM_RAYKHERT.MyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyForm.Kurs
{
    public partial class POForKursForm : Form
    {
        public POForKursForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += POForKursForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void POForKursForm_Load(object sender, EventArgs e)
        {
            POClass.GetPOList();
            dataGridView1.DataSource = POClass.dtPO;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                POForKurs.GetPoForKursList(KursEditForm.id_kursa);
                dataGridView2.DataSource = POForKurs.dtPOForKurs;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                int id_po = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                POForKurs.AddPoForKurs(KursEditForm.id_kursa, id_po);
            }

            POForKurs.GetPoForKursList(KursEditForm.id_kursa);
            dataGridView2.DataSource = POForKurs.dtPOForKurs;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int rowsCount = dataGridView2.RowCount;
            if (rowsCount >= 1)
            {
                int id_pdk = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                POForKurs.RemovePoFromKurs(id_pdk);
            }

            POForKurs.GetPoForKursList(KursEditForm.id_kursa);
            dataGridView2.DataSource = POForKurs.dtPOForKurs;
        }

        private void POForKursForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
