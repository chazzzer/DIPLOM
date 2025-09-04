using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass.SpravochnikClass
{
    internal class POClass
    {
        static public DataTable dtPO = new DataTable();

        /// <summary>
        /// получение списка ПО
        /// </summary>
        static public void GetPOList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_по, по
                from программное_обеспечение";
                dtPO.Clear();
                DbConnection.MyDataAdapter.Fill(dtPO);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список программного обеспечения.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление ПО
        /// </summary>
        /// <param name="po"></param>
        /// <returns></returns>
        static public bool AddPO(string po)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_по from программное_обеспечение where по = '{po}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении программного обеспечения. Данная запись уже существует",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"insert into программное_обеспечение values (null, '{po}')";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Новое программное обеспечение добавлено!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить программное обеспечение.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование ПО
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="new_po"></param>
        /// <param name="old_po"></param>
        /// <returns></returns>
        static public bool EditPO(int idx, string new_po, string old_po)
        {
            try
            {
                if (new_po != old_po)
                {
                    // Проверка уникальности нового типа кабинета
                    DbConnection.myCommand.CommandText = $@"select id_по from программное_обеспечение where по = '{new_po}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        "Ошибка при редактировании программного обеспечения. \r\n\r\nДанная запись уже существует",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }

                    DbConnection.myCommand.CommandText = $@"update программное_обеспечение set по = '{new_po}'
                    where id_по = '{idx}'";
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
                "Не удалось изменить программное обеспечение.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление ПО
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        static public bool DeletePO(string idx)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_по from по_в_кабинете where id_по = '{idx}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при удалении программного обеспечения. Удаление повлечет за собой нарушение логики программы",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"select id_по from по_для_курса where id_по = '{idx}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при удалении программного обеспечения. Удаление повлечет за собой нарушение логики программы",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"delete from программное_обеспечение where id_по = '{idx}'";
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
                "Не удалось удалить программное обеспечение.\r\n" +
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
