using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class POInKabClass
    {
        static public DataTable dtPoInKab = new DataTable();

        /// <summary>
        /// получение списка ПО в кабинете
        /// </summary>
        /// <param name="id_kab"></param>
        static public void GetPoInKabList(int id_kab)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_пвк, id_кабинета, по
                from по_в_кабинете, программное_обеспечение
                where по_в_кабинете.id_по = программное_обеспечение.id_по
                and id_кабинета = '{id_kab}'";
                dtPoInKab.Clear();
                DbConnection.MyDataAdapter.Fill(dtPoInKab);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список программного обеспечения в кабинете.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление ПО в кабинет
        /// </summary>
        /// <param name="id_kab"></param>
        /// <param name="id_po"></param>
        /// <returns></returns>
        static public bool AddPoInKab(int id_kab, int id_po)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_пвк from по_в_кабинете 
                where id_кабинета = '{id_kab}' and id_по = '{id_po}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    $"Ошибка при добавлении ПО в кабинет. \r\n\r\nДанное программное обеспечение уже имеется в кабинете!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"insert into по_в_кабинете values(null,
                '{id_kab}', '{id_po}')";
                DbConnection.myCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить программное обеспечение в кабинет.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление ПО из кабинета
        /// </summary>
        /// <param name="id_pvk"></param>
        /// <returns></returns>
        static public bool RemovePoFromKab(int id_pvk)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"delete from по_в_кабинете where id_пвк = '{id_pvk}'";
                DbConnection.myCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить программное обеспечение из кабинета.\r\n" +
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
