using DIPLOM_RAYKHERT.MyClass;
using DIPLOM_RAYKHERT.MyClass.SpravochnikClass;
using DIPLOM_RAYKHERT.MyForm.Group;
using DIPLOM_RAYKHERT.MyForm.Kabinets;
using DIPLOM_RAYKHERT.MyForm.Student;
using DIPLOM_RAYKHERT.MyForm.Teacher;
using DIPLOM_RAYKHERT.MyForm.Timetable;
using DIPLOM_RAYKHERT.MyForm.Zayavka;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorizationForm af = new AuthorizationForm();
            af.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ZayavkiClass.GetZayavkiList();
            dataGridView1.DataSource = ZayavkiClass.dtZayavki;
            AddColumns();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (DbConnection.role == "Управляющий")
            {
                панельУправляющегоToolStripMenuItem.Visible = true;
            }

            fioTb.Text = DbConnection.fio;
        }

        private void AddColumns()
        {
            // Добавление колонки кнопки "Одобрить"
            DataGridViewButtonColumn approveColumn = new DataGridViewButtonColumn();
            approveColumn.Name = "Approve";
            approveColumn.HeaderText = "Одобрить";
            approveColumn.Text = "Одобрить";
            approveColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(approveColumn);

            // Добавление колонки кнопки "Отклонить"
            DataGridViewButtonColumn rejectColumn = new DataGridViewButtonColumn();
            rejectColumn.Name = "Reject";
            rejectColumn.HeaderText = "Отклонить";
            rejectColumn.Text = "Отклонить";
            rejectColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(rejectColumn);

            // Добавление колонки кнопки "Сформировать договор"
            DataGridViewButtonColumn dogovorColumn = new DataGridViewButtonColumn();
            dogovorColumn.Name = "Dogovor";
            dogovorColumn.HeaderText = "Сформировать договор";
            dogovorColumn.Text = "Сформировать договор";
            dogovorColumn.UseColumnTextForButtonValue = true;
            dogovorColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns.Add(dogovorColumn);
        }

        private void типКабинетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Spravochnik.KabinetTypeForm ktf = new Spravochnik.KabinetTypeForm();
            ktf.ShowDialog();
        }

        private void операционныеСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ролиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpravochnikForm.RoliForm rf = new SpravochnikForm.RoliForm();
            rf.ShowDialog();
        }

        private void статусыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpravochnikForm.StatusForm sf = new SpravochnikForm.StatusForm();
            sf.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void пользователиСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm uf = new UserForm();
            uf.ShowDialog();
        }

        private void сменитьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpf = new ChangePasswordForm();
            cpf.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Проверка колонки
                if (e.ColumnIndex == dataGridView1.Columns["Approve"].Index)
                {
                    // Рисование кнопки "Одобрить" в зеленый цвет
                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.FillRectangle(Brushes.LightGreen, e.CellBounds);
                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds);
                    e.PaintContent(e.CellBounds);
                    e.Handled = true;
                }
                else if (e.ColumnIndex == dataGridView1.Columns["Reject"].Index)
                {
                    // Рисование кнопки "Отклонить" в красный цвет
                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.FillRectangle(Brushes.LightCoral, e.CellBounds);
                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds);
                    e.PaintContent(e.CellBounds);
                    e.Handled = true;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            // Обработка нажатия на кнопку "Одобрить"
            if (e.ColumnIndex == dataGridView1.Columns["Approve"].Index)
            {
                ZayavkiClass.ApproveZayavka(idx);
                ZayavkiClass.GetZayavkiList();
                dataGridView1.DataSource = ZayavkiClass.dtZayavki;
            }
            // Обработка нажатия на кнопку "Отклонить"
            else if (e.ColumnIndex == dataGridView1.Columns["Reject"].Index)
            {
                ZayavkiClass.DeclineZayavka(idx);
                ZayavkiClass.GetZayavkiList();
                dataGridView1.DataSource = ZayavkiClass.dtZayavki;
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Dogovor"].Index)
            {
                string status = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();
                if (status != "Одобрена")
                {
                    MessageBox.Show(
                    "Перед формированием договора, заявка должна быть одобрена!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string kurs = dataGridView1.CurrentRow.Cells["Kurs"].Value.ToString();
                    DogovorClass.AddDogovor(kurs, idx);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZayavkaAddForm zaf = new ZayavkaAddForm();
            zaf.ShowDialog();

            ZayavkiClass.GetZayavkiList();
            dataGridView1.DataSource = ZayavkiClass.dtZayavki;
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заявку для удаления.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить заявку?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    ZayavkiClass.DelZayavka(idx);
                    ZayavkiClass.GetZayavkiList();
                    dataGridView1.DataSource = ZayavkiClass.dtZayavki;
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось удалить заявку.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void договорыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DogovorForm df = new DogovorForm();
            df.ShowDialog();
        }

        private void программноеОбеспечениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyForm.SpravochnikForm.PO.POForm pof = new SpravochnikForm.PO.POForm();
            pof.ShowDialog();
        }

        private void курсыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KursForm kf = new KursForm();
            kf.ShowDialog();
        }

        private void обучающиесяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForm sf = new StudentForm();
            sf.ShowDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            ZayavkiClass.GetZayavkiList();
            dataGridView1.DataSource = ZayavkiClass.dtZayavki;
        }

        private void преподавателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherForm tf = new TeacherForm();
            tf.ShowDialog();
        }

        private void группыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupForm gf = new GroupForm();
            gf.ShowDialog();
        }

        private void кабинетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KabinetForm kf = new KabinetForm();
            kf.ShowDialog();
        }

        private void расписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimetableForm tf = new TimetableForm();
            tf.ShowDialog();
        }

        private void сертификатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sertificat.SertificatForm sf = new Sertificat.SertificatForm();
            sf.ShowDialog();
        }

        private void прайсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Price.PriceForm pf = new Price.PriceForm();
            pf.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sales.SalesForm sf = new Sales.SalesForm();
            sf.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заявку для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string status = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();
            if (status != "Одобрена")
            {
                try
                {
                    string id_zayavki = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string fio = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    string kurs = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    string manager = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    string date = dataGridView1.CurrentRow.Cells["DATEE"].Value.ToString();
                    ZayavkaEditForm zef = new ZayavkaEditForm(id_zayavki, fio, kurs, manager, date);
                    zef.ShowDialog();

                    ZayavkiClass.GetZayavkiList();
                    dataGridView1.DataSource = ZayavkiClass.dtZayavki;
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось отредактировать заявку.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(
                "Нельзя редактировать одобренную заявку",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
        }

        private void сделатьРезервнуюКопиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connStr = $@"Database={ConnectForm.database}; 
                    Datasource={ConnectForm.server_address}; 
                    user=root; 
                    password=qwerty;    
                    charset=utf8;";

            string backupFolderPath = "";

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Выберите папку для сохранения резервной копии";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    backupFolderPath = folderDialog.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Папка не выбрана");
                    return;
                }
            }

            // Формируем полный путь к файлу backup.sql в выбранной папке
            string backupFilePath = Path.Combine(backupFolderPath, "backup.sql");

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        conn.Open();
                        cmd.Connection = conn;

                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            mb.ExportToFile(backupFilePath);
                        }
                    }
                }

                MessageBox.Show($"Резервная копия успешно сохранена в:\n{backupFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании резервной копии: " + ex.Message);
            }

        }

        private void восстановитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connStr = $@"Database={ConnectForm.database}; 
                    Datasource={ConnectForm.server_address}; 
                    user=root; 
                    password=qwerty;    
                    charset=utf8;";

            string backupFilePath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите файл резервной копии для восстановления";
                openFileDialog.Filter = "SQL файлы (*.sql)|*.sql|Все файлы (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    backupFilePath = openFileDialog.FileName;
                }
                else
                {
                    MessageBox.Show("Файл резервной копии не выбран.");
                    return;
                }
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        conn.Open();
                        cmd.Connection = conn;

                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            mb.ImportFromFile(backupFilePath);
                        }
                    }
                }

                MessageBox.Show("Восстановление базы данных прошло успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при восстановлении базы данных: " + ex.Message);
            }

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    AuthorizationForm af = new AuthorizationForm();
                    af.Show();
                    this.Hide();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }
    }
}
