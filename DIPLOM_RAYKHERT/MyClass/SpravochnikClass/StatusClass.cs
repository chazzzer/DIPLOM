using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DIPLOM_RAYKHERT.MyClass.SpravochnikClass
{
    internal class StatusClass
    {
        static public DataTable dtStatus = new DataTable();

        /// <summary>
        /// получение списка статусов
        /// </summary>
        static public void GetStatusList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_статуса, статус
                from с_статусы";
                dtStatus.Clear();
                DbConnection.MyDataAdapter.Fill(dtStatus);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список статусов заказа.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление статуса
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        static public bool AddStatus(string status)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_статуса from с_статусы where статус = '{status}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении статуса. Данная запись уже существует",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"insert into с_статусы values (null, '{status}')";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Новый статус добавлен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить роль.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование статуса
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="new_status"></param>
        /// <param name="old_status"></param>
        /// <returns></returns>
        static public bool EditStatus(int idx, string new_status, string old_status)
        {
            try
            {
                if (new_status != old_status)
                {
                    // Проверка уникальности нового типа кабинета
                    DbConnection.myCommand.CommandText = $@"select id_статуса from с_статусы where статус = '{new_status}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        "Ошибка при редактировании статуса. Данная запись уже существует",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }

                    DbConnection.myCommand.CommandText = $@"update с_статусы set статус = '{new_status}'
                    where id_статуса = '{idx}'";
                    DbConnection.myCommand.ExecuteNonQuery();
                }
                System.Windows.Forms.MessageBox.Show(
                "Запись сохранена",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить роль.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление статуса
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        static public bool DeleteStatus(string idx)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_статус from заявка_на_обучение where id_статус = '{idx}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при удалении статуса. Удаление повлечет за собой нарушение логики программы",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"delete from с_статусы where id_статуса = '{idx}'";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Запись удалена",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить роль.\r\n" +
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
