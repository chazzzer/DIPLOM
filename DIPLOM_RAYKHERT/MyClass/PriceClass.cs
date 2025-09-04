using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class PriceClass
    {
        static public DataTable dtPrice = new DataTable();

        /// <summary>
        /// получение прайс листа
        /// </summary>
        static public void GetPriceList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_прайс, название, прайс_руб, дата_установки_прайса
                from прайс, курсы
                where прайс.id_курса = курсы.id_курса
                order by дата_установки_прайса DESC";
                dtPrice.Clear();
                DbConnection.MyDataAdapter.Fill(dtPrice);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить прайс-лист.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление прайса
        /// </summary>
        /// <param name="kurs"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        static public bool AddPrice(string kurs, string price)
        {
            try
            {
                DateTime now = DateTime.Now;
                string currentDate = now.ToString("yyyy-MM-dd");

                DbConnection.myCommand.CommandText = $@"insert into прайс values (null,
                (select id_курса from курсы where название = '{kurs}'), '{price}', '{currentDate}')";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Прайс установлен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось установить прайс.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// изменение прайса
        /// </summary>
        /// <param name="id_price"></param>
        /// <param name="kurs"></param>
        /// <param name="price"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        static public bool EditPrice(string id_price, string kurs, string price, string date)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"update прайс 
                set id_курса = (select id_курса from курсы where название = '{kurs}'),
                прайс_руб = '{price}', дата_установки_прайса = '{date}'
                where id_прайс = '{id_price}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Прайс изменен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить прайс.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление прайса
        /// </summary>
        /// <param name="id_price"></param>
        /// <returns></returns>
        static public bool DelPrice(int id_price)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"delete from прайс
                where id_прайс = '{id_price}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Прайс удален!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить прайс.\r\n" +
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
