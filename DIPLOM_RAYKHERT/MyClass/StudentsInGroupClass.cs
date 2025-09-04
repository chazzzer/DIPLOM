using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class StudentsInGroupClass
    {
        static public DataTable dtStudentsInGroup = new DataTable();
        static public DataTable dtFreeStud = new DataTable();

        /// <summary>
        /// получение списка обучающихся в группе
        /// </summary>
        /// <param name="group_name"></param>
        static public void GetStudentInGroupList(string group_name)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select concat(фамилия, ' ', имя, ' ', отчество) as 'FIO'
                from обучающиеся, обучающиеся_в_группе, группы
                where обучающиеся.id_обучающегося = обучающиеся_в_группе.id_обучающегося 
                and обучающиеся_в_группе.id_группы = группы.id_группы
                and обучающиеся_в_группе.id_группы = (select id_группы from группы where название_группы = '{group_name}')";
                dtStudentsInGroup.Clear();
                DbConnection.MyDataAdapter.Fill(dtStudentsInGroup);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список обучающихся в группе.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка доступных обучающихся
        /// </summary>
        /// <param name="kurs"></param>
        static public void GetFreeStudentsList(string kurs)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_курса from курсы where название = '{kurs}'";
                int id_kursa = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"
                SELECT 
                    CONCAT(o.фамилия, ' ', o.имя, ' ', o.отчество) AS FIO
                FROM 
                    обучающиеся o
                WHERE 
                    NOT EXISTS (
                        SELECT 1
                        FROM обучающиеся_в_группе og
                        JOIN группы g ON og.id_группы = g.id_группы
                        WHERE o.id_обучающегося = og.id_обучающегося
                          AND g.id_курса = 1
                    )
                ";
                dtFreeStud.Clear();
                DbConnection.MyDataAdapter.Fill(dtFreeStud);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список обучающихся, доступных для добавления в группу.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление обучающегося в группу
        /// </summary>
        /// <param name="fio"></param>
        /// <param name="group_name"></param>
        /// <returns></returns>
        static public bool AddStudentInGroup(string fio, string group_name)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся
                where CONCAT(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество) = '{fio}'";
                int id_student = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"select id_группы from группы where 
                название_группы = '{group_name}'";
                int id_group = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"select id_свг from обучающиеся_в_группе 
                where id_группы = '{id_group}' and id_обучающегося = '{id_student}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении обучающегося в группу. \r\n\r\nДанный человек уже состоит в ней!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"insert into обучающиеся_в_группе values(null,
                '{id_group}', '{id_student}')";
                DbConnection.myCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить обучающегося в группу.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление обучающегося из группы
        /// </summary>
        /// <param name="fio"></param>
        /// <param name="group_name"></param>
        /// <returns></returns>
        static public bool RemoveStudentFromGroup(string fio, string group_name)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся
                where CONCAT(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество) = '{fio}'";
                int id_student = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"select id_группы from группы where 
                название_группы = '{group_name}'";
                int id_group = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"delete from обучающиеся_в_группе where 
                id_группы = '{id_group}' and id_обучающегося = '{id_student}'";
                DbConnection.myCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить обучающегося из группы.\r\n" +
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
