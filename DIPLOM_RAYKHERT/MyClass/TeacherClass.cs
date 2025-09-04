using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class TeacherClass
    {
        static public DataTable dtTeacher = new DataTable();
        static public DataTable dtTeacherFio = new DataTable();
        static public DataTable dtTeacherKurs = new DataTable();
        static public DataTable dtTeacherFioList = new DataTable();
        static public DataTable dtTeacherWord = new DataTable();

        /// <summary>
        /// получение списка преподавателей
        /// </summary>
        static public void GetTeacherList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_преподавателя, фамилия, имя, отчество, email, телефон
                from преподаватели";
                dtTeacher.Clear();
                DbConnection.MyDataAdapter.Fill(dtTeacher);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список преподавателей.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение ФИО преподавателей
        /// </summary>
        static public void GetTeacherFioList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"SELECT 
                    CONCAT(p.фамилия, ' ', p.имя, ' ', p.отчество) AS 'FIO'
                FROM 
                    преподаватели p
                ";
                dtTeacherFioList.Clear();
                DbConnection.MyDataAdapter.Fill(dtTeacherFioList);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список ФИО преподавателей.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение данных преподавателей по закрепленной группе
        /// </summary>
        /// <param name="group_name"></param>
        static public void GetTeacherListSorted(string group_name)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"SELECT 
                    p.id_преподавателя, 
                    p.фамилия, 
                    p.имя, 
                    p.отчество, 
                    p.email, 
                    p.телефон
                FROM 
                    преподаватели p
                INNER JOIN 
                    группы g ON p.id_преподавателя = g.id_преподавателя
                WHERE 
                    g.название_группы = '{group_name}';";
                dtTeacher.Clear();
                DbConnection.MyDataAdapter.Fill(dtTeacher);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить данные о преподавателе, закрепленного за данной группой.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка преподаваемых курсов у данного преподавателя
        /// </summary>
        /// <param name="id_teacher"></param>
        static public void GetTeacherKursList(int id_teacher)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select название 
                from курсы, преподаватели_курсы, преподаватели
                where курсы.id_курса = преподаватели_курсы.id_курса and преподаватели_курсы.id_преподавателя = преподаватели.id_преподавателя
                and преподаватели.id_преподавателя = '{id_teacher}'";
                dtTeacherKurs.Clear();
                DbConnection.MyDataAdapter.Fill(dtTeacherKurs);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список преподаваемых курсов у данного преподавателя.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка ФИО преподавателей, ведущих данный курс
        /// </summary>
        /// <param name="kurs"></param>
        static public void GetTeacherFio(string kurs)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"SELECT 
                    CONCAT(p.фамилия, ' ', p.имя, ' ', p.отчество) AS 'FIO'
                FROM 
                    преподаватели p
                JOIN 
                    преподаватели_курсы pc ON p.id_преподавателя = pc.id_преподавателя
                JOIN 
                    курсы c ON pc.id_курса = c.id_курса
                WHERE 
                    c.название = '{kurs}'
                ";
                dtTeacherFio.Clear();
                DbConnection.MyDataAdapter.Fill(dtTeacherFio);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список ФИО преподавателей, ведущих данный курс.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление преподавателя
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="lastName"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        static public bool AddTeacher(string name, string surname, string lastName, string phone, string email)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_преподавателя from преподаватели where телефон = '{phone}'";
                //если чел с таким номером телефона уже существует
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении преподавателя. \r\n\r\nЧеловек с таким номером телефона уже существует в базе.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"select id_преподавателя from преподаватели where email = '{email}'";
                //если чел с таким email уже существует
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении преподавателя. \r\n\r\nЧеловек с таким адресом электронной почты уже существует в базе.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"insert into преподаватели values (null, 
                '{surname}', '{name}', '{lastName}', 
                    '{email}', '{phone}')";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Преподаватель добавлен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить преподавателя.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование преподавателя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="lastName"></param>
        /// <param name="new_phone"></param>
        /// <param name="new_email"></param>
        /// <param name="old_phone"></param>
        /// <param name="old_email"></param>
        /// <returns></returns>
        static public bool EditTeacher(int id, string name, string surname, string lastName, string new_phone, string new_email,
            string old_phone, string old_email)
        {
            try
            {
                if (new_phone != old_phone)
                {
                    //проверка уникальности нового номера
                    DbConnection.myCommand.CommandText = $@"select id_преподавателя from преподаватели where телефон = '{new_phone}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при редактировании преподавателя. \r\n\r\nЧеловек с таким номером телефона уже есть в базе.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (new_email != old_email)
                {
                    //проверка уникальности нового емайла
                    DbConnection.myCommand.CommandText = $@"select id_преподавателя from преподаватели where email = '{new_email}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при редактировании преподавателя. \r\n\r\nЧеловек с таким адресом электронной почты уже есть в базе.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (new_phone != old_phone || new_email != old_email)
                {
                    DbConnection.myCommand.CommandText = $@"
                    UPDATE преподаватели
                    SET 
                        фамилия = '{surname}',
                        имя = '{name}',
                        отчество = '{lastName}',
                        email = '{new_email}',
                        телефон = '{new_phone}'
                    WHERE id_преподавателя = '{id}'";
                }
                else
                {
                    //обновляем без телефона и емайла
                    DbConnection.myCommand.CommandText = $@"update преподаватели set фамилия = '{surname}', имя = '{name}', отчество = '{lastName}'
                    where id_преподавателя = '{id}'";
                }
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Преподаватель изменен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить преподавателя.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление преподавателя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public bool DeleteTeacher(int id)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_преподавателя from группы where id_преподавателя = '{id}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Невозможно удалить преподавателя.\r\n\r\n" +
                    "Этот человек ведёт занятия в группе. Пожалуйста, сначала удалите его из группы, " +
                    "а затем повторите попытку.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"delete from преподаватели_курсы where id_преподавателя = '{id}'";
                DbConnection.myCommand.ExecuteNonQuery();
                DbConnection.myCommand.CommandText = $@"delete from преподаватели where id_преподавателя = '{id}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Преподаватель удален!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить преподавателя.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// получение информации о преподавательском составе для отчета
        /// </summary>
        static public void GetTeacherListForWord()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"SELECT 
                    CONCAT(п.фамилия, ' ', п.имя, ' ', п.отчество) AS ФИО,
                    GROUP_CONCAT(к.название ORDER BY к.название SEPARATOR '\n') AS Курсы
                FROM 
                    преподаватели п
                LEFT JOIN 
                    преподаватели_курсы пк ON п.id_преподавателя = пк.id_преподавателя
                LEFT JOIN 
                    курсы к ON пк.id_курса = к.id_курса
                GROUP BY 
                    п.id_преподавателя, п.фамилия, п.имя, п.отчество
                ORDER BY 
                    п.фамилия, п.имя;
                ";
                dtTeacherWord.Clear();
                DbConnection.MyDataAdapter.Fill(dtTeacherWord);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить информацию о преподавательском составе для отчета.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
