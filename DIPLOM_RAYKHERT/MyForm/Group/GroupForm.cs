using DIPLOM_RAYKHERT.MyClass;
using Microsoft.Office.Interop.Word;
using Mysqlx.Crud;
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

namespace DIPLOM_RAYKHERT.MyForm.Group
{
    public partial class GroupForm : Form
    {
        public GroupForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += GroupForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            GroupClass.GetGroupList();
            dataGridView1.DataSource = GroupClass.dtGroup;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            KursiClass.GetKursiList();
            comboBox1.DataSource = KursiClass.dtKursi;
            comboBox1.DisplayMember = "название";

            TeacherClass.GetTeacherFioList();
            comboBox2.DataSource = TeacherClass.dtTeacherFioList;
            comboBox2.DisplayMember = "FIO";

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                string group_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                StudentsInGroupClass.GetStudentInGroupList(group_name);
                dataGridView2.DataSource = StudentsInGroupClass.dtStudentsInGroup;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GroupAddForm gaf = new GroupAddForm();
            gaf.ShowDialog();

            GroupClass.GetGroupList();
            dataGridView1.DataSource = GroupClass.dtGroup;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string group_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            StudentsInGroupClass.GetStudentInGroupList(group_name);
            dataGridView2.DataSource = StudentsInGroupClass.dtStudentsInGroup;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите группу для удаления.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int id_group = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить группу?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    GroupClass.DeleteGroup(id_group);
                    GroupClass.GetGroupList();
                    dataGridView1.DataSource = GroupClass.dtGroup;
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось удалить группу.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                string group_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                StudentsInGroupClass.GetStudentInGroupList(group_name);
                dataGridView2.DataSource = StudentsInGroupClass.dtStudentsInGroup;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите группу.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string group_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string kurs = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            AddStudInGroupForm asi = new AddStudInGroupForm(group_name, kurs);
            asi.ShowDialog();

            GroupClass.GetGroupList();
            dataGridView1.DataSource = GroupClass.dtGroup;

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                string group_namee = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                StudentsInGroupClass.GetStudentInGroupList(group_namee);
                dataGridView2.DataSource = StudentsInGroupClass.dtStudentsInGroup;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите группу для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string group_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string teacher = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string kurs = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string start_date = dataGridView1.CurrentRow.Cells["Start"].Value.ToString();

                GroupEditForm gef = new GroupEditForm(id, group_name, teacher, kurs, start_date);
                gef.ShowDialog();

                GroupClass.GetGroupList();
                dataGridView1.DataSource = GroupClass.dtGroup;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch
            {
                MessageBox.Show(
                "Не удалось отредактировать группу.\r\n\r\n" +
                "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.ForeColor = System.Drawing.Color.Black;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = System.Drawing.Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GroupClass.GetGroupList();
            dataGridView1.DataSource = GroupClass.dtGroup;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string kurs = comboBox1.Text;

            GroupClass.GetGroupListSorted(kurs);
            dataGridView1.DataSource = GroupClass.dtGroup;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GroupClass.GetGroupList();
            dataGridView1.DataSource = GroupClass.dtGroup;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                System.Windows.Forms.MessageBox.Show(
                "Ошибка при получении фильтрации списка групп. \r\n\r\nНачальная дата не может быть больше конечной!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                GroupClass.GetGroupList();
                dataGridView1.DataSource = GroupClass.dtGroup;

                return;
            }

            string date_ot = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string date_do = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            GroupClass.GetGroupListSortedByDate(date_ot, date_do);
            dataGridView1.DataSource = GroupClass.dtGroup;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            button11.ForeColor = System.Drawing.Color.Black;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.ForeColor = System.Drawing.Color.White;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string teacher = comboBox2.Text;

            GroupClass.GetGroupListSortedByTeacher(teacher);
            dataGridView1.DataSource = GroupClass.dtGroup;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            GroupClass.GetGroupList();
            dataGridView1.DataSource = GroupClass.dtGroup;
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
            GroupClass.GetGroupListForWord();
            var dt = GroupClass.dtGroupWord;

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
            string templateRelativePath = @"Docs_Template\[TEMPLATE] Group_list.docx";
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
                table.Cell(tableRowIndex, 2).Range.Text = row["название_группы"].ToString();
                table.Cell(tableRowIndex, 3).Range.Text = row["название_курса"].ToString();
                table.Cell(tableRowIndex, 4).Range.Text = row["вычтенные_часы"].ToString();
                table.Cell(tableRowIndex, 5).Range.Text = row["всего_часов"].ToString();

                // Выравнивание по центру для номера
                table.Cell(tableRowIndex, 1).Range.ParagraphFormat.Alignment = 
                Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }*/

            // Заполняем таблицу данными и выделяем желтым
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                int tableRowIndex = startRow + i;

                // № п/п
                var cell1 = table.Cell(tableRowIndex, 1);
                cell1.Range.Text = (i + 1).ToString();
                cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cell1.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;

                // название_группы
                var cell2 = table.Cell(tableRowIndex, 2);
                cell2.Range.Text = row["название_группы"].ToString();
                cell2.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;

                // название_курса
                var cell3 = table.Cell(tableRowIndex, 3);
                cell3.Range.Text = row["название_курса"].ToString();
                cell3.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;

                // вычтенные_часы
                var cell4 = table.Cell(tableRowIndex, 4);
                cell4.Range.Text = row["вычтенные_часы"].ToString();
                cell4.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;

                // всего_часов
                var cell5 = table.Cell(tableRowIndex, 5);
                cell5.Range.Text = row["всего_часов"].ToString();
                cell5.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;
            }

