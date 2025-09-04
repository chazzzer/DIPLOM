using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass.SpravochnikClass
{
    internal class KabinetTypeClass
    {
        static public DataTable dtKabinetType = new DataTable();

        /// <summary>
        /// получение списка типов кабинета
        /// </summary>
        static public void GetKabinetTypeList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_тип_кабинета, тип_кабинета
                from с_тип_кабинета";
                dtKabinetType.Clear();
                DbConnection.MyDataAdapter.Fill(dtKabinetType);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список типов кабинета.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление типа кабинета
        /// </summary>
        /// <param name="kabinet_type"></param>
        /// <returns></returns>
        static public bool AddKabinetType(string kabinet_type)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_тип_кабинета from с_тип_кабинета where тип_кабинета = '{kabinet_type}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении типа кабинета. Данная запись уже существует",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"insert into с_тип_кабинета values (null, '{kabinet_type}')";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Новый тип кабинета добавлен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить тип кабинета.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование типа кабинета
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="new_kabinet_type"></param>
        /// <param name="old_kabinet_type"></param>
        /// <returns></returns>
        static public bool EditKabinetType(int idx, string new_kabinet_type, string old_kabinet_type)
        {
            try
            {

                if (new_kabinet_type != old_kabinet_type)
                {
                    // Проверка уникальности нового типа кабинета
                    DbConnection.myCommand.CommandText = $@"SELECT id_тип_кабинета FROM с_тип_кабинета WHERE тип_кабинета = '{new_kabinet_type}'";
                    if (DbConnection.myCommand.ExecuteScalar() != null)
                    {
                        MessageBox.Show("Ошибка при редактировании типа кабинета. \r\n\r\nДанная запись уже существует",
                            "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    DbConnection.myCommand.CommandText = $@"update с_тип_кабинета set тип_кабинета = '{new_kabinet_type}'
                    where id_тип_кабинета = '{idx}'";
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
                "Не удалось изменить тип кабинета.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление типа кабинета
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        static public bool DeleteKabinetType(string idx)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_тип_кабинета from кабинеты where id_тип_кабинета = '{idx}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при удалении типа кабинета. Удаление повлечет за собой нарушение логики программы",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"delete from с_тип_кабинета where id_тип_кабинета = '{idx}'";
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
                "Не удалось удалить тип кабинета.\r\n" +
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
