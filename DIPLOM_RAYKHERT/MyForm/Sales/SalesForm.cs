using DIPLOM_RAYKHERT.MyClass;
using DIPLOM_RAYKHERT.MyForm.Price;
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
using System.Windows.Forms.DataVisualization.Charting;
using Word = Microsoft.Office.Interop.Word;

namespace DIPLOM_RAYKHERT.MyForm.Sales
{
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += SalesForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            MyClass.SalesClass.GetSalesList();
            dataGridView1.DataSource = SalesClass.dtSales;
            Graphic();

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void Graphic()
        {
            // Получить данные из БД
            SalesClass.GetSalesStat();
            System.Data.DataTable data = SalesClass.dtSalesStat; // Реализуйте метод для получения данных из БД
            // Очистить существующий чарт
            chart1.Series.Clear();
            chart1.Titles.Clear();
            // Добавить серию
            System.Windows.Forms.DataVisualization.Charting.Series series = 
                new System.Windows.Forms.DataVisualization.Charting.Series("Sales");
            series.ChartType = SeriesChartType.Pie;
            series.Label = "#VALY"; // Отображать значение (цену) на диаграмме
            // Добавить данные в серию
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row = data.Rows[i];
                series.Points.AddXY("", Convert.ToDouble(row["total_sales"])); // Не использовать название курса
                series.Points[i].LegendText = row["course_name"].ToString(); // Установить название курса для легенды
            }
            // Добавить серию к диаграмме
            chart1.Series.Add(series);
            // Добавить заголовок к диаграмме
            chart1.Titles.Add("Общая статистика продаж курсов");
            // Обновить чарт
            chart1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesAddForm saf = new SalesAddForm();
            saf.ShowDialog();

            SalesClass.GetSalesList();
            dataGridView1.DataSource = SalesClass.dtSales;
            Graphic();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите продажу для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string id_sale = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string kurs = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string price = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string date = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                SalesEditForm sef = new SalesEditForm(id_sale, kurs, price, date);
                sef.ShowDialog();

