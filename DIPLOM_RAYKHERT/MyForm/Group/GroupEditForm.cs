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
    public partial class GroupEditForm : Form
    {
        string id = "";
        string old_groupName;
        public GroupEditForm(string idx, string group_name, string teacher, 
            string kurs, string start_date)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += GroupEditForm_KeyDown;

            old_groupName = group_name;

            KursiClass.GetKursiList();
            comboBox1.DataSource = KursiClass.dtKursi;
            comboBox1.DisplayMember = "название";
            comboBox1.Text = kurs;

            TeacherClass.GetTeacherFio(comboBox1.Text);
            comboBox2.DataSource = TeacherClass.dtTeacherFio;
            comboBox2.DisplayMember = "FIO";

            id = idx;
            textBox1.Text = group_name;
            comboBox2.Text = teacher;
            dateTimePicker1.Text = start_date;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeacherClass.GetTeacherFio(comboBox1.Text);
            comboBox2.DataSource = TeacherClass.dtTeacherFio;
            comboBox2.DisplayMember = "FIO";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                System.Windows.Forms.MessageBox.Show(
                $"Ошибка при редактировании группы. \r\n\r\nВведите название группы",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            GroupClass.EditGroup(id, textBox1.Text, comboBox2.Text, 
                comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), old_groupName);
            this.Close();
        }

        private void GroupEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы изменить группу, нужно:

            1) Указать новое название группы в поле для ввода
            2) В соответствующем выпадающем списке выбрать курс для изучения
            3) Ниже выбрать доступного преподавателя
            4) Выбрать дату начала обучения
            5) Нажать на кнопку 'Сохранить'";

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
