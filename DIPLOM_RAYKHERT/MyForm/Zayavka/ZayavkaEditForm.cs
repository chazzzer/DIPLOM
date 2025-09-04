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

namespace DIPLOM_RAYKHERT.MyForm.Zayavka
{
    public partial class ZayavkaEditForm : Form
    {
        string id;
        string old_phone;
        string old_email;
        public ZayavkaEditForm(string id_zayavki, string fio, string kurs, string manager, string date)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += ZayavkaEditForm_KeyDown;

            KursiClass.GetKursiList();
            kursiCb.DataSource = KursiClass.dtKursi;
            kursiCb.DisplayMember = "название";
            kursiCb.ValueMember = "id_курса";

            UserClass.GetUsersListFio();
            comboBox1.DataSource = UserClass.dtUsersFio;
            comboBox1.DisplayMember = "FIO";
            
            id = id_zayavki;

            string[] parts = fio.Split(' ');
            surnameTb.Text = parts[0];
            nameTb.Text = parts[1];
            lastNameTb.Text = parts[2];
            phoneMtb.Text = StudentClass.GetPhone(id);
            old_phone = phoneMtb.Text;
            emailTb.Text = StudentClass.GetEmail(id);
            old_email = emailTb.Text;

            kursiCb.Text = kurs;
            comboBox1.Text = manager;
            dateTimePicker1.Text = date;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ZayavkaEditForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameTb.Text;
            string surname = surnameTb.Text;
            string lastName = lastNameTb.Text;
            string new_phone = phoneMtb.Text;
            string new_email = emailTb.Text;
            string kurs = kursiCb.Text;
            string data_zayavki = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string manager_fio = comboBox1.Text;

            if ((name == "") || (surname == "") || (lastName == "") ||
                (new_phone == "") || (new_email == ""))
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении заявки. \r\n\r\nЗаполните все поля!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (phoneMtb.MaskCompleted)
            {
                // Номер введен полностью
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении заявки. \r\n\r\nВведите номер телефона полностью!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


            if (MyClass.UserClass.CheckEmail(new_email) == false)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Введите корректный электронный адрес! Пример: name@gmail.com",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            ZayavkiClass.EditZayavka(id, name, surname, lastName, new_phone, new_email, kurs,
                data_zayavki, manager_fio, old_phone, old_email);
            this.Close();
        }

        private void ZayavkaEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для редактирования заявки, необходимо:

            1) Указать фамилию, имя, отчество человека, подавшего заявку
            2) Выбрать в выпадающем списке наименование курса
            3) Заполнить номер телефона и адрес электронной почты
            4) Выбрать ФИО менеджера и указать дату составления заявки
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
