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

namespace DIPLOM_RAYKHERT.MyForm.Teacher
{
    public partial class TeacherKursForm : Form
    {
        int id = 0;
        public TeacherKursForm(int idx)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += TeacherKursForm_KeyDown;
            id = idx;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TeacherKursForm_Load(object sender, EventArgs e)
        {
            KursiClass.GetKursiList();
            dataGridView1.DataSource = KursiClass.dtKursi;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                TeacherKursClass.GetTeacherKursList(id);
                dataGridView2.DataSource = TeacherKursClass.dtTeacherKurs;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                string id_kurs = dataGridView1.CurrentRow.Cells["KURSID"].Value.ToString();
                TeacherKursClass.AddTeacherKurs(id, id_kurs);
            }

            TeacherKursClass.GetTeacherKursList(id);
            dataGridView2.DataSource = TeacherKursClass.dtTeacherKurs;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int rowsCount = dataGridView2.RowCount;
            if (rowsCount >= 1)
            {
                string id_pk = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                TeacherKursClass.DeleteTeacherKurs(id_pk);
            }

            TeacherKursClass.GetTeacherKursList(id);
            dataGridView2.DataSource = TeacherKursClass.dtTeacherKurs;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void TeacherKursForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы добавить преподаваемый курс, необходимо:
            1) Нажать на курс в левой колонке
            2) Нажать на зеленую стрелочку
            
            Если Вам нужно убрать преподаваемый курс, то:
            1) Нажмите на курс в правой колонке
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
