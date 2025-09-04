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
    public partial class GroupAddForm : Form
    {
        public GroupAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += GroupAddForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kurs = comboBox1.Text;
            string teacher = comboBox2.Text;
            string start_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            GroupClass.AddGroup(kurs, teacher, start_date);
            this.Close();
        }

        private void GroupAddForm_Load(object sender, EventArgs e)
        {
            KursiClass.GetKursiList();
            comboBox1.DataSource = KursiClass.dtKursi;
            comboBox1.DisplayMember = "название";

            TeacherClass.GetTeacherFio(comboBox1.Text);
            comboBox2.DataSource = TeacherClass.dtTeacherFio;
            comboBox2.DisplayMember = "FIO";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeacherClass.GetTeacherFio(comboBox1.Text);
            comboBox2.DataSource = TeacherClass.dtTeacherFio;
            comboBox2.DisplayMember = "FIO";
        }

        private void GroupAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы создать новую группу для изучения курса, нужно:

            1) В соответствующем выпадающем списке выбрать курс для изучения
            2) Ниже выбрать доступного преподавателя
            3) Выбрать дату начала обучения
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
