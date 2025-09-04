using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass.SpravochnikClass
{
    internal class RoliClass
    {
        static public DataTable dtRoli = new DataTable();

        /// <summary>
        /// получение списка ролей
        /// </summary>
        static public void GetRoliList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_роли, роль
                from с_роли";
                dtRoli.Clear();
                DbConnection.MyDataAdapter.Fill(dtRoli);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список ролей пользователя.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление роли
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        static public bool AddRoli(string role)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_роли from с_роли where роль = '{role}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении роли. Данная запись уже существует",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"insert into с_роли values (null, '{role}')";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Новая роль добавлена!",
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
        /// редактирование роли
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="new_role"></param>
        /// <param name="old_role"></param>
        /// <returns></returns>
        static public bool EditRole(int idx, string new_role, string old_role)
        {
            try
            {
                if (new_role != old_role)
                {
                    // Проверка уникальности нового типа кабинета
                    DbConnection.myCommand.CommandText = $@"select id_роли from с_роли where роль = '{new_role}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        "Ошибка при редактировании роли. Данная запись уже существует",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }

                    DbConnection.myCommand.CommandText = $@"update с_роли set роль = '{new_role}'
                    where id_роли = '{idx}'";
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
        /// удаление роли
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        static public bool DeleteRole(string idx)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_роли from пользователи where id_роли = '{idx}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при удалении роли. Удаление повлечет за собой нарушение логики программы",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"delete from с_роли where id_роли = '{idx}'";
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
