using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class POForKurs
    {
        static public DataTable dtPOForKurs = new DataTable();

        /// <summary>
        /// вывод ПО для курса
        /// </summary>
        /// <param name="id_kurs"></param>
        static public void GetPoForKursList(int id_kurs)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_пдк, id_курса, по
                from по_для_курса, программное_обеспечение
                where по_для_курса.id_по = программное_обеспечение.id_по
                and id_курса = '{id_kurs}'";
                dtPOForKurs.Clear();
                DbConnection.MyDataAdapter.Fill(dtPOForKurs);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список программного обеспечения для изучения курса.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавить ПО для курса
        /// </summary>
        /// <param name="id_kurs"></param>
        /// <param name="id_po"></param>
        /// <returns></returns>
        static public bool AddPoForKurs(int id_kurs, int id_po)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_пдк from по_для_курса 
                where id_курса = '{id_kurs}' and id_по = '{id_po}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    $"Ошибка при добавлении программного обеспечения для прохождения курса. " +
                    $"\r\n\r\nДанное программное обеспечение уже включено!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"insert into по_для_курса values(null,
                '{id_kurs}', '{id_po}')";
                DbConnection.myCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить программное обеспечение для изучения курса.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// убрать ПО для курса
        /// </summary>
        /// <param name="id_pdk"></param>
        /// <returns></returns>
        static public bool RemovePoFromKurs(int id_pdk)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"delete from по_для_курса where id_пдк = '{id_pdk}'";
                DbConnection.myCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить программное обеспечение из списка необходимых программ для курса.\r\n" +
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
