using DIPLOM_RAYKHERT.MyClass;
using DIPLOM_RAYKHERT.MyForm.Student;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace DIPLOM_RAYKHERT.MyForm.Teacher
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += TeacherForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {

            TeacherClass.GetTeacherList();
            dataGridView1.DataSource = TeacherClass.dtTeacher;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                int idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                TeacherClass.GetTeacherKursList(idx);
                dataGridView2.DataSource = TeacherClass.dtTeacherKurs;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeacherAddForm taf = new TeacherAddForm();
            taf.ShowDialog();

            TeacherClass.GetTeacherList();
            dataGridView1.DataSource = TeacherClass.dtTeacher;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите преподавателя для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string surname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string name = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string lastName = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string email = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string phone = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                TeacherEditForm tef = new TeacherEditForm(id, surname, name, lastName, phone, email);
                tef.ShowDialog();

                TeacherClass.GetTeacherList();
                dataGridView1.DataSource = TeacherClass.dtTeacher;
            }
            catch
            {
                MessageBox.Show(
                "Не удалось отредактировать преподавателя.\r\n\r\n" +
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
                MessageBox.Show("Пожалуйста, выберите преподавателя для удаления.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить преподавателя?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    TeacherClass.DeleteTeacher(idx);
                    TeacherClass.GetTeacherList();
                    dataGridView1.DataSource = TeacherClass.dtTeacher;
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось удалить преподавателя.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            TeacherClass.GetTeacherKursList(idx);
            dataGridView2.DataSource = TeacherClass.dtTeacherKurs;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите преподавателя.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            TeacherKursForm tkf = new TeacherKursForm(idx);
            tkf.ShowDialog();

            TeacherClass.GetTeacherList();
            dataGridView1.DataSource = TeacherClass.dtTeacher;

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                TeacherClass.GetTeacherKursList(idx);
                dataGridView2.DataSource = TeacherClass.dtTeacherKurs;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            button12.ForeColor = System.Drawing.Color.Black;
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            button12.ForeColor = System.Drawing.Color.White;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TeacherClass.GetTeacherListForWord();
            var dt = TeacherClass.dtTeacherWord;

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для формирования отчета.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var app = new Word.Application();
            app.Visible = false;

            string baseDirectory = Environment.CurrentDirectory;
            string templateRelativePath = @"Docs_Template\[TEMPLATE] Prepod_sostav.docx";
            string templateFullPath = Path.GetFullPath(Path.Combine(baseDirectory, templateRelativePath));

            if (!File.Exists(templateFullPath))
            {
                MessageBox.Show($"Шаблон не найден по пути: {templateFullPath}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Создаем документ на основе шаблона
            var doc = app.Documents.Add(templateFullPath);
            doc.Activate();

            // Получаем первую таблицу (с заголовками)
            Word.Table table = doc.Tables[1];

            int startRow = 2; // начинаем со второй строки (первая — заголовок)

            int rowsNeeded = dt.Rows.Count;
            int existingRows = table.Rows.Count - 1; // без строки заголовка

            // Добавляем строки, если их меньше, чем нужно
            if (rowsNeeded > existingRows)
            {
                for (int i = 0; i < rowsNeeded - existingRows; i++)
                {
                    table.Rows.Add();
                }
            }

            // Заполняем таблицу данными
            /*for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                int tableRowIndex = startRow + i;

                table.Cell(tableRowIndex, 1).Range.Text = (i + 1).ToString(); // № п/п
                table.Cell(tableRowIndex, 2).Range.Text = row["ФИО"].ToString();

                // В столбец с курсами заменяем символы \n на реальные переводы строки Word
                string coursesRaw = row["Курсы"].ToString();
                string coursesFormatted = coursesRaw.Replace("\\n", "\r\n").Replace("\n", "\r\n");
                table.Cell(tableRowIndex, 3).Range.Text = coursesFormatted;

                // Выравнивание по центру для номера
                table.Cell(tableRowIndex, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }*/
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                int tableRowIndex = startRow + i;

                var cell1 = table.Cell(tableRowIndex, 1);
                cell1.Range.Text = (i + 1).ToString(); // № п/п
                cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cell1.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;

                var cell2 = table.Cell(tableRowIndex, 2);
                cell2.Range.Text = row["ФИО"].ToString();
                cell2.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;

                var cell3 = table.Cell(tableRowIndex, 3);
                string coursesRaw = row["Курсы"].ToString();
                string coursesFormatted = coursesRaw.Replace("\\n", "\r\n").Replace("\n", "\r\n");
                cell3.Range.Text = coursesFormatted;
                cell3.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;

                // Выравнивание по центру для номера уже сделано, для курсов оставляем по левому краю (по умолчанию)
            }

            // Заполняем закладки с ФИО менеджера и текущей датой
            string manager_fio = MyClass.DocumentsClass.GetFioManager();
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("d MMMM yyyy 'года'", new CultureInfo("ru-RU"));
            /*doc.Bookmarks["FioManager"].Range.Text = MyClass.DocumentsClass.GetInitials(manager_fio);
            doc.Bookmarks["TodayDate"].Range.Text = formattedDate;*/
            MyClass.DocumentsClass.InsertTextWithHighlight(doc, "FioManager", MyClass.DocumentsClass.GetInitials(manager_fio));
            MyClass.DocumentsClass.InsertTextWithHighlight(doc, "TodayDate", formattedDate);


            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string fileName = $"Prepod_sostav_{currentDate}.docx";
            // Диалог выбора места и имени файла для сохранения
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Сохранить список преподавателей как";
                saveFileDialog.Filter = "Документы Word (*.docx)|*.docx|Все файлы (*.*)|*.*";
                saveFileDialog.FileName = fileName;
                saveFileDialog.InitialDirectory = baseDirectory;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        doc.SaveAs2(saveFileDialog.FileName);

                        MessageBox.Show($"Список преподавателей сохранён! \r\n\r\nРасположение файла: {saveFileDialog.FileName}",
                            "Успешно",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении документа:\r\n{ex.Message}",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Сохранение документа отменено пользователем.",
                        "Отмена",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            // Закрываем документ и приложение
            doc.Close(false);
            app.Quit();

            // Освобождаем COM-объекты
            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }

        private void TeacherForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
