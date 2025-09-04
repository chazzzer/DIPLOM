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

namespace DIPLOM_RAYKHERT.MyForm.Sertificat
{
    public partial class SertificatForm : Form
    {
        public SertificatForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += SertificatForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SertificatForm_Load(object sender, EventArgs e)
        {
            SertificatClass.GetSertList();
            dataGridView1.DataSource = SertificatClass.dtSert;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SertificatAddForm saf = new SertificatAddForm();
            saf.ShowDialog();

            SertificatClass.GetSertList();
            dataGridView1.DataSource = SertificatClass.dtSert;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите сертификат для удаления.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int id_sert = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить сертификат?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    SertificatClass.DelSert(id_sert);
                    SertificatClass.GetSertList();
                    dataGridView1.DataSource = SertificatClass.dtSert;
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось удалить сертификат.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите сертификат для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id_sert = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string fio = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string kurs = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string date = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                SertificatEditForm sef = new SertificatEditForm(id_sert, fio, kurs, date);
                sef.ShowDialog();

                SertificatClass.GetSertList();
                dataGridView1.DataSource = SertificatClass.dtSert;
            }
            catch
            {
                MessageBox.Show(
                "Не удалось отредактировать сертификат.\r\n\r\n" +
                "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SertificatClass.GetSertList();
            dataGridView1.DataSource = SertificatClass.dtSert;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                System.Windows.Forms.MessageBox.Show(
                "Ошибка при получении фильтрации списка сертификатов. \r\n\r\nНачальная дата не может быть больше конечной!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                SertificatClass.GetSertList();
                dataGridView1.DataSource = SertificatClass.dtSert;

                return;
            }

            string date_ot = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string date_do = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            SertificatClass.GetSertListSorted(date_ot, date_do);
            dataGridView1.DataSource = SertificatClass.dtSert;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.ForeColor = System.Drawing.Color.Black;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.ForeColor = System.Drawing.Color.White;
        }

        private void SertificatForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для получения списка выданных сертификатов за определенный период, необходимо:
            1) Указать начальную дату
            2) Указать конечную дату
            3) Нажать на кнопку 'Вывести'
            4) Для получения общего списка выданных сертификатов, нажмите 'Сбросить'";

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
