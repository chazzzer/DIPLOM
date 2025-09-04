using DIPLOM_RAYKHERT.MyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyForm.Student
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += StudentForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            StudentClass.GetStudentList();
            dataGridView1.DataSource = StudentClass.dtStudents;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            KursiClass.GetKursiList();
            comboBox1.DataSource = KursiClass.dtKursi;
            comboBox1.DisplayMember = "название";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentAddForm saf = new StudentAddForm();
            saf.ShowDialog();

            StudentClass.GetStudentList();
            dataGridView1.DataSource = StudentClass.dtStudents;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите обучающегося для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string surname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string name = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string lastName = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string phone = dataGridView1.CurrentRow.Cells["Phone"].Value.ToString();
                string email = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                StudentEditForm sef = new StudentEditForm(id, surname, name, lastName, phone, email);
                sef.ShowDialog();

                StudentClass.GetStudentList();
                dataGridView1.DataSource = StudentClass.dtStudents;
            }
            catch
            {
                MessageBox.Show(
                "Не удалось отредактировать обучающегося.\r\n\r\n" +
                "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите обучающегося для удаления.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить обучающегося?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    StudentClass.DeleteStudent(idx);
                    StudentClass.GetStudentList();
                    dataGridView1.DataSource = StudentClass.dtStudents;
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось удалить обучающегося.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string fio = textBox2.Text;

            StudentClass.GetStudentListSortedByFIO(fio);
            dataGridView1.DataSource = StudentClass.dtStudents;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.ForeColor = System.Drawing.Color.Black;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = System.Drawing.Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

            string fio = textBox2.Text;

            StudentClass.GetStudentListSortedByFIO(fio);
            dataGridView1.DataSource = StudentClass.dtStudents;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.ForeColor = System.Drawing.Color.Black;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.ForeColor = System.Drawing.Color.White;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string fio = textBox2.Text;

            StudentClass.GetStudentListSortedByFIO(fio);
            dataGridView1.DataSource = StudentClass.dtStudents;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string fio = textBox2.Text;
            string kurs = comboBox1.Text;

            StudentClass.GetStudentListSortedByFIOandKurs(fio, kurs);
            dataGridView1.DataSource = StudentClass.dtStudents;
        }

        private void записатьНаКурсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ZapisNaKursForm znkf = new ZapisNaKursForm(id);
            znkf.ShowDialog();

            StudentClass.GetStudentList();
            dataGridView1.DataSource = StudentClass.dtStudents;
        }

        private void StudentForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для записи обучающегося на новый курс, нужно:
            1) Нажать на нужного обучающегося правой кнопки мыши, тем самым откроется контекстное меню
            2) В контекстном меню нажать левой кнопкой мыши на 'Записать на курс'

            Для получения списка обучающихся по их ФИО, требуется:
            1) Ввести в поле для ввода ФИО обучающегося
            2) Для получения общего списка обучающихся, нажмите 'Очистить поле'

            Для получения списка обучающихся по изучаемому курсу на данный момент, необходимо:
            1) Выбрать наименование курса в соответствующем выпадающем списке
            2) Нажать на кнопку 'Применить'
            3) Для получения общего списка обучающихся, нажмите 'Сбросить'";

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