                SalesClass.GetSalesList();
                dataGridView1.DataSource = SalesClass.dtSales;
                Graphic();
            }
            catch
            {
                MessageBox.Show(
                "Не удалось отредактировать продажу.\r\n\r\n" +
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
                MessageBox.Show("Пожалуйста, выберите продажу для удаления.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int id_sale = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить продажу?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    SalesClass.DelSale(id_sale);
                    SalesClass.GetSalesList();
                    dataGridView1.DataSource = SalesClass.dtSales;
                    Graphic();
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось удалить продажу.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }                
            }
        }

        private void button9_Enter(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                System.Windows.Forms.MessageBox.Show(
                "Ошибка при фильтрации продаж. \r\n\r\nНачальная дата не может быть больше конечной!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                SalesClass.GetSalesList();
                dataGridView1.DataSource = SalesClass.dtSales;

                return;
            }

            string date_ot = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string date_do = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            SalesClass.GetSalesListSorted(date_ot, date_do);
            dataGridView1.DataSource = SalesClass.dtSales;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SalesClass.GetSalesList();
            dataGridView1.DataSource = SalesClass.dtSales;
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
            string date_ot = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string date_do = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            SalesClass.GetSaleStatForWord(date_ot, date_do);
            var dt = SalesClass.dtSaleStatWord;

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для формирования отчета.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var app = new Microsoft.Office.Interop.Word.Application();
            app.Visible = false;

            string baseDirectory = Environment.CurrentDirectory;
            string templateRelativePath = @"Docs_Template\[TEMPLATE] Sales.docx";
            string templateFullPath = Path.GetFullPath(Path.Combine(baseDirectory, templateRelativePath));

            if (!File.Exists(templateFullPath))
            {
                MessageBox.Show($"Шаблон не найден по пути: {templateFullPath}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Создаем новый документ на основе шаблона, шаблон останется неизменным
            var doc = app.Documents.Add(templateFullPath);
            doc.Activate();

            // Предположим, что таблица для данных — первая таблица в документе
            Word.Table table = doc.Tables[1];

            int startRow = 2; // Начинаем со второй строки (первая — заголовок)

            // Проверяем, достаточно ли строк в таблице, если нет — добавляем
            int rowsNeeded = SalesClass.dtSaleStatWord.Rows.Count;
            int existingRows = table.Rows.Count - 1; // без заголовка

            if (rowsNeeded > existingRows)
            {
                for (int i = 0; i < rowsNeeded - existingRows; i++)
                {
                    table.Rows.Add();
                }
            }

            // Заполняем данные начиная со второй строки
            /*for (int i = 0; i < SalesClass.dtSaleStatWord.Rows.Count; i++)
            {
                var row = SalesClass.dtSaleStatWord.Rows[i];
                int tableRowIndex = startRow + i;

                table.Cell(tableRowIndex, 1).Range.Text = (i + 1).ToString(); // № п/п
                table.Cell(tableRowIndex, 2).Range.Text = row["Название_курса"].ToString();
                table.Cell(tableRowIndex, 3).Range.Text = row["Число_продаж"].ToString();
                table.Cell(tableRowIndex, 4).Range.Text = row["Цена_курса"].ToString();
                table.Cell(tableRowIndex, 5).Range.Text = row["Итого"].ToString();

                // Можно добавить выравнивание, форматирование и т.п.
                table.Cell(tableRowIndex, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(tableRowIndex, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(tableRowIndex, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(tableRowIndex, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }*/
            for (int i = 0; i < SalesClass.dtSaleStatWord.Rows.Count; i++)
            {
                var row = SalesClass.dtSaleStatWord.Rows[i];
                int tableRowIndex = startRow + i;

                var cell1 = table.Cell(tableRowIndex, 1);
                cell1.Range.Text = (i + 1).ToString();
                cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cell1.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;

                var cell2 = table.Cell(tableRowIndex, 2);
                cell2.Range.Text = row["Название_курса"].ToString();
                cell2.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;

                var cell3 = table.Cell(tableRowIndex, 3);
                cell3.Range.Text = row["Число_продаж"].ToString();
                cell3.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cell3.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;

                var cell4 = table.Cell(tableRowIndex, 4);
                cell4.Range.Text = row["Цена_курса"].ToString();
                cell4.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cell4.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;

                var cell5 = table.Cell(tableRowIndex, 5);
                cell5.Range.Text = row["Итого"].ToString();
                cell5.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cell5.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;
            }

            // Подсчёт итогов
            int totalSalesCount = 0;
            decimal totalSum = 0m;

            for (int i = 0; i < SalesClass.dtSaleStatWord.Rows.Count; i++)
            {
                var row = SalesClass.dtSaleStatWord.Rows[i];

                // Суммируем число продаж
                if (int.TryParse(row["Число_продаж"].ToString(), out int salesCount))
                    totalSalesCount += salesCount;

                // Суммируем итоговую сумму
                if (decimal.TryParse(row["Итого"].ToString(), out decimal sum))
                    totalSum += sum;
            }

            // Добавляем итоговую строку в таблицу
            int totalRowIndex = startRow + SalesClass.dtSaleStatWord.Rows.Count;

            table.Rows.Add(); // добавляем новую строку

            // Заполняем ячейки итоговой строки
            table.Cell(totalRowIndex, 1).Range.Text = ""; // Пусто или можно написать "Итого"
            table.Cell(totalRowIndex, 2).Range.Text = "Итого:";
            table.Cell(totalRowIndex, 3).Range.Text = totalSalesCount.ToString();
            table.Cell(totalRowIndex, 4).Range.Text = ""; // Цена в итогах обычно не показывают
            table.Cell(totalRowIndex, 5).Range.Text = totalSum.ToString("F2"); // Формат с 2 знаками после запятой

            // Форматируем итоговую строку (жирный шрифт, выравнивание)
            /*for (int c = 2; c <= 5; c++)
            {
                table.Cell(totalRowIndex, c).Range.Font.Bold = 1;
                table.Cell(totalRowIndex, c).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }*/
            // Форматируем и выделяем фон
            for (int c = 2; c <= 5; c++)
            {
                var cell = table.Cell(totalRowIndex, c);
                cell.Range.Font.Bold = 1;
                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;
            }

            string manager_fio = MyClass.DocumentsClass.GetFioManager();
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("d MMMM yyyy 'года'", new CultureInfo("ru-RU"));

            /*doc.Bookmarks["DateS"].Range.Text = dateTimePicker1.Text;
            doc.Bookmarks["DatePo"].Range.Text = dateTimePicker2.Text;
            doc.Bookmarks["FioManager"].Range.Text = MyClass.DocumentsClass.GetInitials(manager_fio);
            doc.Bookmarks["TodayDate"].Range.Text = formattedDate;*/
            MyClass.DocumentsClass.InsertTextWithHighlight(doc, "DateS", dateTimePicker1.Text);
            MyClass.DocumentsClass.InsertTextWithHighlight(doc, "DatePo", dateTimePicker2.Text);
            MyClass.DocumentsClass.InsertTextWithHighlight(doc, "FioManager", MyClass.DocumentsClass.GetInitials(manager_fio));
            MyClass.DocumentsClass.InsertTextWithHighlight(doc, "TodayDate", formattedDate);

            // Диалог выбора места и имени файла для сохранения
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Сохранить статистику продаж как";
                saveFileDialog.Filter = "Документы Word (*.docx)|*.docx|Все файлы (*.*)|*.*";
                saveFileDialog.FileName = $"Sales_{date_ot}_to_{date_do}.docx";
                saveFileDialog.InitialDirectory = baseDirectory;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        doc.SaveAs2(saveFileDialog.FileName);

                        MessageBox.Show($"Статистика продаж сохранена! \r\n\r\nРасположение файла: {saveFileDialog.FileName}",
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

            doc.Close(false);
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }

        private void SalesForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для получения списка продаж за определенный период, необходимо:
            1) Указать начальную дату
            2) Указать конечную дату
            3) Нажать на кнопку 'Вывести'
            4) Для получения общего списка продаж, нажмите 'Сбросить'";

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
