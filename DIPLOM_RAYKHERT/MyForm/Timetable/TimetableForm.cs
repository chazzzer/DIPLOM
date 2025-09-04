using DIPLOM_RAYKHERT.MyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyForm.Timetable
{
    public partial class TimetableForm : Form
    {
        public TimetableForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += TimetableForm_KeyDown;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            // Создать и настроить таймер
            refreshTimer = new Timer();
            refreshTimer.Interval = 60000; // Установить интервал в 60,000 миллисекунд (1 минута)
            refreshTimer.Tick += refreshTimer_Tick; // Присоединить обработчик события Tick
            refreshTimer.Start(); // Запустить таймер
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimetableForm_Load(object sender, EventArgs e)
        {
            TimetableClass.GetTimetableList();
            dataGridView1.DataSource = TimetableClass.dtTimetable;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimetableAddForm taf = new TimetableAddForm();
            taf.ShowDialog();

            TimetableClass.GetTimetableList();
            dataGridView1.DataSource = TimetableClass.dtTimetable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите занятие для отмены.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            string start = dataGridView1.CurrentRow.Cells["START"].Value.ToString();
            string formattedDateStr;
            DateTime originalDate = DateTime.ParseExact(start, "dd.MM.yyyy HH:mm:ss", null);
            formattedDateStr = originalDate.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime date = DateTime.ParseExact(formattedDateStr, "yyyy-MM-dd HH:mm:ss", null);

            string group_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DialogResult result = MessageBox.Show($"Вы уверены, что хотите отменить занятие?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    TimetableClass.DelTimetable(idx, date, group_name);
                    TimetableClass.GetTimetableList();
                    dataGridView1.DataSource = TimetableClass.dtTimetable;
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось отменить занятие.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            TimetableClass.GetTimetableList();
            dataGridView1.DataSource = TimetableClass.dtTimetable;
        }

        private void TimetableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите занятие для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string id_raspisaniya = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string group_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string fio_teacher = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string kabinet = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string start = dataGridView1.CurrentRow.Cells["START"].Value.ToString();
                TimetableEditForm tef = new TimetableEditForm(id_raspisaniya, group_name, fio_teacher, kabinet, start);
                tef.ShowDialog();

                TimetableClass.GetTimetableList();
                dataGridView1.DataSource = TimetableClass.dtTimetable;
            }
            catch
            {
                MessageBox.Show(
                "Не удалось отредактировать занятие.\r\n\r\n" +
                "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void TimetableForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
