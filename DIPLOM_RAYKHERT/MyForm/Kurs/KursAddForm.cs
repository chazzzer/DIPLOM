using DIPLOM_RAYKHERT.MyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace DIPLOM_RAYKHERT.MyForm
{
    public partial class KursAddForm : Form
    {
        string relativePath = "";
        public KursAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += KursAddForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KursAddForm_Load(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog
            {
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    kursPb.Image = Image.FromFile(openFileDialog1.FileName);

                    string currentDirectory = Environment.CurrentDirectory;
                    string fullPath = openFileDialog1.FileName;
                    // Преобразовать полный путь к относительному
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        // Для более старых версий .NET
                        Uri baseUri = new Uri(currentDirectory + "\\");
                        Uri fileUri = new Uri(fullPath);
                        Uri relativeUri = baseUri.MakeRelativeUri(fileUri);
                        relativePath = Uri.UnescapeDataString(relativeUri.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии файла: " + ex.Message, 
                    "Ошибка", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                }
            }
        }

        private void kursTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) ||
             e.KeyChar == (char)Keys.Back ||
             e.KeyChar == (char)Keys.Space ||
             e.KeyChar == ':' || e.KeyChar == '-' || e.KeyChar == '#' || e.KeyChar == ',' || e.KeyChar == '&' ||
             char.IsDigit(e.KeyChar));
        }

        private void hoursTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) ||
                e.KeyChar == (char)Keys.Back);
        }

        private void priceTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) ||
                e.KeyChar == (char)Keys.Back);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kurs = kursTb.Text;
            if ((kurs == "") || (hoursTb.Text == "") || (priceTb.Text == ""))
            {
                MessageBox.Show("Заполните все поля и выберите изображение!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            int hours = Convert.ToInt32(hoursTb.Text);
            if (hours < 2)
            {
                MessageBox.Show("Курс не может длиться менее 2-х часов!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (hours > 300)
            {
                MessageBox.Show("Курс не может длиться более 300 часов!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                hoursTb.Text = "300";
                hours = Convert.ToInt32(hoursTb.Text);
                return;
            }

            if (priceTb.Text == "0")
            {
                MessageBox.Show("Цена не может быть равна нулю!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            string kopeek;
            if (maskedTextBox1.MaskFull)
            {
                kopeek = maskedTextBox1.Text;
            }
            else
            {
                kopeek = "00";
            }
            string rubli = priceTb.Text;
            string price = rubli + '.' + kopeek;

            KursiClass.AddKurs(relativePath, kurs, hours, price);
            this.Close();
        }

        private void KursAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы добавить новый курс, нужно:

            1) Указать название курса в поле для ввода
            2) Указать количество академических часов
            3) Ввести цену на курс
            4) Выбрать изображение, нажатием на кнопку 'Обзор'
            5) Нажать на кнопку 'Добавить'";

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

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = System.Drawing.Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = System.Drawing.Color.White;
        }
    }
}
