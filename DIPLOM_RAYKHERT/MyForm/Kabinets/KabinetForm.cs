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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DIPLOM_RAYKHERT.MyForm.Kabinets
{
    public partial class KabinetForm : Form
    {
        public KabinetForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += KabinetForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KabinetForm_Load(object sender, EventArgs e)
        {
            KabinetClass.GetKabList();
            dataGridView1.DataSource = KabinetClass.dtKab;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                int id_kabineta = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                POInKabClass.GetPoInKabList(id_kabineta);
                dataGridView2.DataSource = POInKabClass.dtPoInKab;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KabinetAddForm kaf = new KabinetAddForm();
            kaf.ShowDialog();

            KabinetClass.GetKabList();
            dataGridView1.DataSource = KabinetClass.dtKab;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите кабинет для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string nomer = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string type = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                KabinetEditForm kef = new KabinetEditForm(id, nomer, type);
                kef.ShowDialog();

                KabinetClass.GetKabList();
                dataGridView1.DataSource = KabinetClass.dtKab;
            }
            catch
            {
                MessageBox.Show(
                "Не удалось отредактировать кабинет.\r\n\r\n" +
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
                MessageBox.Show("Пожалуйста, выберите кабинет для удаления.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить кабинет?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    KabinetClass.DeleteKabinet(id);
                    KabinetClass.GetKabList();
                    dataGridView1.DataSource = KabinetClass.dtKab;
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось удалить кабинет.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите кабинет.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int id_kabineta = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int kab = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            AddPOInKabForm apoi = new AddPOInKabForm(id_kabineta, kab);
            apoi.ShowDialog();

            KabinetClass.GetKabList();
            dataGridView1.DataSource = KabinetClass.dtKab;

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                POInKabClass.GetPoInKabList(id_kabineta);
                dataGridView2.DataSource = POInKabClass.dtPoInKab;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_kabineta = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            POInKabClass.GetPoInKabList(id_kabineta);
            dataGridView2.DataSource = POInKabClass.dtPoInKab;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void KabinetForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