            string manager_fio = MyClass.DocumentsClass.GetFioManager();
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("d MMMM yyyy 'года'", new CultureInfo("ru-RU"));

            /*doc.Bookmarks["FioManager"].Range.Text = MyClass.DocumentsClass.GetInitials(manager_fio);
            doc.Bookmarks["TodayDate"].Range.Text = formattedDate;*/
            DocumentsClass.InsertTextWithHighlight(doc, "FioManager", MyClass.DocumentsClass.GetInitials(manager_fio));
            DocumentsClass.InsertTextWithHighlight(doc, "TodayDate", formattedDate);


            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string fileName = $"Groups_{currentDate}.docx";
            // Создаем диалог сохранения файла
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Сохранить список групп как";
                saveFileDialog.Filter = "Документы Word (*.docx)|*.docx|Все файлы (*.*)|*.*";
                saveFileDialog.FileName = fileName;
                saveFileDialog.InitialDirectory = baseDirectory;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Сохраняем документ по выбранному пользователем пути
                        doc.SaveAs2(saveFileDialog.FileName);

                        MessageBox.Show($"Список групп сохранён! \r\n\r\nРасположение файла: {saveFileDialog.FileName}",
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

        private void GroupForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для получения списка групп по определенному курсу, необходимо:
            1) Выбрать курс в соответствующем выпадающем списке
            2) Нажать на кнопку 'Вывести'
            3) Для получения общего списка групп, нажмите 'Сбросить'

            Для получения списка групп, проходящих обучение в определенный период, нужно:
            1) Указать начальную дату
            2) Указать конечную дату
            3) Нажать на кнопку 'Вывести'
            4) Для получения общего списка групп, нажмите 'Сбросить'

            Для получения списка групп по закрепленному преподавателю, необходимо:
            1) Выбрать ФИО преподавателя в соответствующем выпадающем списке
            2) Нажать на кнопку 'Вывести'
            3) Для получения общего списка групп, нажмите 'Сбросить'";

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

        private void button13_Click(object sender, EventArgs e)
        {
            string group_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            StudentsInGroupClass.GetStudentInGroupList(group_name);
            var dt = StudentsInGroupClass.dtStudentsInGroup;

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
            string templateRelativePath = @"Docs_Template\[TEMPLATE] Prikaz_o_zachislenii.docx";
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

            int startRow = 1; // начинаем с первой строки, т.к. заголовка нет

            int rowsNeeded = dt.Rows.Count;
            int existingRows = table.Rows.Count; // считаем все строки в таблице

            // Добавляем строки, если их меньше, чем нужно
            if (rowsNeeded > existingRows)
            {
                for (int i = 0; i < rowsNeeded - existingRows; i++)
                {
                    table.Rows.Add();
                }
            }

            // Заполняем единственный столбец данными из первого столбца dt
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int tableRowIndex = startRow + i;

                var cell = table.Cell(tableRowIndex, 1); // единственный столбец - 1
                var value = dt.Rows[i][0]?.ToString() ?? ""; // берем значение из первого столбца DataTable

                cell.Range.Text = value;

                // При необходимости можно добавить форматирование, например, выделить желтым:
                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;
            }


            string manager_fio = MyClass.DocumentsClass.GetFioManager();
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("d MMMM yyyy 'года'", new CultureInfo("ru-RU"));

            string owner = "Мильруд Евгений Александрович";
            string kurs = dataGridView1.CurrentRow.Cells["KURS"].Value.ToString();

            string start_date = dataGridView1.CurrentRow.Cells["Start"].Value.ToString();
            DateTime startDateTime = DateTime.Parse(start_date);
            string formattedDate2 = startDateTime.ToString("d MMMM yyyy 'года'", new CultureInfo("ru-RU"));

            /*doc.Bookmarks["РегДата1"].Range.Text = formattedDate;
            doc.Bookmarks["Организация1"].Range.Text = "ООО «Корунд»";
            doc.Bookmarks["Организация3"].Range.Text = "ООО «Корунд»";
            doc.Bookmarks["ОргПодписантДолж1"].Range.Text = "Управляющий индивидуальный предприниматель";
            doc.Bookmarks["ОргПодписантФИО1"].Range.Text = MyClass.DocumentsClass.GetInitials(owner);
            doc.Bookmarks["РегНомер1"].Range.Text = MyClass.DocumentsClass.GetGroupId(group_name);
            doc.Bookmarks["ГруппаНомер1"].Range.Text = group_name;
            doc.Bookmarks["НаимОбрПрогр1"].Range.Text = kurs;
            doc.Bookmarks["ГруппаНомер2"].Range.Text = group_name;
            doc.Bookmarks["НаимОбрПрогр2"].Range.Text = kurs;
            doc.Bookmarks["ОбрПрогрДлит1"].Range.Text = MyClass.DocumentsClass.GetKursHours(kurs);
            doc.Bookmarks["НачОбуч1"].Range.Text = formattedDate2;*/
            DocumentsClass.InsertTextWithHighlight(doc, "РегДата1", formattedDate);
            DocumentsClass.InsertTextWithHighlight(doc, "Организация1", "ООО «Корунд»");
            DocumentsClass.InsertTextWithHighlight(doc, "Организация3", "ООО «Корунд»");
            DocumentsClass.InsertTextWithHighlight(doc, "ОргПодписантДолж1", "Управляющий индивидуальный предприниматель");
            DocumentsClass.InsertTextWithHighlight(doc, "ОргПодписантФИО1", MyClass.DocumentsClass.GetInitials(owner));
            DocumentsClass.InsertTextWithHighlight(doc, "РегНомер1", MyClass.DocumentsClass.GetGroupId(group_name));
            DocumentsClass.InsertTextWithHighlight(doc, "ГруппаНомер1", group_name);
            DocumentsClass.InsertTextWithHighlight(doc, "НаимОбрПрогр1", kurs);
            DocumentsClass.InsertTextWithHighlight(doc, "ГруппаНомер2", group_name);
            DocumentsClass.InsertTextWithHighlight(doc, "НаимОбрПрогр2", kurs);
            DocumentsClass.InsertTextWithHighlight(doc, "ОбрПрогрДлит1", MyClass.DocumentsClass.GetKursHours(kurs));
            DocumentsClass.InsertTextWithHighlight(doc, "НачОбуч1", formattedDate2);

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string fileName = $"Prikaz_o_zachislenii_{group_name}_{currentDate}.docx";
            // Создаем диалог сохранения файла
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Сохранить список групп как";
                saveFileDialog.Filter = "Документы Word (*.docx)|*.docx|Все файлы (*.*)|*.*";
                saveFileDialog.FileName = fileName;
                saveFileDialog.InitialDirectory = baseDirectory;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Сохраняем документ по выбранному пользователем пути
                        doc.SaveAs2(saveFileDialog.FileName);

                        MessageBox.Show($"Список групп сохранён! \r\n\r\nРасположение файла: {saveFileDialog.FileName}",
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

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.ForeColor = System.Drawing.Color.Black;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.ForeColor = System.Drawing.Color.White;
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            button13.ForeColor = System.Drawing.Color.Black;
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {
            button13.ForeColor = System.Drawing.Color.White;
        }
    }
}
