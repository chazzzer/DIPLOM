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
    public partial class TimetableAddForm : Form
    {
        public TimetableAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += TimetableAddForm_KeyDown;

            GroupClass.GetGroupList();
            comboBox1.DataSource = GroupClass.dtGroup;
            comboBox1.DisplayMember = "название_группы";

            KabinetClass.GetKabList();
            comboBox2.DataSource = KabinetClass.dtKab;
            comboBox2.DisplayMember = "номер_кабинета";
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
                    "Ошибка при назначении занятия. \r\n\r\nВведите корректное время!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string group_name = comboBox1.Text;
            string kab = comboBox2.Text;
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string time = maskedTextBox1.Text;
            string dateTimeStart = date + ' ' + time;

            TimetableClass.AddTimetable(group_name, kab, dateTimeStart);
            this.Close();
        }

        private void TimetableAddForm_Load(object sender, EventArgs e)
        {

        }

        private void TimetableAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы назначить занятие, необходимо:

            1) Выбрать группу в соответствующем выпадающем списке
            2) Выбрать кабинет в соответствующем выпадающем списке
            3) Указать дату и время начала занятия
            4) Нажать на кнопку 'Добавить'";

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
