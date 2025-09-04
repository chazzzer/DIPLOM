using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class TimetableClass
    {
        static public DataTable dtTimetable = new DataTable();

        /// <summary>
        /// получение расписания занятий
        /// </summary>
        static public void GetTimetableList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"
                SELECT 
                    r.id_расписание,
                    g.название_группы,
                    CONCAT(p.фамилия, ' ', p.имя, ' ', p.отчество) AS FIO,
                    r.дата_время_занятия,
                    CASE 
                        WHEN r.дата_время_занятия > NOW() THEN 
                            CONCAT(
                                TIMESTAMPDIFF(HOUR, NOW(), r.дата_время_занятия), 
                                ' час(-ов) ', 
                                TIMESTAMPDIFF(MINUTE, NOW(), r.дата_время_занятия) % 60, 
                                ' минут до начала'
                            )
                        WHEN r.дата_время_занятия <= NOW() AND r.дата_время_занятия + INTERVAL 2 HOUR > NOW() THEN 
                            CONCAT(
                                TIMESTAMPDIFF(MINUTE, r.дата_время_занятия, NOW()), 
                                ' минут с начала'
                            )
                        ELSE 'Занятие прошло'
                    END AS time_status,
                    k.номер_кабинета
                FROM 
                    расписание r
                JOIN 
                    группы g ON r.id_группы = g.id_группы
                JOIN 
                    преподаватели p ON g.id_преподавателя = p.id_преподавателя
                JOIN 
                    кабинеты k ON r.id_кабинета = k.id_кабинета
                ORDER BY r.дата_время_занятия ASC
                ";
                dtTimetable.Clear();
                DbConnection.MyDataAdapter.Fill(dtTimetable);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить расписание занятий.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление занятия
        /// </summary>
        /// <param name="group_name"></param>
        /// <param name="kab"></param>
        /// <param name="dateTimeStart"></param>
        /// <returns></returns>
        static public bool AddTimetable(string group_name, string kab, string dateTimeStart)
        {
            try
            {
                DateTime date = DateTime.Parse(dateTimeStart);
                // Проверяем, что день недели не суббота и не воскресенье
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Нельзя назначать занятия на субботу и воскресенье!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                DateTime startOfWeek = date.AddDays(-(((int)date.DayOfWeek + 6) % 7)).Date;
                DateTime endOfWeek = startOfWeek.AddDays(6).Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                string sql = @"
                SELECT COUNT(*)
                FROM расписание r
                JOIN группы g ON r.id_группы = g.id_группы
                WHERE r.дата_время_занятия BETWEEN @startOfWeek AND @endOfWeek
                  AND g.название_группы = @groupName";

                DbConnection.myCommand.CommandText = sql;
                DbConnection.myCommand.Parameters.Clear();
                DbConnection.myCommand.Parameters.AddWithValue("@startOfWeek", startOfWeek);
                DbConnection.myCommand.Parameters.AddWithValue("@endOfWeek", endOfWeek);
                DbConnection.myCommand.Parameters.AddWithValue("@groupName", group_name);

                int count = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                if (count >= 2)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Ошибка при назначении занятия.\r\n\r\n" +
                        "Количество занятий на неделе у одной группы не может быть больше 2-х!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"select id_преподавателя
                from группы
                where название_группы = '{group_name}'";
                int id_teacher_gruppi = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                // --- Новая проверка: есть ли занятия преподавателя в интервале ±2 часа от нового занятия ---
                DbConnection.myCommand.CommandText = $@"
                SELECT COUNT(*) 
                FROM расписание r
                JOIN группы g ON r.id_группы = g.id_группы
                WHERE g.id_преподавателя = {id_teacher_gruppi}
                  AND ABS(TIMESTAMPDIFF(MINUTE, r.дата_время_занятия, '{dateTimeStart}')) < 120";
                int conflictCount = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                if (conflictCount > 0)
                {
                    DbConnection.myCommand.CommandText = $@"
                    select CONCAT(фамилия, ' ', имя, ' ', отчество)
                    from преподаватели
                    where id_преподавателя = {id_teacher_gruppi}";
                    string FIO = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                    System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при назначении занятия.\r\n\r\n" +
                        $"У преподавателя {FIO} уже есть занятие менее чем за 2 часа от указанного времени.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                // --- Конец новой проверки ---

                DbConnection.myCommand.CommandText = $@"
                SELECT 
                        r.id_расписание
                    FROM 
                        расписание r
                    JOIN 
                        группы g ON r.id_группы = g.id_группы
                    JOIN 
                преподаватели p ON g.id_преподавателя = p.id_преподавателя
    
                where p.id_преподавателя = '{id_teacher_gruppi}' and r.дата_время_занятия = '{dateTimeStart}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    DbConnection.myCommand.CommandText = $@"
                    select 
                        CONCAT(преподаватели.фамилия, ' ', преподаватели.имя, ' ', преподаватели.отчество)
                    from преподаватели
                    where id_преподавателя = '{id_teacher_gruppi}'";
                    string FIO = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                    System.Windows.Forms.MessageBox.Show(
                    $"Ошибка при назначении занятия. \r\n\r\nДанную группу ведет преподаватель {FIO}. " +
                    $" У него(неё) уже имеется занятие в данную дату и время.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"select id_расписание from расписание
                where id_кабинета = (select id_кабинета from кабинеты where номер_кабинета = '{kab}')
                and дата_время_занятия = '{dateTimeStart}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    DbConnection.myCommand.CommandText = $@"select название_группы 
                    from группы, расписание, кабинеты
                    where расписание.id_группы = группы.id_группы and расписание.id_кабинета = кабинеты.id_кабинета
                    and расписание.id_кабинета = (select id_кабинета from кабинеты where номер_кабинета = '{kab}')
                    and расписание.дата_время_занятия = '{dateTimeStart}'";
                    string group = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                    System.Windows.Forms.MessageBox.Show(
                    $"Ошибка при назначении занятия. \r\n\r\nДля группы {group} в это же время назначено" +
                    $" занятие в кабинете {kab}.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                // --- Проверка наличия необходимого ПО для курса в кабинете ---
                // Получаем id_курса по названию группы (предполагается, что поле id_курса есть в таблице группы)
                DbConnection.myCommand.CommandText = $@"
                SELECT id_курса
                FROM группы
                WHERE название_группы = '{group_name}'";
                object courseIdObj = DbConnection.myCommand.ExecuteScalar();
                if (courseIdObj == null)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Не удалось определить курс для группы.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                int courseId = Convert.ToInt32(courseIdObj);

                // Получаем id_кабинета по номеру кабинета
                DbConnection.myCommand.CommandText = @"
                SELECT id_кабинета
                FROM кабинеты
                WHERE номер_кабинета = @cabinetNumber";
                DbConnection.myCommand.Parameters.Clear();
                DbConnection.myCommand.Parameters.AddWithValue("@cabinetNumber", kab);
                object cabinetIdObj = DbConnection.myCommand.ExecuteScalar();
                if (cabinetIdObj == null)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Не удалось определить кабинет по номеру.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                int cabinetId = Convert.ToInt32(cabinetIdObj);

                // Получаем список id_по, необходимого для курса
                DbConnection.myCommand.CommandText = @"
                SELECT id_по
                FROM ПО_для_курса
                WHERE id_курса = @CourseId";
                DbConnection.myCommand.Parameters.Clear();
                DbConnection.myCommand.Parameters.AddWithValue("@CourseId", courseId);
                var requiredSoft = new List<int>();
                using (var reader = DbConnection.myCommand.ExecuteReader())
                {
                    while (reader.Read())
                        requiredSoft.Add(reader.GetInt32(0));
                }

                // Получаем список id_по, установленного в кабинете
                DbConnection.myCommand.CommandText = @"
                SELECT id_по
                FROM ПО_в_кабинете
                WHERE id_кабинета = @CabinetId";
                DbConnection.myCommand.Parameters.Clear();
                DbConnection.myCommand.Parameters.AddWithValue("@CabinetId", cabinetId);
                var installedSoft = new HashSet<int>();
                using (var reader = DbConnection.myCommand.ExecuteReader())
                {
                    while (reader.Read())
                        installedSoft.Add(reader.GetInt32(0));
                }

                // Проверяем, что все необходимые ПО установлены
                foreach (var softwareId in requiredSoft)
                {
                    if (!installedSoft.Contains(softwareId))
                    {
                        System.Windows.Forms.MessageBox.Show(
                            "В кабинете не установлено необходимое программное обеспечение для изучения курса.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                }
                // --- Конец проверки ПО ---

                DbConnection.myCommand.CommandText = $@"select осталось_часов from группы where 
                название_группы = '{group_name}'";
                int currentHours = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                if (currentHours == 0)
                {
                    System.Windows.Forms.MessageBox.Show(
                    $"Ошибка при назначении занятия. \r\n\r\nУ этой группы вычтены все часы.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"update группы set осталось_часов = {currentHours - 2}
                where название_группы = '{group_name}'";
                DbConnection.myCommand.ExecuteNonQuery();

                DbConnection.myCommand.CommandText = $@"insert into расписание values(null, 
                (select id_группы from группы where название_группы = '{group_name}'), 
                (select id_кабинета from кабинеты where номер_кабинета = '{kab}'),
                '{dateTimeStart}')";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Занятие назначено!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить занятие.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление занятия
        /// </summary>
        /// <param name="id_timetable"></param>
        /// <param name="start"></param>
        /// <param name="group_name"></param>
        /// <returns></returns>
        static public bool DelTimetable(int id_timetable, DateTime start, string group_name)
        {
            try
            {
                // Получение текущего времени
                DateTime currentTime = DateTime.Now;
                if (start > currentTime)
                {
                    DbConnection.myCommand.CommandText = $@"select осталось_часов from группы where 
                    название_группы = '{group_name}'";
                    int currentHours = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                    DbConnection.myCommand.CommandText = $@"update группы set осталось_часов = {currentHours + 2}
                    where название_группы = '{group_name}'";
                    DbConnection.myCommand.ExecuteNonQuery();
                }

                DbConnection.myCommand.CommandText = $@"delete from расписание where id_расписание = '{id_timetable}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Занятие отменено!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось отменить занятие.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование занятия
        /// </summary>
        /// <param name="id_tt"></param>
        /// <param name="new_group_name"></param>
        /// <param name="new_kab"></param>
        /// <param name="new_dateTimeStart"></param>
        /// <param name="old_group_name"></param>
        /// <returns></returns>
        static public bool EditTimetable(string id_tt, string new_group_name, string new_kab, string new_dateTimeStart,
            string old_group_name)
        {
            try
            {
                DateTime date = DateTime.Parse(new_dateTimeStart);
                // Проверяем, что день недели не суббота и не воскресенье
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Нельзя назначать занятия на субботу и воскресенье!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                // Вычисляем понедельник текущей недели
                DateTime startOfWeek = date.AddDays(-(((int)date.DayOfWeek + 6) % 7)).Date;

                // Конец недели — воскресенье 23:59:59
                DateTime endOfWeek = startOfWeek.AddDays(6).Date.AddDays(1).AddTicks(-1);

                string sql = @"
                SELECT COUNT(*)
                FROM расписание r
                JOIN группы g ON r.id_группы = g.id_группы
                WHERE r.дата_время_занятия BETWEEN @startOfWeek AND @endOfWeek
                  AND g.название_группы = @groupName";

                DbConnection.myCommand.CommandText = sql;

                // Очищаем параметры, если нужно
                DbConnection.myCommand.Parameters.Clear();

                // Добавляем параметры
                DbConnection.myCommand.Parameters.AddWithValue("@startOfWeek", startOfWeek);
                DbConnection.myCommand.Parameters.AddWithValue("@endOfWeek", endOfWeek);
                DbConnection.myCommand.Parameters.AddWithValue("@groupName", new_group_name);

                int count = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                if (count >= 2)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Ошибка при изменении занятия.\r\n\r\n" +
                        "Количество занятий на неделе у одной группы не может быть больше 2-х!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"select id_преподавателя
                from группы
                where название_группы = '{new_group_name}'";
                int id_teacher_gruppi = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                // --- Новая проверка: есть ли занятия преподавателя в интервале ±2 часа от нового занятия ---
                DbConnection.myCommand.CommandText = $@"
                SELECT COUNT(*) 
                FROM расписание r
                JOIN группы g ON r.id_группы = g.id_группы
                WHERE g.id_преподавателя = {id_teacher_gruppi}
                  AND ABS(TIMESTAMPDIFF(MINUTE, r.дата_время_занятия, '{new_dateTimeStart}')) < 120";
                int conflictCount = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                if (conflictCount > 0)
                {
                    DbConnection.myCommand.CommandText = $@"
                    select CONCAT(фамилия, ' ', имя, ' ', отчество)
                    from преподаватели
                    where id_преподавателя = {id_teacher_gruppi}";
                    string FIO = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                    System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при изменении занятия.\r\n\r\n" +
                        $"У преподавателя {FIO} уже есть занятие менее чем за 2 часа от указанного времени.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                // --- Конец новой проверки ---

                DbConnection.myCommand.CommandText = $@"select id_группы from группы where название_группы = '{new_group_name}'";
                int id_new_group = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());
                DbConnection.myCommand.CommandText = $@"select id_группы from группы where название_группы = '{old_group_name}'";
                int id_old_group = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());
                DbConnection.myCommand.CommandText = $@"select id_кабинета from кабинеты where номер_кабинета = '{new_kab}'";
                int id_new_kab = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"select id_расписание from расписание
                where id_группы = '{id_new_group}' and дата_время_занятия = '{new_dateTimeStart}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Невозможно изменить занятие.\r\n\r\n" +
                    "На указанную дату и время у этой группы уже запланировано занятие.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                if (id_new_group != id_old_group)
                {
                    DbConnection.myCommand.CommandText = $@"select осталось_часов from группы where id_группы = '{id_old_group}'";
                    int hours_oldGroup = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());
                    DbConnection.myCommand.CommandText = $@"select осталось_часов from группы where id_группы = '{id_new_group}'";
                    int hours_newGroup = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                    DbConnection.myCommand.CommandText = $@"update группы set осталось_часов = '{hours_oldGroup + 2}' where id_группы = '{id_old_group}'";
                    DbConnection.myCommand.ExecuteNonQuery();

                    DbConnection.myCommand.CommandText = $@"update группы set осталось_часов = '{hours_newGroup - 2}' where id_группы = '{id_new_group}'";
                    DbConnection.myCommand.ExecuteNonQuery();
                }

                DbConnection.myCommand.CommandText = $@"update расписание set id_группы = '{id_new_group}', id_кабинета = '{id_new_kab}',
                дата_время_занятия = '{new_dateTimeStart}'
                where id_расписание = '{id_tt}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                $"Занятие изменено!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить информацию о занятии.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
