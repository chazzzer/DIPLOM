using DIPLOM_RAYKHERT.MyClass.SpravochnikClass;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace DIPLOM_RAYKHERT.MyClass
{
    public class DocumentsClass
    {
        /// <summary>
        /// получение роли пользователя
        /// </summary>
        /// <param name="fio"></param>
        /// <returns></returns>
        static public string GetRole(string fio)
        {
            try
            {
                string role = "";

                DbConnection.myCommand.CommandText = $@"select роль from с_роли, пользователи
                where пользователи.id_роли = с_роли.id_роли
                and concat(фамилия, ' ', имя, ' ', отчество) = '{fio}'";
                role = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                return role;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить роль пользователя.\r\n" +
                "Проверьте корректность введенного ФИО, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return "[ОШИБКА ПРИ ПОЛУЧЕНИИ РОЛИ]";
            }
        }

        /// <summary>
        /// получение название курса
        /// </summary>
        /// <param name="id_dogovor"></param>
        /// <returns></returns>
        static public string GetKurs(int id_dogovor)
        {
            try
            {
                string kurs = "";

                DbConnection.myCommand.CommandText = $@"select название from курсы,договоры,заявка_на_обучение
                where договоры.id_заявки_на_обучение = заявка_на_обучение.id_заявки_на_обучение
                and заявка_на_обучение.id_курса = курсы.id_курса
                and id_договора = '{id_dogovor}'";
                kurs = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                return kurs;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить название курса.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return "[ОШИБКА ПРИ ПОЛУЧЕНИИ НАЗВАНИЯ КУРСА]";
            }
        }

        /// <summary>
        /// получение эл почты обучающегося
        /// </summary>
        /// <param name="id_dogovora"></param>
        /// <returns></returns>
        static public string GetEmail(int id_dogovora)
        {
            try
            {
                string email = "";

                DbConnection.myCommand.CommandText = $@"select id_обучающегося from заявка_на_обучение, договоры
                where договоры.id_заявки_на_обучение = заявка_на_обучение.id_заявки_на_обучение
                and id_договора = '{id_dogovora}'";
                int id_student = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"select email from обучающиеся 
                where id_обучающегося = '{id_student}'";
                email = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                return email;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить электронную почту обучающегося.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return "[ОШИБКА ПРИ ПОЛУЧЕНИИ EMAIL]";
            }
        }

        /// <summary>
        /// получение номера телефона обучающегося
        /// </summary>
        /// <param name="id_dogovora"></param>
        /// <returns></returns>
        static public string GetPhone(int id_dogovora)
        {
            try
            {
                string phone = "";

                DbConnection.myCommand.CommandText = $@"select id_обучающегося from заявка_на_обучение, договоры
                where договоры.id_заявки_на_обучение = заявка_на_обучение.id_заявки_на_обучение
                and id_договора = '{id_dogovora}'";
                int id_student = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"select телефон from обучающиеся 
                where id_обучающегося = '{id_student}'";
                phone = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                return phone;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить номер телефона обучающегося.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return "[ОШИБКА ПРИ ПОЛУЧЕНИИ НОМЕРА ТЕЛЕФОНА]";
            }
        }

        /// <summary>
        /// получение инициалов
        /// </summary>
        /// <param name="fio"></param>
        /// <returns></returns>
        static public string GetInitials(string fio)
        {
            try
            {
                string initials = "";

                // Разделяем ФИО
                var parts = fio.Split(' ');

                if (parts.Length >= 3)
                {
                    string lastName = parts[0];
                    string firstName = parts[1];
                    string middleName = parts[2];

                    // Формируем инициалы
                    initials = $"{lastName} {firstName[0]}. {middleName[0]}.";
                }
                else
                {
                    MessageBox.Show($"Некорректный формат ФИО!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                return initials;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить иницалы.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return "[ОШИБКА ПРИ ПОЛУЧЕНИИ ИНИЦИАЛОВ]";
            }
        }

        /// <summary>
        /// получение кол-ва часов курса
        /// </summary>
        /// <param name="kurs"></param>
        /// <returns></returns>
        static public string GetKursHours(string kurs)
        {
            try
            {
                string hours = "";

                DbConnection.myCommand.CommandText = $@"select длительность_ч from курсы 
                where название = '{kurs}'";
                hours = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                return hours;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить количество часов курса.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return "[ОШИБКА ПРИ ПОЛУЧЕНИИ КОЛИЧЕСТВА ЧАСОВ КУРСА]";
            }
        }

        /// <summary>
        /// получение фио менеджера
        /// </summary>
        /// <returns></returns>
        static public string GetFioManager()
        {
            try
            {
                string fio = "";

                DbConnection.myCommand.CommandText = $@"select concat(фамилия, ' ', имя, ' ', отчество)
                from пользователи where логин = '{DbConnection.user}'";
                fio = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                return fio;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить ФИО менеджера.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return "[ОШИБКА ПРИ ПОЛУЧЕНИИ ФИО МЕНЕДЖЕРА]";
            }
        }

        static public void InsertTextWithHighlight(Word.Document doc, string bookmarkName, string text)
        {
            if (doc.Bookmarks.Exists(bookmarkName))
            {
                Word.Range range = doc.Bookmarks[bookmarkName].Range;
                range.Text = text;

                // Восстанавливаем закладку, т.к. после вставки текста она удаляется
                object rangeStart = range.Start;
                object rangeEnd = range.Start + text.Length;
                doc.Bookmarks.Add(bookmarkName, doc.Range(ref rangeStart, ref rangeEnd));

                // Выделяем фон желтым
                range.Shading.BackgroundPatternColor = Word.WdColor.wdColorYellow;
            }
        }

        static public string GetGroupId(string group_name)
        {
            try
            {
                string id = "";

                DbConnection.myCommand.CommandText = $@"select id_группы from группы where название_группы = '{group_name}'";
                id = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                return id;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить порядковый номер группы.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return "[ОШИБКА]";
            }
        }
    }
}
