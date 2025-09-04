using DIPLOM_RAYKHERT.MyClass;
using DIPLOM_RAYKHERT.MyForm.Dogovor;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;
using Humanizer;
using System.Globalization;

namespace DIPLOM_RAYKHERT.MyForm
{
    public partial class DogovorForm : Form
    {
        public DogovorForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += DogovorForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DogovorForm_Load(object sender, EventArgs e)
        {
            DogovorClass.GetDogovorList();
            dataGridView1.DataSource = DogovorClass.dtDogovor;
            AddColumns();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void AddColumns()
        {
            // Добавление колонки кнопки "Печать"
            DataGridViewButtonColumn printColumn = new DataGridViewButtonColumn();
            printColumn.Name = "Print";
            printColumn.HeaderText = "Сохранить";
            printColumn.Text = "Сохранить";
            printColumn.UseColumnTextForButtonValue = true;
            printColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns.Add(printColumn);
        }

        //УДАЛЕНИЕ
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите договор для расторжения.", 
                    "Внимание", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            int nomer = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Nomer"].Value.ToString());

            DialogResult result = MessageBox.Show("Вы уверены, что хотите расторгнуть договор?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    DogovorClass.DelDogovor(nomer);
                    DogovorClass.GetDogovorList();
                    dataGridView1.DataSource = DogovorClass.dtDogovor;
                }
                catch
                {
                    MessageBox.Show(
                    "Не удалось расторгнуть договор.\r\n\r\n" +
                    "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                    "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = System.Drawing.Color.Black;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = System.Drawing.Color.White;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                System.Windows.Forms.MessageBox.Show(
                "Ошибка при получении фильтрации списка договоров. \r\n\r\nНачальная дата не может быть больше конечной!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                DogovorClass.GetDogovorList();
                dataGridView1.DataSource = DogovorClass.dtDogovor;

                return;
            }

            string date_ot = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string date_do = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            DogovorClass.GetDogovorSorted(date_ot, date_do);
            dataGridView1.DataSource = DogovorClass.dtDogovor;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DogovorClass.GetDogovorList();
            dataGridView1.DataSource = DogovorClass.dtDogovor;
        }

        //РЕДАКТИРОВАНИЕ
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите договор для редактирования.", 
                    "Внимание", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string id_dogovora = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string fio = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string data_zakl = dataGridView1.CurrentRow.Cells["DATEE"].Value.ToString();
                string itogo = dataGridView1.CurrentRow.Cells["ITOGO"].Value.ToString();

                DogovorEditForm def = new DogovorEditForm(id_dogovora, fio, data_zakl, itogo);
                def.ShowDialog();

                DogovorClass.GetDogovorList();
                dataGridView1.DataSource = DogovorClass.dtDogovor;
            }
            catch
            {
                MessageBox.Show(
                "Не удалось отредактировать договор.\r\n\r\n" +
                "Возможно, отсутствует подключение к базе данных или возникли проблемы с доступом.\r\n" +
                "Проверьте подключение и обратитесь к администратору, если проблема не исчезнет.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Обработка нажатия на кнопку "Печать"
            if (e.ColumnIndex == dataGridView1.Columns["Print"].Index)
            {
                var app = new Microsoft.Office.Interop.Word.Application();
                app.Visible = false;

                string baseDirectory = Environment.CurrentDirectory;
                string templateRelativePath = @"Docs_Template\[TEMPLATE] Dogovor.docx";
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

                int id_dogovor = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string nomer_dogovora = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                string data_dogovora = dataGridView1.CurrentRow.Cells["DATEE"].Value.ToString();
                DateTime dt = DateTime.Parse(data_dogovora);
                DateTime dateOnly = dt.Date;
                string dateString = dateOnly.ToString("dd.MM.yyyy");
                DateTime date = DateTime.ParseExact(dateString, "dd.MM.yyyy", null);
                string formattedDate = date.ToString("d MMMM yyyy 'г.'", new System.Globalization.CultureInfo("ru-RU"));

                string organization = "ООО «Корунд»";
                string fio_student = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string fio_manager = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                string itogo = dataGridView1.CurrentRow.Cells["ITOGO"].Value.ToString();
                string[] parts = itogo.Split(',');
                string rub = parts[0];
                string kop = parts[1];

                // Преобразуем рубли и копейки в числа
                int rubInt = int.Parse(rub);
                int kopInt = int.Parse(kop);

                // Получаем пропись для рублей и копеек
                string rubText = rubInt.ToWords(new CultureInfo("ru-RU"));
                string kopText = kopInt.ToWords(new CultureInfo("ru-RU"));

                // Функция для правильного склонения слова (рубль, рубля, рублей и т.д.)
                string GetCurrencyWord(int number, string form1, string form2, string form5)
                {
                    number = number % 100;
                    if (number >= 11 && number <= 19)
                        return form5;
                    int i = number % 10;
                    switch (i)
                    {
                        case 1:
                            return form1;
                        case 2:
                        case 3:
                        case 4:
                            return form2;
                        default:
                            return form5;
                    }
                }

                string rubWord = GetCurrencyWord(rubInt, "рубль", "рубля", "рублей");
                string kopWord = GetCurrencyWord(kopInt, "копейка", "копейки", "копеек");

                // Формируем итоговую строку с прописью в скобках
                string k_oplate = $@"{rub} {rubWord} {kop} {kopWord} ({UppercaseFirst(rubText)} {rubWord} {kop} {kopWord})";

                // Метод для заглавной первой буквы
                string UppercaseFirst(string s)
                {
                    if (string.IsNullOrEmpty(s))
                        return string.Empty;
                    return char.ToUpper(s[0]) + s.Substring(1);
                }

                string owner = "Мильруд Евгений Александрович";

                /*doc.Bookmarks["РегНомер1"].Range.Text = nomer_dogovora;
                doc.Bookmarks["РегДата1"].Range.Text = formattedDate;
                doc.Bookmarks["Организация1"].Range.Text = organization;
                doc.Bookmarks["ОргПодписантДолж1"].Range.Text = "Управляющего индивидуального предпринимателя";
                doc.Bookmarks["ОргПодписантФИО1"].Range.Text = "Мильруда Евгения Александровича";
                doc.Bookmarks["ОргПодписантОснов1"].Range.Text = "Устава";
                doc.Bookmarks["КорНаим1"].Range.Text = fio_student;
                doc.Bookmarks["КорПодписантДолж1"].Range.Text = " обучающийся"; 
                doc.Bookmarks["КорПодписантФИО1"].Range.Text = fio_student; 
                doc.Bookmarks["КорПодписДокумент1"].Range.Text = "[ТУТ ДОЛЖНЫ БЫТЬ ПАСПОРТНЫЕ ДАННЫЕ]";
                doc.Bookmarks["НаимОбрПрогр1"].Range.Text = $@"«{MyClass.DocumentsClass.GetKurs(id_dogovor)}»";
                doc.Bookmarks["ФормаОбучения1"].Range.Text = "очная форма обучения "; 
                doc.Bookmarks["КорСлушФИО1"].Range.Text = fio_student;
                doc.Bookmarks["КорСлушЭлАдрес1"].Range.Text = MyClass.DocumentsClass.GetEmail(id_dogovor);
                doc.Bookmarks["КорСлушТел1"].Range.Text = MyClass.DocumentsClass.GetPhone(id_dogovor);
                doc.Bookmarks["ИтогДокумент1"].Range.Text = "сертификат";
                doc.Bookmarks["НаимОбрПрогр2"].Range.Text = $@"{MyClass.DocumentsClass.GetKurs(id_dogovor)}";
                doc.Bookmarks["СтоимОбуч1"].Range.Text = k_oplate;
                doc.Bookmarks["ОтвОргФИО1"].Range.Text = fio_manager;
                doc.Bookmarks["КорПодписантФИО0"].Range.Text = fio_student;
                doc.Bookmarks["КорПодписантТел1"].Range.Text = MyClass.DocumentsClass.GetPhone(id_dogovor);
                doc.Bookmarks["Организация2"].Range.Text = organization;
                doc.Bookmarks["ОргИНН1"].Range.Text = "ИНН 5190140429";
                doc.Bookmarks["ОргКПП1"].Range.Text = "КПП 519001001";
                doc.Bookmarks["ОргБанк1"].Range.Text = "МУРМАНСКОЕ ОТДЕЛЕНИЕ N8627 ПАО СБЕРБАНК";
                doc.Bookmarks["ОргРасчСчет1"].Range.Text = "40702810241000002184";
                doc.Bookmarks["ОргКорСчет1"].Range.Text = "30101810300000000615";
                doc.Bookmarks["ОргБИК1"].Range.Text = "044705615";
                doc.Bookmarks["ОргЮрАдрес1"].Range.Text = "183025, Мурманская обл, " +
                    "Мурманск г, Тарана ул, дом №10";
                doc.Bookmarks["ОргФактАдрес1"].Range.Text = "183025, Мурманская обл, " +
                    "Мурманск г, Тарана ул, дом №10";
                doc.Bookmarks["ОргТел1"].Range.Text = "442-442";
                doc.Bookmarks["ОргФакс1"].Range.Text = "+7 (8152) 400-598";
                doc.Bookmarks["ОргМэйл1"].Range.Text = "info@korund-s.ru";
                doc.Bookmarks["КорНаим2"].Range.Text = fio_student;
                doc.Bookmarks["КорТел1"].Range.Text = MyClass.DocumentsClass.GetPhone(id_dogovor);
                doc.Bookmarks["КорМэйл1"].Range.Text = MyClass.DocumentsClass.GetEmail(id_dogovor);
                doc.Bookmarks["ОргПодписантДолж3"].Range.Text = "Управляющий индивидуальный предприниматель";
                doc.Bookmarks["Организация"].Range.Text = organization;
                doc.Bookmarks["ОргПодписантФИО2"].Range.Text = MyClass.DocumentsClass.GetInitials(owner);
                doc.Bookmarks["ОргПодписантФИО3"].Range.Text = MyClass.DocumentsClass.GetInitials(fio_student);*/

                DocumentsClass.InsertTextWithHighlight(doc, "РегНомер1", nomer_dogovora);
                DocumentsClass.InsertTextWithHighlight(doc, "РегДата1", formattedDate);
                DocumentsClass.InsertTextWithHighlight(doc, "Организация1", organization);
                DocumentsClass.InsertTextWithHighlight(doc, "ОргПодписантДолж1", "Управляющего индивидуального предпринимателя");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргПодписантФИО1", "Мильруда Евгения Александровича");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргПодписантОснов1", "Устава");
                DocumentsClass.InsertTextWithHighlight(doc, "КорНаим1", fio_student);
                DocumentsClass.InsertTextWithHighlight(doc, "КорПодписантДолж1", " обучающийся");
                DocumentsClass.InsertTextWithHighlight(doc, "КорПодписантФИО1", fio_student);
                DocumentsClass.InsertTextWithHighlight(doc, "КорПодписДокумент1", "паспорта");
                DocumentsClass.InsertTextWithHighlight(doc, "НаимОбрПрогр1", $@"«{MyClass.DocumentsClass.GetKurs(id_dogovor)}»");
                DocumentsClass.InsertTextWithHighlight(doc, "ФормаОбучения1", "очная форма обучения ");
                DocumentsClass.InsertTextWithHighlight(doc, "КорСлушФИО1", fio_student);
                DocumentsClass.InsertTextWithHighlight(doc, "КорСлушЭлАдрес1", MyClass.DocumentsClass.GetEmail(id_dogovor));
                DocumentsClass.InsertTextWithHighlight(doc, "КорСлушТел1", MyClass.DocumentsClass.GetPhone(id_dogovor));
                DocumentsClass.InsertTextWithHighlight(doc, "ИтогДокумент1", "сертификат");
                DocumentsClass.InsertTextWithHighlight(doc, "НаимОбрПрогр2", $@"{MyClass.DocumentsClass.GetKurs(id_dogovor)}");
                DocumentsClass.InsertTextWithHighlight(doc, "СтоимОбуч1", k_oplate);
                DocumentsClass.InsertTextWithHighlight(doc, "ОтвОргФИО1", fio_manager);
                DocumentsClass.InsertTextWithHighlight(doc, "КорПодписантФИО0", fio_student);
                DocumentsClass.InsertTextWithHighlight(doc, "КорПодписантТел1", MyClass.DocumentsClass.GetPhone(id_dogovor));
                DocumentsClass.InsertTextWithHighlight(doc, "Организация2", organization);
                DocumentsClass.InsertTextWithHighlight(doc, "ОргИНН1", "ИНН 5190140429");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргКПП1", "КПП 519001001");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргБанк1", "МУРМАНСКОЕ ОТДЕЛЕНИЕ N8627 ПАО СБЕРБАНК");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргРасчСчет1", "40702810241000002184");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргКорСчет1", "30101810300000000615");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргБИК1", "044705615");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргЮрАдрес1", "183025, Мурманская обл, Мурманск г, Тарана ул, дом №10");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргФактАдрес1", "183025, Мурманская обл, Мурманск г, Тарана ул, дом №10");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргТел1", "442-442");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргФакс1", "+7 (8152) 400-598");
                DocumentsClass.InsertTextWithHighlight(doc, "ОргМэйл1", "info@korund-s.ru");
                DocumentsClass.InsertTextWithHighlight(doc, "КорНаим2", fio_student);
                DocumentsClass.InsertTextWithHighlight(doc, "КорТел1", MyClass.DocumentsClass.GetPhone(id_dogovor));
                DocumentsClass.InsertTextWithHighlight(doc, "КорМэйл1", MyClass.DocumentsClass.GetEmail(id_dogovor));
                DocumentsClass.InsertTextWithHighlight(doc, "ОргПодписантДолж3", "Управляющий индивидуальный предприниматель");
                DocumentsClass.InsertTextWithHighlight(doc, "Организация", organization);
                DocumentsClass.InsertTextWithHighlight(doc, "ОргПодписантФИО2", MyClass.DocumentsClass.GetInitials(owner));
                DocumentsClass.InsertTextWithHighlight(doc, "ОргПодписантФИО3", MyClass.DocumentsClass.GetInitials(fio_student));

                string safeFio = string.Join("_", fio_student.Split(Path.GetInvalidFileNameChars()));
                string dateForFileName = date.ToString("yyyy-MM-dd");
                string fileName = $"Dogovor_{safeFio}_{dateForFileName}.docx";
                // Создаем диалог сохранения файла
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Сохранить договор как";
                    saveFileDialog.Filter = "Документы Word (*.docx)|*.docx|Все файлы (*.*)|*.*";
                    saveFileDialog.FileName = fileName;
                    saveFileDialog.InitialDirectory = baseDirectory; // начальная папка

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Сохраняем документ в выбранном пользователем месте
                            doc.SaveAs2(saveFileDialog.FileName);

                            MessageBox.Show($"Договор сохранен! \r\n\r\nРасположение договора: {saveFileDialog.FileName}",
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
        }

        private void DogovorForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Для получения списка договоров за определенный период, необходимо:

            1) Указать начальную дату
            2) Указать конечную дату
            3) Нажать на кнопку 'Применить'
            4) Для получения общего списка договоров, нажмите 'Сбросить'";

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
