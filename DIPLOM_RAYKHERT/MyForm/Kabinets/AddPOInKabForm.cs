using DIPLOM_RAYKHERT.MyClass;
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

namespace DIPLOM_RAYKHERT.MyForm.Kabinets
{
    public partial class AddPOInKabForm : Form
    {
        int id = 0;
        public AddPOInKabForm(int id_kab, int kabinet)
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += AddPOInKabForm_KeyDown;
            id = id_kab;
            kabLbl.Text = kabinet.ToString();
        }

        private void AddPOInKabForm_Load(object sender, EventArgs e)
        {
            POClass.GetPOList();
            dataGridView1.DataSource = POClass.dtPO;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                POInKabClass.GetPoInKabList(id);
                dataGridView2.DataSource = POInKabClass.dtPoInKab;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                int id_po = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                POInKabClass.AddPoInKab(id, id_po);
            }

            POInKabClass.GetPoInKabList(id);
            dataGridView2.DataSource = POInKabClass.dtPoInKab;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int rowsCount = dataGridView2.RowCount;
            if (rowsCount >= 1)
            {
                int id_pvk = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                POInKabClass.RemovePoFromKab(id_pvk);
            }

            POInKabClass.GetPoInKabList(id);
            dataGridView2.DataSource = POInKabClass.dtPoInKab;
        }

        private void AddPOInKabForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы добавить программное обеспечение в кабинет, необходимо:
            1) Нажать на программное обеспечение в левой колонке
            2) Нажать на зеленую стрелочку
            
            Если Вам нужно убрать программное обеспечение из кабинета, то:
            1) Нажмите на программное обеспечение в правой колонке
            2) Нажмите на красную стрелочку";

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
