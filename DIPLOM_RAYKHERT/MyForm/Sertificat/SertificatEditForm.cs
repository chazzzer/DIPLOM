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
    public partial class SertificatEditForm : Form
    {
        int id = 0;
        public SertificatEditForm(int idx, string fioo, string kurss, string datee)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += SertificatEditForm_KeyDown;

            SertificatClass.GetStudFio();
            comboBox1.DataSource = SertificatClass.dtStudFio;
            comboBox1.DisplayMember = "FIO";

            KursiClass.GetKursiList();
            comboBox2.DataSource = KursiClass.dtKursi;
            comboBox2.DisplayMember = "название";

            id = idx;
            comboBox1.Text = fioo;
            comboBox2.Text = kurss;
            dateTimePicker1.Text = datee;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fioo = comboBox1.Text;
            string kurs = comboBox2.Text;
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            SertificatClass.EditSert(id, fioo, kurs, date);
            this.Close();
        }

        private void SertificatEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы изменить сертификат, нужно:

            1) В выпадающем списке выбрать ФИО обучающегося
            2) Ниже выбрать название курса
            3) Указать дату выдачи сертификата
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
