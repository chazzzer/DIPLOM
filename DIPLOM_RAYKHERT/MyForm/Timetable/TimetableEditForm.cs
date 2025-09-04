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

namespace DIPLOM_RAYKHERT.MyForm.Timetable
{
    public partial class TimetableEditForm : Form
    {
        string id;
        string old_group_name;
        string old_fio_teacher;
        string old_kabinet;
        string old_start;
        public TimetableEditForm(string id_raspisaniya, string group_name, 
            string fio_teacher, string kabinet, string start)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += TimetableEditForm_KeyDown;

            GroupClass.GetGroupList();
            comboBox1.DataSource = GroupClass.dtGroup;
            comboBox1.DisplayMember = "название_группы";

            KabinetClass.GetKabList();
            comboBox2.DataSource = KabinetClass.dtKab;
            comboBox2.DisplayMember = "номер_кабинета";

            comboBox1.Text = group_name;
            comboBox2.Text = kabinet;

            id = id_raspisaniya;
            old_group_name = group_name;
            old_fio_teacher = fio_teacher;
            old_kabinet = kabinet;

            string[] parts = start.Split(' ');
            string datePart = parts[0];
            string timePart = parts[1];
            dateTimePicker1.Text = datePart;
            maskedTextBox1.Text = timePart;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskCompleted)
            {
                // Время введено полностью
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при редактировании занятия. \r\n\r\nВведите корректное время!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string new_group_name = comboBox1.Text;
            string new_kab = comboBox2.Text;
            string new_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string new_time = maskedTextBox1.Text;
            string new_dateTimeStart = new_date + ' ' + new_time;

            TimetableClass.EditTimetable(id, new_group_name, new_kab, new_dateTimeStart, old_group_name);
            this.Close();
        }

        private void TimetableEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы изменить занятие, необходимо:

            1) Выбрать группу в соответствующем выпадающем списке
            2) Выбрать кабинет в соответствующем выпадающем списке
            3) Указать дату и время начала занятия
            4) Нажать на кнопку 'Сохранить'";

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
