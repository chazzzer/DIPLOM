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

namespace DIPLOM_RAYKHERT.MyForm.Price
{
    public partial class PriceForm : Form
    {
        public PriceForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += PriceForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PriceForm_Load(object sender, EventArgs e)
        {
            PriceClass.GetPriceList();
            dataGridView1.DataSource = PriceClass.dtPrice;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PriceAddForm paf = new PriceAddForm();
            paf.ShowDialog();

            PriceClass.GetPriceList();
            dataGridView1.DataSource = PriceClass.dtPrice;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите прайс для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string id_price = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string kurs = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string price = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string date = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                PriceEditForm pef = new PriceEditForm(id_price, kurs, price, date);
                pef.ShowDialog();

                PriceClass.GetPriceList();
                dataGridView1.DataSource = PriceClass.dtPrice;
            }
            catch
            {
                MessageBox.Show(
                "Не удалось отредактировать прайс.\r\n\r\n" +
                "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите прайс для удаления.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int id_price = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить прайс?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    PriceClass.DelPrice(id_price);
                    PriceClass.GetPriceList();
                    dataGridView1.DataSource = PriceClass.dtPrice;
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось удалить прайс.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }                
            }
        }

        private void PriceForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
