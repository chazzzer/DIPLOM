using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class KabinetClass
    {
        static public DataTable dtKab = new DataTable();

        /// <summary>
        /// получение списка кабинетов
        /// </summary>
        static public void GetKabList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_кабинета, номер_кабинета, тип_кабинета
                from кабинеты, с_тип_кабинета
                where кабинеты.id_тип_кабинета = с_тип_кабинета.id_тип_кабинета
                order by номер_кабинета aSC";
                dtKab.Clear();
                DbConnection.MyDataAdapter.Fill(dtKab);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список кабинетов.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление кабинета
        /// </summary>
        /// <param name="nomer"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        static public bool AddKabinet(int nomer, string type)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_кабинета from кабинеты where номер_кабинета = '{nomer}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    $"Ошибка при добавлении кабинета. \r\n\r\nКабинет с таким номером уже существует",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"insert into кабинеты values (null,
                '{nomer}', (select id_тип_кабинета from с_тип_кабинета where тип_кабинета = '{type}'))";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                $"Кабинет добавлен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить новый кабинет.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование кабинета
        /// </summary>
        /// <param name="id"></param>
        /// <param name="new_nomer"></param>
        /// <param name="type"></param>
        /// <param name="old_nomer"></param>
        /// <returns></returns>
        static public bool EditKabinet(int id, int new_nomer, string type, int old_nomer)
        {
            try
            {
                if (new_nomer != old_nomer)
                {
                    // Проверка уникальности
                    DbConnection.myCommand.CommandText = $@"select id_кабинета 
                    from кабинеты
                    where номер_кабинета = '{new_nomer}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при редактировании кабинета. \r\n\r\nКабинет с таким номером уже существует",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }
                    // Обновление данных (с изменением названия)
                    DbConnection.myCommand.CommandText = $@"update кабинеты set номер_кабинета = '{new_nomer}',
                    id_тип_кабинета = (select id_тип_кабинета from с_тип_кабинета where тип_кабинета = '{type}')
                    where id_кабинета = '{id}'";
                    DbConnection.myCommand.ExecuteNonQuery();
                }
                else
                {
                    // Обновление данных (без изменения названия)
                    DbConnection.myCommand.CommandText = $@"update кабинеты 
                    set id_тип_кабинета = (select id_тип_кабинета from с_тип_кабинета where тип_кабинета = '{type}')
                    where id_кабинета = '{id}'";
                    DbConnection.myCommand.ExecuteNonQuery();
                }

                System.Windows.Forms.MessageBox.Show(
                $"Кабинет изменен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить кабинет.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление кабинета
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public bool DeleteKabinet(int id)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_расписание from расписание where id_кабинета = '{id}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    $"Ошибка при удалении кабинета. \r\n\r\nДанный кабинет используется в расписании! " +
                    $"\r\n\r\nУдалите запись с данным кабинетом из расписания и повторите попытку",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"delete from по_в_кабинете where id_кабинета = '{id}'";
                DbConnection.myCommand.ExecuteNonQuery();

                DbConnection.myCommand.CommandText = $@"delete from кабинеты where id_кабинета = '{id}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                $"Кабинет удален!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить кабинет.\r\n" +
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
