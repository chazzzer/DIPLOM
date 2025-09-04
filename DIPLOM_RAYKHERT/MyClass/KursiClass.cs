using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class KursiClass
    {
        static public DataTable dtKursi = new DataTable();
        static public DataTable dtKursiFormatted = new DataTable();

        /// <summary>
        /// получение списка курсов
        /// </summary>
        static public void GetKursiList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_курса, изображение, название, длительность_ч
                from курсы";
                dtKursi.Clear();
                DbConnection.MyDataAdapter.Fill(dtKursi);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список курсов.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// форматный вывод курсов
        /// </summary>
        /// <param name="panel"></param>
        static public void GetKursiListFormatted(FlowLayoutPanel panel)
        {
            try
            {
                panel.Controls.Clear();

                DbConnection.myCommand.CommandText = 
                $@"
                SELECT 
                K.id_курса,
                K.изображение,
                K.название,
                K.длительность_ч,
                P.прайс_руб AS последняя_цена
            FROM 
                курсы K
            INNER JOIN 
                (
                    SELECT 
                        id_курса, 
                        прайс_руб, 
                        ROW_NUMBER() OVER (PARTITION BY id_курса ORDER BY id_прайс DESC) AS RowNum
                    FROM 
                        прайс
                ) P ON K.id_курса = P.id_курса AND P.RowNum = 1;
                ";

                using (MySqlDataReader reader = DbConnection.myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KursCard kc = new KursCard(
                            reader["id_курса"].ToString(),
                            reader["изображение"].ToString(),
                            reader["название"].ToString(),
                            reader["длительность_ч"].ToString(),
                            reader["последняя_цена"].ToString());

                        panel.Controls.Add(kc);
                    }
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список курсов для форматного вывода.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление курса
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="kurs"></param>
        /// <param name="hours"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        static public bool AddKurs(string filePath, string kurs, int hours, string price)
        {
            int last_kurs;
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_курса from курсы where название = '{kurs}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Курс с таким названием уже существует!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                
                }
                DbConnection.myCommand.CommandText = $@"insert into курсы values(null, '{filePath}',
                '{kurs}', '{hours}')";
                DbConnection.myCommand.ExecuteNonQuery();

                //ласт курс
                DbConnection.myCommand.CommandText = $@"select id_курса from курсы order by id_курса DESC limit 1";
                last_kurs = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());
                //текущая дата
                DateTime now = DateTime.Now;
                string currentDate = now.ToString("yyyy-MM-dd");

                DbConnection.myCommand.CommandText = $@"insert into прайс values(null, '{last_kurs}',
                '{price}', '{currentDate}')";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Курс добавлен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить новый курс.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование курса
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pic"></param>
        /// <param name="new_name"></param>
        /// <param name="hours"></param>
        /// <param name="price"></param>
        /// <param name="old_name"></param>
        /// <returns></returns>
        static public bool EditKurs(int id, string pic, string new_name, int hours, string price, string old_name)
        {
            try
            {
                if (new_name != old_name)
                {
                    DbConnection.myCommand.CommandText = $@"select id_курса from курсы where название = '{new_name}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при редактировании курса. \r\n\r\nКурс с таким названием уже существует",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }
                    //обновляем запись в таблице с названием
                    DbConnection.myCommand.CommandText = $@"update курсы set изображение = '{pic}', название = '{new_name}',
                    длительность_ч = '{hours}' where id_курса = '{id}'";
                    DbConnection.myCommand.ExecuteNonQuery();
                }
                else
                {
                    //обновляем запись в таблице без названия
                    DbConnection.myCommand.CommandText = $@"update курсы  
                    set изображение = '{pic}', длительность_ч = '{hours}' where id_курса = '{id}'";
                    DbConnection.myCommand.ExecuteNonQuery();
                }

                //выполняем проверку на необходимость добавления записи об изменении цены курса
                DbConnection.myCommand.CommandText = $@"select прайс_руб from прайс where id_курса = '{id}' 
                order by id_прайс DESC limit 1";
                string last_price_kursa = Convert.ToString(DbConnection.myCommand.ExecuteScalar());
                last_price_kursa = last_price_kursa.Replace(',', '.');
                if (last_price_kursa != price)
                {
                    //текущая дата
                    DateTime now = DateTime.Now;
                    string currentDate = now.ToString("yyyy-MM-dd");
                    DbConnection.myCommand.CommandText = $@"insert into прайс values(null, '{id}', '{price}', 
                    '{currentDate}')";
                    DbConnection.myCommand.ExecuteNonQuery();
                }
                System.Windows.Forms.MessageBox.Show(
                "Курс изменен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить курс.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление курса
        /// </summary>
        /// <param name="id_kursa"></param>
        /// <returns></returns>
        static public bool DeleteKurs(int id_kursa)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_курса from преподаватели_курсы where id_курса = '{id_kursa}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при удалении курса. \r\n\r\nИмеется запись с этим курсом в таблице «Преподаватели». " +
                    "Перед удалением курса необходимо удалить запись с упоминанием данного курса в этой таблице.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"select id_курса from сертификаты where id_курса = '{id_kursa}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при удалении курса. \r\n\r\nИмеется запись с этим курсом в таблице «Сертификаты». " +
                    "Перед удалением курса необходимо удалить запись с упоминанием данного курса в этой таблице.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"select id_курса from заявка_на_обучение where id_курса = '{id_kursa}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при удалении курса. \r\n\r\nИмеется запись с этим курсом в таблице «Заявка на обучение». " +
                    "Перед удалением курса необходимо удалить запись с упоминанием данного курса в этой таблице.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"delete from продажи where id_курса = '{id_kursa}'";
                DbConnection.myCommand.ExecuteNonQuery();
                DbConnection.myCommand.CommandText = $@"delete from прайс where id_курса = '{id_kursa}'";
                DbConnection.myCommand.ExecuteNonQuery();
                DbConnection.myCommand.CommandText = $@"delete from курсы where id_курса = '{id_kursa}'";
                DbConnection.myCommand.ExecuteNonQuery();
                DbConnection.myCommand.CommandText = $@"delete from по_для_курса where id_курса = '{id_kursa}'";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Курс удален!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить курс.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// форматный вывод курсов с условием
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="kurs_name"></param>
        /// <param name="hours_ot"></param>
        /// <param name="hours_do"></param>
        /// <param name="sort_mode"></param>
        static public void GetKursiListFormattedSorted(FlowLayoutPanel panel, string kurs_name, string hours_ot, string hours_do,
            string sort_mode) 
        {
            try
            {
                panel.Controls.Clear();

                if (sort_mode == "По умолчанию")
                {
                    DbConnection.myCommand.CommandText =
                    $@"
                    SELECT 

                    K.id_курса,
                    K.изображение,
                    K.название,
                    K.длительность_ч,
                    P.прайс_руб AS последняя_цена

                    FROM 
                        курсы K

                    INNER JOIN 
                        (
                            SELECT 
                                id_курса, 
                                прайс_руб, 
                                ROW_NUMBER() OVER (PARTITION BY id_курса ORDER BY id_прайс DESC) AS RowNum
                            FROM 
                                прайс
                        ) P ON K.id_курса = P.id_курса AND P.RowNum = 1

                    WHERE K.название like '%{kurs_name}%'
                    and K.длительность_ч between '{hours_ot}' and '{hours_do}'";
                }

                if (sort_mode == "По возрастанию")
                {
                    DbConnection.myCommand.CommandText =
                    $@"
                    SELECT 

                    K.id_курса,
                    K.изображение,
                    K.название,
                    K.длительность_ч,
                    P.прайс_руб AS последняя_цена

                    FROM 
                        курсы K

                    INNER JOIN 
                        (
                            SELECT 
                                id_курса, 
                                прайс_руб, 
                                ROW_NUMBER() OVER (PARTITION BY id_курса ORDER BY id_прайс DESC) AS RowNum
                            FROM 
                                прайс
                        ) P ON K.id_курса = P.id_курса AND P.RowNum = 1

                    WHERE K.название like '%{kurs_name}%'
                    and K.длительность_ч between '{hours_ot}' and '{hours_do}'

                    order by последняя_цена ASC";
                }

                if (sort_mode == "По убыванию")
                {
                    DbConnection.myCommand.CommandText =
                    $@"
                    SELECT 

                    K.id_курса,
                    K.изображение,
                    K.название,
                    K.длительность_ч,
                    P.прайс_руб AS последняя_цена

                    FROM 
                        курсы K

                    INNER JOIN 
                        (
                            SELECT 
                                id_курса, 
                                прайс_руб, 
                                ROW_NUMBER() OVER (PARTITION BY id_курса ORDER BY id_прайс DESC) AS RowNum
                            FROM 
                                прайс
                        ) P ON K.id_курса = P.id_курса AND P.RowNum = 1

                    WHERE K.название like '%{kurs_name}%'
                    and K.длительность_ч between '{hours_ot}' and '{hours_do}'

                    order by последняя_цена DESC";
                }


                using (MySqlDataReader reader = DbConnection.myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KursCard kc = new KursCard(
                            reader["id_курса"].ToString(),
                            reader["изображение"].ToString(),
                            reader["название"].ToString(),
                            reader["длительность_ч"].ToString(),
                            reader["последняя_цена"].ToString());

                        panel.Controls.Add(kc);
                    }
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список курсов с фильтрами.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
