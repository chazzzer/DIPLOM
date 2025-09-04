using DIPLOM_RAYKHERT.MyClass;
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

namespace DIPLOM_RAYKHERT.MyForm.Sertificat
{
    public partial class SertificatAddForm : Form
    {
        public SertificatAddForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += SertificatAddForm_KeyDown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SertificatAddForm_Load(object sender, EventArgs e)
        {
            GroupClass.GetFinishedGroupList();
            dataGridView1.DataSource = GroupClass.dtGroup;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            int rowsCount = dataGridView1.RowCount;
            if (rowsCount >= 1)
            {
                AddColumns();
                string group_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                StudentsInGroupClass.GetStudentInGroupList(group_name);
                dataGridView2.DataSource = StudentsInGroupClass.dtStudentsInGroup;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void AddColumns()
        {
            // Добавление колонки кнопки "Сформировать сертификат"
            DataGridViewButtonColumn sertColumn = new DataGridViewButtonColumn();
            sertColumn.Name = "Sert";
            sertColumn.HeaderText = "Сформировать сертификат";
            sertColumn.Text = "Сформировать сертификат";
            sertColumn.UseColumnTextForButtonValue = true;
            sertColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView2.Columns.Add(sertColumn);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string group_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            StudentsInGroupClass.GetStudentInGroupList(group_name);
            dataGridView2.DataSource = StudentsInGroupClass.dtStudentsInGroup;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["Sert"].Index)
            {
                var app = new Microsoft.Office.Interop.Word.Application();
                app.Visible = false;

                string baseDirectory = Environment.CurrentDirectory;
                string templateRelativePath = @"Docs_Template\[TEMPLATE] Sert.docx";
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

                string fio_student = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                string kurs_name = dataGridView1.CurrentRow.Cells["KURS"].Value.ToString();

                DateTime date = DateTime.Now;
                string formattedDate = date.ToString("d MMMM yyyy 'года'", new CultureInfo("ru-RU"));

                /*doc.Bookmarks["FioStudent"].Range.Text = fio_student + "\r\n";
                doc.Bookmarks["KursName"].Range.Text = kurs_name;
                doc.Bookmarks["KursHours"].Range.Text = MyClass.DocumentsClass.GetKursHours(kurs_name);
                doc.Bookmarks["Date"].Range.Text = formattedDate;*/
                MyClass.DocumentsClass.InsertTextWithHighlight(doc, "FioStudent", fio_student + "\r\n");
                MyClass.DocumentsClass.InsertTextWithHighlight(doc, "KursName", kurs_name);
                MyClass.DocumentsClass.InsertTextWithHighlight(doc, "KursHours", MyClass.DocumentsClass.GetKursHours(kurs_name));
                MyClass.DocumentsClass.InsertTextWithHighlight(doc, "Date", formattedDate);


                string fio = dataGridView2.CurrentRow.Cells["FIO"].Value.ToString();
                string kurs = dataGridView1.CurrentRow.Cells["KURS"].Value.ToString();
                // Открываем диалог сохранения файла
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Сохранить сертификат как";
                    saveFileDialog.Filter = "Документы Word (*.docx)|*.docx|Все файлы (*.*)|*.*";
                    // Предлагаем имя файла с ФИО и названием курса
                    string safeFio = string.Join("_", fio_student.Split(Path.GetInvalidFileNameChars()));
                    string safeKurs = string.Join("_", kurs_name.Split(Path.GetInvalidFileNameChars()));
                    saveFileDialog.FileName = $"Sert_{safeFio}_{safeKurs}.docx";
                    saveFileDialog.InitialDirectory = baseDirectory;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            doc.SaveAs2(saveFileDialog.FileName);

                            MessageBox.Show($"Сертификат сохранен! \r\n\r\nРасположение сертификата: {saveFileDialog.FileName}",
                                "Успешно",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            SertificatClass.AddSert(fio, kurs);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при сохранении сертификата:\r\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Сохранение сертификата отменено пользователем.",
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

        private void SertificatAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            HelpForm.hint = $@"
            Чтобы выдать сертификат, нужно:

            1) В спике групп выбрать необходимую группу
            2) Справа появится список обучающихся в этой группе
            3) Напротив необходимого обучающегося нажать на кнопку 'Выдать сертификат'";

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
