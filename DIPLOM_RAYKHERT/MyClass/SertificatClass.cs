using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class SertificatClass
    {
        static public DataTable dtSert = new DataTable();
        static public DataTable dtStudFio = new DataTable();

        /// <summary>
        /// получение списка сертификатов
        /// </summary>
        static public void GetSertList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_сертификата, 
                concat(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество) AS 'FIO',
                название, дата_выдачи
                from сертификаты, обучающиеся, курсы
                where сертификаты.id_обучающегося = обучающиеся.id_обучающегося and сертификаты.id_курса = курсы.id_курса
                order by дата_выдачи DESC";
                dtSert.Clear();
                DbConnection.MyDataAdapter.Fill(dtSert);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список сертификатов.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка сертификатов за период
        /// </summary>
        /// <param name="date_ot"></param>
        /// <param name="date_do"></param>
        static public void GetSertListSorted(string date_ot, string date_do)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_сертификата, 
                concat(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество) AS 'FIO',
                название, дата_выдачи
                from сертификаты, обучающиеся, курсы
                where сертификаты.id_обучающегося = обучающиеся.id_обучающегося and сертификаты.id_курса = курсы.id_курса
                and дата_выдачи between '{date_ot}' and '{date_do}'";
                dtSert.Clear();
                DbConnection.MyDataAdapter.Fill(dtSert);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список сертификатов за период.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка ФИО обучающихся
        /// </summary>
        static public void GetStudFio()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select 
                concat(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество) AS 'FIO'
                from обучающиеся";
                dtStudFio.Clear();
                DbConnection.MyDataAdapter.Fill(dtStudFio);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список ФИО обучающихся.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// выдача сертификата
        /// </summary>
        /// <param name="fio"></param>
        /// <param name="kurs"></param>
        /// <returns></returns>
        static public bool AddSert(string fio, string kurs)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся
                where concat(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество) = '{fio}'";
                int id_student = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"select id_курса from курсы
                where название = '{kurs}'";
                int id_kursa = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DateTime now = DateTime.Now;
                string currentDate = now.ToString("yyyy-MM-dd");

                DbConnection.myCommand.CommandText = $@"insert into сертификаты values(null,
                '{id_student}', '{id_kursa}', '{currentDate}')";
                DbConnection.myCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось сформировать сертификат.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление сертификата
        /// </summary>
        /// <param name="id_sert"></param>
        /// <returns></returns>
        static public bool DelSert(int id_sert)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"delete from сертификаты where id_сертификата = '{id_sert}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                $"Сертификат удален!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить сертификат.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование сертификата
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fio"></param>
        /// <param name="kurs"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        static public bool EditSert(int id, string fio, string kurs, string date)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся
                where concat(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество) = '{fio}'";
                int id_student = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"select id_курса from курсы
                where название = '{kurs}'";
                int id_kursa = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"update сертификаты set id_обучающегося = '{id_student}',
                id_курса = '{id_kursa}', дата_выдачи = '{date}' where id_сертификата = '{id}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                $"Сертификат изменен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить сертификат.\r\n" +
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
