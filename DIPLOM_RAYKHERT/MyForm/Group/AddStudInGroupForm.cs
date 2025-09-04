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

namespace DIPLOM_RAYKHERT.MyForm.Group
{
    public partial class AddStudInGroupForm : Form
    {
        string kurs;
        public AddStudInGroupForm(string group_name, string kursss)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += AddStudInGroupForm_KeyDown;
            groupNameLbl.Text = group_name;
            kurs = kursss;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddStudInGroupForm_Load(object sender, EventArgs e)
        {
            StudentsInGroupClass.GetFreeStudentsList(kurs);
            dataGridView1.DataSource = StudentsInGroupClass.dtFreeStud;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                StudentsInGroupClass.GetStudentInGroupList(groupNameLbl.Text);
                dataGridView2.DataSource = StudentsInGroupClass.dtStudentsInGroup;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                string fio = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                StudentsInGroupClass.AddStudentInGroup(fio, groupNameLbl.Text);
            }

            StudentsInGroupClass.GetStudentInGroupList(groupNameLbl.Text);
            dataGridView2.DataSource = StudentsInGroupClass.dtStudentsInGroup;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int rowsCount = dataGridView2.RowCount;
            if (rowsCount >= 1)
            {
                string fio = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                StudentsInGroupClass.RemoveStudentFromGroup(fio, groupNameLbl.Text);
            }

            StudentsInGroupClass.GetFreeStudentsList(kurs);
            dataGridView1.DataSource = StudentsInGroupClass.dtFreeStud;
            StudentsInGroupClass.GetStudentInGroupList(groupNameLbl.Text);
            dataGridView2.DataSource = StudentsInGroupClass.dtStudentsInGroup;
        }

        private void AddStudInGroupForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы добавить обучающегося в группу, необходимо:
            1) Нажать на обучающегося в левой колонке
            2) Нажать на зеленую стрелочку
            
            Если Вам нужно убрать обучающегося из группы, то:
            1) Нажмите на обучающегося в правой колонке
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
