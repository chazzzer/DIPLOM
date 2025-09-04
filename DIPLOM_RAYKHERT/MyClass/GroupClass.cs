using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class GroupClass
    {
        static public DataTable dtGroup = new DataTable();
        static public DataTable dtGroupWord = new DataTable();

        /// <summary>
        /// получение списка групп
        /// </summary>
        static public void GetGroupList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"
                        SELECT 
                g.id_группы,
                g.название_группы,
                CONCAT(p.фамилия, ' ', p.имя, ' ', p.отчество) AS 'FIO',
                (SELECT c.название FROM курсы c WHERE c.id_курса = g.id_курса) AS 'KURS',
                g.осталось_часов,
                g.старт_обучения,
                g.окончание_обучения,
                CASE 
                    WHEN g.окончание_обучения = CURRENT_DATE THEN 'Завершается сегодня'
                    WHEN g.окончание_обучения < CURRENT_DATE THEN 'Завершено'
                    WHEN g.старт_обучения > CURRENT_DATE THEN 'Еще не началось'
                    ELSE 'Продолжается'
                END AS 'Статус обучения'
            FROM 
                группы g
            JOIN 
                преподаватели p ON g.id_преподавателя = p.id_преподавателя

                ";

                dtGroup.Clear();
                DbConnection.MyDataAdapter.Fill(dtGroup);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список групп.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка групп по учителю
        /// </summary>
        /// <param name="teacher"></param>
        static public void GetGroupListSortedByTeacher(string teacher)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"
                        SELECT 
                g.id_группы,
                g.название_группы,
                CONCAT(p.фамилия, ' ', p.имя, ' ', p.отчество) AS 'FIO',
                (SELECT c.название FROM курсы c WHERE c.id_курса = g.id_курса) AS 'KURS',
                g.осталось_часов,
                g.старт_обучения,
                g.окончание_обучения,
                CASE 
                    WHEN g.окончание_обучения = CURRENT_DATE THEN 'Завершается сегодня'
                    WHEN g.окончание_обучения < CURRENT_DATE THEN 'Завершено'
                    WHEN g.старт_обучения > CURRENT_DATE THEN 'Еще не началось'
                    ELSE 'Продолжается'
                END AS 'Статус обучения'
            FROM 
                группы g
            JOIN 
                преподаватели p ON g.id_преподавателя = p.id_преподавателя
            where concat(p.фамилия, ' ', p.имя, ' ', p.отчество) = '{teacher}'
                ";

                dtGroup.Clear();
                DbConnection.MyDataAdapter.Fill(dtGroup);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список групп по закрепленному преподавателю.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка групп по названию курса
        /// </summary>
        /// <param name="kurs"></param>
        static public void GetGroupListSorted(string kurs)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"
                        SELECT 
                g.id_группы,
                g.название_группы,
                CONCAT(p.фамилия, ' ', p.имя, ' ', p.отчество) AS 'FIO',
                (SELECT c.название FROM курсы c WHERE c.id_курса = g.id_курса) AS 'KURS',
                g.осталось_часов,
                g.старт_обучения,
                g.окончание_обучения,
                CASE 
                    WHEN g.окончание_обучения = CURRENT_DATE THEN 'Завершается сегодня'
                    WHEN g.окончание_обучения < CURRENT_DATE THEN 'Завершено'
                    WHEN g.старт_обучения > CURRENT_DATE THEN 'Еще не началось'
                    ELSE 'Продолжается'
                END AS 'Статус обучения'
            FROM 
                группы g
            JOIN 
                преподаватели p ON g.id_преподавателя = p.id_преподавателя
            where g.id_курса = (select id_курса from курсы where название = '{kurs}')
                ";

                dtGroup.Clear();
                DbConnection.MyDataAdapter.Fill(dtGroup);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список групп по названию проходимого курса.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка групп по периоду обучения
        /// </summary>
        /// <param name="date_ot"></param>
        /// <param name="date_do"></param>
        static public void GetGroupListSortedByDate(string date_ot, string date_do)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"
                        SELECT 
                g.id_группы,
                g.название_группы,
                CONCAT(p.фамилия, ' ', p.имя, ' ', p.отчество) AS 'FIO',
                (SELECT c.название FROM курсы c WHERE c.id_курса = g.id_курса) AS 'KURS',
                g.осталось_часов,
                g.старт_обучения,
                g.окончание_обучения,
                CASE 
                    WHEN g.окончание_обучения = CURRENT_DATE THEN 'Завершается сегодня'
                    WHEN g.окончание_обучения < CURRENT_DATE THEN 'Завершено'
                    WHEN g.старт_обучения > CURRENT_DATE THEN 'Еще не началось'
                    ELSE 'Продолжается'
                END AS 'Статус обучения'
            FROM 
                группы g
            JOIN 
                преподаватели p ON g.id_преподавателя = p.id_преподавателя
            where g.старт_обучения >= '{date_ot}' and g.окончание_обучения <= '{date_do}'
                ";

                dtGroup.Clear();
                DbConnection.MyDataAdapter.Fill(dtGroup);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список групп за указанный период.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка групп с законченным обучением
        /// </summary>
        static public void GetFinishedGroupList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"
                SELECT 
                    g.id_группы,
                    g.название_группы,
                    CONCAT(p.фамилия, ' ', p.имя, ' ', p.отчество) AS 'FIO',
                    (SELECT c.название FROM курсы c WHERE c.id_курса = g.id_курса) AS 'KURS',
                    g.осталось_часов,
                    g.старт_обучения,
                    g.окончание_обучения,
                    'Завершено' AS 'Статус обучения'
                FROM 
                    группы g
                JOIN 
                    преподаватели p ON g.id_преподавателя = p.id_преподавателя
                WHERE 
                    g.окончание_обучения < CURRENT_DATE
                ORDER BY 
                    g.окончание_обучения DESC;
                ";
                dtGroup.Clear();
                DbConnection.MyDataAdapter.Fill(dtGroup);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список групп, закончивших обучение.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление группы
        /// </summary>
        /// <param name="kurs"></param>
        /// <param name="teacher"></param>
        /// <param name="start_date"></param>
        /// <returns></returns>
        static public bool AddGroup(string kurs, string teacher, string start_date)
        {
            try
            {
                // Разбиваем строку на слова
                var words = kurs.Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

                // Извлекаем заглавные буквы из каждого слова
                var uppercaseLetters = words.SelectMany(word =>
                {
                    if (word.All(char.IsUpper))
                    {
                        // Если слово состоит только из заглавных букв, берем только первую букву
                        return new[] { word[0] };
                    }
                    else
                    {
                        // Иначе берем все заглавные буквы
                        return word.Where(char.IsUpper);
                    }
                });

                // Объединяем буквы в строку
                string groupName = new string(uppercaseLetters.ToArray());

                // Запрос для получения максимального номера группы с таким названием
                DbConnection.myCommand.CommandText = $@"
                    SELECT MAX(CAST(SUBSTRING_INDEX(название_группы, '-', -1) AS UNSIGNED)) 
                    FROM группы 
                    WHERE название_группы LIKE '{groupName}-%'";

                object result = DbConnection.myCommand.ExecuteScalar();

                int maxGroupNumber = result == DBNull.Value ? 0 : Convert.ToInt32(result);

                // Присваиваем новый номер
                groupName += $"-{maxGroupNumber + 1}";

                DbConnection.myCommand.CommandText = $@"select id_преподавателя from преподаватели
                where (select concat(фамилия, ' ', имя, ' ', отчество)) = '{teacher}'";
                int id_teacher = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                // Длина курса в часах
                DbConnection.myCommand.CommandText = $@"select длительность_ч from курсы where название = '{kurs}'";
                int courseDurationHours = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());
                // Количество часов в неделю
                int hoursPerWeek = 4;
                // Дата начала курса
                DateTime startDate = DateTime.ParseExact(start_date, "yyyy-MM-dd", null);
                // Рассчитываем количество недель, необходимое для завершения курса
                int weeksRequired = (int)Math.Ceiling((double)courseDurationHours / hoursPerWeek);
                // Рассчитываем дату окончания курса
                DateTime endDate = startDate.AddDays(weeksRequired * 7);

                DbConnection.myCommand.CommandText = $@"select id_курса from курсы where название = '{kurs}'";
                int id_kursa = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"insert into группы values (null,
                '{groupName}', '{id_kursa}', '{id_teacher}', '{courseDurationHours}', 
                '{start_date}', '{endDate.ToString("yyyy-MM-dd")}')";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Новая группа добавлена!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось сформировать группу.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление группы
        /// </summary>
        /// <param name="id_group"></param>
        /// <returns></returns>
        static public bool DeleteGroup(int id_group)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_группы from расписание
                where id_группы = '{id_group}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Не удалось удалить группу.\r\n" +
                    "Данная группа упоминается в расписании. Удалите информацию о встрече с данной группой " +
                    "из расписания и повторите попытку.\r\n\r\n" +
                    "Если ошибка повторяется, обратитесь к администратору системы.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"delete from обучающиеся_в_группе
                where id_группы = '{id_group}'";
                DbConnection.myCommand.ExecuteNonQuery();

                DbConnection.myCommand.CommandText = $@"delete from группы
                where id_группы = '{id_group}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Группа удалена!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить группу.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование группы
        /// </summary>
        /// <param name="id"></param>
        /// <param name="new_group_name"></param>
        /// <param name="teacher"></param>
        /// <param name="kurs"></param>
        /// <param name="start_date"></param>
        /// <param name="old_group_name"></param>
        /// <returns></returns>
        static public bool EditGroup(string id, string new_group_name, string teacher,
    string kurs, string start_date, string old_group_name)
        {
            try
            {
                // Получение длительности курса
                DbConnection.myCommand.CommandText = $@"SELECT длительность_ч FROM курсы WHERE название = '{kurs}'";
                int courseDurationHours = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                // Расчет даты окончания
                int hoursPerWeek = 4;
                DateTime startDate = DateTime.ParseExact(start_date, "yyyy-MM-dd", null);
                DateTime endDate = startDate.AddDays((int)Math.Ceiling((double)courseDurationHours / hoursPerWeek) * 7);

                // Получение ID курса
                DbConnection.myCommand.CommandText = $@"SELECT id_курса FROM курсы WHERE название = '{kurs}'";
                int id_kursa = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                if (new_group_name != old_group_name)
                {
                    // Проверка уникальности нового названия группы
                    DbConnection.myCommand.CommandText = $@"SELECT id_группы FROM группы WHERE название_группы = '{new_group_name}'";
                    if (DbConnection.myCommand.ExecuteScalar() != null)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        "Не удалось сформировать группу.\r\n" +
                        "Группа с таким названием уже существует.\r\n\r\n" +
                        "Если ошибка повторяется, обратитесь к администратору системы.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }

                    // Обновление данных группы (с изменением названия)
                    DbConnection.myCommand.CommandText = $@"
                UPDATE группы
                SET 
                    название_группы = '{new_group_name}',
                    id_курса = '{id_kursa}',
                    id_преподавателя = (SELECT id_преподавателя FROM преподаватели WHERE CONCAT(фамилия, ' ', имя, ' ', отчество) = '{teacher}'),
                    осталось_часов = '{courseDurationHours}',
                    старт_обучения = '{start_date}',
                    окончание_обучения = '{endDate:yyyy-MM-dd}'
                WHERE id_группы = '{id}'";

                    DbConnection.myCommand.ExecuteNonQuery();
                }
                else
                {
                    // Обновление данных группы (без изменения названия)
                    DbConnection.myCommand.CommandText = $@"
                UPDATE группы
                SET 
                    id_курса = '{id_kursa}',
                    id_преподавателя = (SELECT id_преподавателя FROM преподаватели WHERE CONCAT(фамилия, ' ', имя, ' ', отчество) = '{teacher}'),
                    осталось_часов = '{courseDurationHours}',
                    старт_обучения = '{start_date}',
                    окончание_обучения = '{endDate:yyyy-MM-dd}'
                WHERE id_группы = '{id}'";

                    DbConnection.myCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Группа изменена!", 
                    "Успешно", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить группу.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// получение списка групп для документа
        /// </summary>
        static public void GetGroupListForWord()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"SELECT 
                    г.название_группы,
                    к.название AS название_курса,
                    (к.длительность_ч - г.осталось_часов) AS вычтенные_часы,
                    к.длительность_ч AS всего_часов
                FROM 
                    группы г
                JOIN 
                    курсы к ON г.id_курса = к.id_курса
                WHERE 
                    г.окончание_обучения >= CURDATE()
                ORDER BY 
                    г.название_группы";
                dtGroupWord.Clear();
                DbConnection.MyDataAdapter.Fill(dtGroupWord);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список групп для документа.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

    }
}
