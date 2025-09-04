using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class SalesClass
    {
        static public DataTable dtSales = new DataTable();
        static public DataTable dtSalesStat = new DataTable();
        static public DataTable dtSaleStatWord = new DataTable();

        /// <summary>
        /// получение списка продаж
        /// </summary>
        static public void GetSalesList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_продажи, название, стоимость, дата_продажи
                from продажи, курсы
                where продажи.id_курса = курсы.id_курса
                order by дата_продажи DESC";
                dtSales.Clear();
                DbConnection.MyDataAdapter.Fill(dtSales);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить историю продаж.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение истории продаж за период
        /// </summary>
        /// <param name="date_ot"></param>
        /// <param name="date_do"></param>
        static public void GetSalesListSorted(string date_ot, string date_do)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_продажи, название, стоимость, дата_продажи
                from продажи, курсы
                where продажи.id_курса = курсы.id_курса
                and дата_продажи between '{date_ot}' and '{date_do}'
                order by дата_продажи DESC";
                dtSales.Clear();
                DbConnection.MyDataAdapter.Fill(dtSales);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить историю продаж за период.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавить продажу
        /// </summary>
        /// <param name="kurs"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        static public bool AddSale(string kurs, string price)
        {
            try
            {
                DateTime now = DateTime.Now;
                string currentDate = now.ToString("yyyy-MM-dd");

                DbConnection.myCommand.CommandText = $@"insert into продажи values(null,
                (select id_курса from курсы where название = '{kurs}'), '{price}', '{currentDate}')";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Продажа добавлена!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить информацию о продаже.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// изменение продажи
        /// </summary>
        /// <param name="id_price"></param>
        /// <param name="kurs"></param>
        /// <param name="price"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        static public bool EditSale(string id_price, string kurs, string price, string date)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"update продажи 
                set id_курса = (select id_курса from курсы where название = '{kurs}'),
                стоимость = '{price}', дата_продажи = '{date}'
                where id_продажи = '{id_price}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Продажа изменена!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить информацию о продаже.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление продажи
        /// </summary>
        /// <param name="id_sale"></param>
        /// <returns></returns>
        static public bool DelSale(int id_sale)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"delete from продажи
                where id_продажи = '{id_sale}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Продажа удалена!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить информацию о продаже.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// получение статистики продаж
        /// </summary>
        static public void GetSalesStat()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"
                SELECT 
                    c.название AS course_name,
                    SUM(s.стоимость) AS total_sales
                FROM 
                    продажи s
                JOIN 
                    курсы c ON s.id_курса = c.id_курса
                GROUP BY 
                    c.название
                ORDER BY 
                    total_sales DESC;
                ";
                dtSalesStat.Clear();
                DbConnection.MyDataAdapter.Fill(dtSalesStat);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить статистику продаж.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение истории продаж для отчета
        /// </summary>
        /// <param name="date_ot"></param>
        /// <param name="date_do"></param>
        static public void GetSaleStatForWord(string date_ot, string date_do)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"SELECT 
                    k.название AS Название_курса,
                    COUNT(p.id_продажи) AS Число_продаж,
                    pr.прайс_руб AS Цена_курса,
                    COUNT(p.id_продажи) * pr.прайс_руб AS Итого
                FROM 
                    продажи p
                JOIN 
                    курсы k ON p.id_курса = k.id_курса
                JOIN 
                    прайс pr ON pr.id_курса = p.id_курса
                    AND pr.дата_установки_прайса = (
                        SELECT MAX(pr2.дата_установки_прайса)
                        FROM прайс pr2
                        WHERE pr2.id_курса = p.id_курса
                          AND pr2.дата_установки_прайса <= p.дата_продажи
                    )
                WHERE 
                    p.дата_продажи BETWEEN '{date_ot}' AND '{date_do}'
                GROUP BY 
                    k.название, pr.прайс_руб
                ORDER BY 
                    k.название;
                ";
                dtSaleStatWord.Clear();
                DbConnection.MyDataAdapter.Fill(dtSaleStatWord);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить историю продаж для отчета.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
