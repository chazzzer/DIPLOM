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

namespace DIPLOM_RAYKHERT.MyForm.Student
{
    public partial class ZapisNaKursForm : Form
    {
        string id_student;
        public ZapisNaKursForm(string id)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += ZapisNaKursForm_KeyDown;

            id_student = id;

            KursiClass.GetKursiList();
            kursiCb.DataSource = KursiClass.dtKursi;
            kursiCb.DisplayMember = "название";
            kursiCb.ValueMember = "id_курса";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kurs = kursiCb.Text;
            ZayavkiClass.ZapisNaKurs(id_student, kurs);
            this.Close();
        }

        private void ZapisNaKursForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для записи обучающегося на новый курс, нужно:
            1) В выпадающем списке выбрать курс
            2) Нажать на кнопку 'Записать'";

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
