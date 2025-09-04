using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class DogovorClass
    {
        static public DataTable dtDogovor = new DataTable();

        /// <summary>
        /// получение списка договоров
        /// </summary>
        static public void GetDogovorList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select 
                договоры.id_договора,
                договоры.id_заявки_на_обучение,
                договоры.номер_договора, 
                concat(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество) AS 'FIOO',
                concat(пользователи.фамилия, ' ', пользователи.имя, ' ', пользователи.отчество) AS 'FIO',
                договоры.дата_заключения, 
                concat('Курс «',курсы.название,'»') AS 'KURS',
                договоры.сумма_к_оплате

                from договоры, пользователи, заявка_на_обучение, обучающиеся, курсы

                where договоры.id_пользователя = пользователи.id_пользователя
                and договоры.id_заявки_на_обучение = заявка_на_обучение.id_заявки_на_обучение
                and заявка_на_обучение.id_обучающегося = обучающиеся.id_обучающегося
                and заявка_на_обучение.id_курса = курсы.id_курса

                group by договоры.id_договора, договоры.id_заявки_на_обучение, 
                договоры.номер_договора, FIOO, FIO, договоры.дата_заключения, KURS, 
                договоры.сумма_к_оплате

                order by договоры.дата_заключения DESC";
                dtDogovor.Clear();
                DbConnection.MyDataAdapter.Fill(dtDogovor);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список договоров.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка договор с фильтрами
        /// </summary>
        /// <param name="date_ot"></param>
        /// <param name="date_do"></param>
        static public void GetDogovorSorted(string date_ot, string date_do)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select 
                договоры.id_договора,
                договоры.id_заявки_на_обучение,
                договоры.номер_договора, 
                concat(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество) AS 'FIOO',
                concat(пользователи.фамилия, ' ', пользователи.имя, ' ', пользователи.отчество) AS 'FIO',
                договоры.дата_заключения, 
                concat('Курс «',курсы.название,'»') AS 'KURS',
                договоры.сумма_к_оплате

                from договоры, пользователи, заявка_на_обучение, обучающиеся, курсы

                where договоры.id_пользователя = пользователи.id_пользователя
                and договоры.id_заявки_на_обучение = заявка_на_обучение.id_заявки_на_обучение
                and заявка_на_обучение.id_обучающегося = обучающиеся.id_обучающегося
                and заявка_на_обучение.id_курса = курсы.id_курса
                and договоры.дата_заключения between '{date_ot}' and '{date_do}'

                group by договоры.id_договора, договоры.id_заявки_на_обучение, 
                договоры.номер_договора, FIOO, FIO, договоры.дата_заключения, KURS, 
                договоры.сумма_к_оплате

                order by договоры.номер_договора ASC";
                dtDogovor.Clear();
                DbConnection.MyDataAdapter.Fill(dtDogovor);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список договоров с фильтром.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление договора
        /// </summary>
        /// <param name="kurs"></param>
        /// <param name="zayavka"></param>
        /// <returns></returns>
        static public bool AddDogovor(string kurs, int zayavka)
        {
            int last_dogovor;
            string itogo;
            try
            {
                DbConnection.myCommand.CommandText = $@"select номер_договора from договоры where id_заявки_на_обучение = '{zayavka}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    int dogovor = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());
                    System.Windows.Forms.MessageBox.Show(
                    $"На основе данной заявки уже сформирован договор! \r\n\r\nЕго номер: {dogovor}",
                    "Уведомление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    return false;
                }

                //текущая дата
                DateTime now = DateTime.Now;
                string currentDate = now.ToString("yyyy-MM-dd");

                //Прайс услуги
                DbConnection.myCommand.CommandText = $@"select прайс_руб from прайс, курсы 
                where курсы.название = '{kurs}'
                and прайс.id_курса = курсы.id_курса";
                itogo = Convert.ToString(DbConnection.myCommand.ExecuteScalar());
                itogo = itogo.Replace(",", ".");

                //ласт договор
                DbConnection.myCommand.CommandText = $@"select номер_договора from договоры order by номер_договора DESC limit 1";
                last_dogovor = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                //добавление записи о договоре
                DbConnection.myCommand.CommandText = $@"insert into договоры values(null, '{last_dogovor + 1}', '{zayavka}', '{currentDate}',
                (select id_пользователя from пользователи where логин = '{DbConnection.user}'), '{itogo}')";
                DbConnection.myCommand.ExecuteNonQuery();

                //ласт договор
                DbConnection.myCommand.CommandText = $@"select номер_договора from договоры order by номер_договора DESC limit 1";
                last_dogovor = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                //добавление записи о продаже
                DbConnection.myCommand.CommandText = $@"insert into продажи values(null, 
                (select id_курса from курсы where название = '{kurs}'), '{itogo}', '{currentDate}')";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                $"Договор сформирован! Его номер: {last_dogovor}",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                last_dogovor = 0;
                itogo = "";
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось сформировать договор.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование договора
        /// </summary>
        /// <param name="id_dogovora"></param>
        /// <param name="manager"></param>
        /// <param name="data"></param>
        /// <param name="itogo"></param>
        /// <returns></returns>
        static public bool EditDogovor(string id_dogovora, string manager, string data, string itogo)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"update договоры
                set дата_заключения = '{data}', 
                id_пользователя = (select id_пользователя from пользователи where concat(фамилия, ' ', имя, ' ', отчество) = '{manager}'),
                сумма_к_оплате = '{itogo}'
                where id_договора = '{id_dogovora}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Договор изменен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить договор.\r\n" +
                "Проверьте корректность введенных данных, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление договора
        /// </summary>
        /// <param name="nomer"></param>
        /// <returns></returns>
        static public bool DelDogovor(int nomer)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"delete from договоры where номер_договора = '{nomer}'";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Договор расторгнут",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось расторгнуть договор.\r\n" +
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
