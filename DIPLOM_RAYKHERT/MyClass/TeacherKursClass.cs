using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class TeacherKursClass
    {
        static public DataTable dtTeacherKurs = new DataTable();

        /// <summary>
        /// получение списка преподаваемых курсов
        /// </summary>
        /// <param name="id_teacher"></param>
        static public void GetTeacherKursList(int id_teacher)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_пк, название
                from курсы, преподаватели_курсы
                where преподаватели_курсы.id_курса = курсы.id_курса
                and преподаватели_курсы.id_преподавателя = '{id_teacher}'";
                dtTeacherKurs.Clear();
                DbConnection.MyDataAdapter.Fill(dtTeacherKurs);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список преподаваемых курсов.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление преподаваемого курса
        /// </summary>
        /// <param name="id_teacher"></param>
        /// <param name="id_kurs"></param>
        /// <returns></returns>
        static public bool AddTeacherKurs(int id_teacher, string id_kurs)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_пк from преподаватели_курсы where id_преподавателя = '{id_teacher}'
                and id_курса = '{id_kurs}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении преподаваемого курса. \r\n\r\nДанный преподаватель уже ведет этот курс!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"insert into преподаватели_курсы values (null,
                '{id_teacher}', '{id_kurs}')";
                DbConnection.myCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить преподаваемый курс.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление преподаваемого курса
        /// </summary>
        /// <param name="id_pk"></param>
        /// <returns></returns>
        static public bool DeleteTeacherKurs(string id_pk)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"delete from преподаватели_курсы where id_пк = '{id_pk}'";
                DbConnection.myCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить преподаваемый курс.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
