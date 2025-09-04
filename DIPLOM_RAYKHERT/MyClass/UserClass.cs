using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class UserClass
    {
        static public DataTable dtUsers = new DataTable();
        static public DataTable dtUsersFio = new DataTable();

        /// <summary>
        /// получение списка пользователей
        /// </summary>
        static public void GetUsersList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_пользователя, с_роли.роль, фамилия, имя, отчество, email, телефон, логин, пароль
                from пользователи, с_роли
                where пользователи.id_роли = с_роли.id_роли";
                dtUsers.Clear();
                DbConnection.MyDataAdapter.Fill(dtUsers);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список пользователей.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка ФИО пользователей
        /// </summary>
        static public void GetUsersListFio()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_пользователя, с_роли.роль, 
                concat(фамилия, ' ', имя, ' ', отчество) as 'FIO', email, телефон, логин, пароль
                from пользователи, с_роли
                where пользователи.id_роли = с_роли.id_роли";
                dtUsersFio.Clear();
                DbConnection.MyDataAdapter.Fill(dtUsersFio);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список ФИО пользователей.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// удаление пользователя
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        static public bool DeleteUser(int idx)
        {
            try
            {
                string picked_user = "";
                DbConnection.myCommand.CommandText = $@"select логин from пользователи where id_пользователя = '{idx}'";
                picked_user = Convert.ToString(DbConnection.myCommand.ExecuteScalar());
                if (picked_user == DbConnection.user)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Невозможно удалить пользователя. Вы не можете удалить свою собственную учётную запись!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return false;
                }
                DbConnection.myCommand.CommandText = $@"select id_пользователя from заявка_на_обучение where id_пользователя = '{idx}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Невозможно удалить пользователя.\r\n\r\n" +
                    "Этот пользователь создал заявку на обучение, поэтому удаление приведёт к нарушению логики работы программы. " +
                    "Пожалуйста, сначала удалите заявку, затем повторите попытку.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return false;
                }
                DbConnection.myCommand.CommandText = $@"select id_пользователя from договоры where id_пользователя = '{idx}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Невозможно удалить пользователя.\r\n\r\n" +
                    "Этот пользователь сформировал договор, поэтому удаление приведёт к нарушению логики работы программы. " +
                    "Пожалуйста, сначала закройте или удалите договор, затем повторите попытку.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return false;
                }
                DbConnection.myCommand.CommandText = $@"delete from пользователи where id_пользователя = '{idx}'";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                    "Пользователь успешно удален!",
                    "Успешно",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить пользователя.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// проверка корректности адреса электронной почты
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        static public bool CheckEmail(string email)
        {
            try
            {
                int countDogMark = 0;
                foreach (char c in email)
                    if (c == '@') countDogMark++;
                if (countDogMark != 1) return false;

                if (email.StartsWith(".") || email.EndsWith(".")) return false;
                if (email.StartsWith("@") || email.EndsWith("@")) return false;

                int countPointMark = 0;
                int indexDogMark = email.IndexOf("@");

                for (int i = indexDogMark; i < email.Length; i++)
                    if (email[i] == '.') countPointMark++;
                if (countPointMark < 1) return false;

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось проверить корректность адреса электронной почты.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// добавление пользователя
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="lastname"></param>
        /// <param name="role"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="login"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        static public bool AddUser(string name, string surname, string lastname, string role, string phone,
            string email, string login, string pass)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_пользователя from пользователи 
                where логин = '{login}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении пользователя. Пользователь с таким логином уже существует.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"insert into пользователи values(null, 
                (select id_роли from с_роли where роль = '{role}'), '{surname}', '{name}', '{lastname}',
                '{email}', '{phone}', '{login}', md5('{pass}'))";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Пользователь системы добавлен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить пользователя.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="lastname"></param>
        /// <param name="role"></param>
        /// <param name="new_phone"></param>
        /// <param name="new_email"></param>
        /// <param name="new_login"></param>
        /// <param name="old_phone"></param>
        /// <param name="old_email"></param>
        /// <param name="old_login"></param>
        /// <returns></returns>
        static public bool EditUser(int id, string name, string surname, string lastname, string role, string new_phone,
            string new_email, string new_login, string old_phone, string old_email, string old_login)
        {
            try
            {
                if (new_phone != old_phone)
                {
                    //проверка уникальности нового номера
                    DbConnection.myCommand.CommandText = $@"select id_пользователя from пользователи where телефон = '{new_phone}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при редактировании пользователя. \r\n\r\nЧеловек с таким номером телефона уже есть в базе!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (new_email != old_email)
                {
                    //проверка уникальности нового емайла
                    DbConnection.myCommand.CommandText = $@"select id_пользователя from пользователи where email = '{new_email}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при редактировании пользователя. \r\n\r\nЧеловек с таким адресом электронной почты уже есть в базе!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (new_login != old_login)
                {
                    //проверка уникальности нового logina
                    DbConnection.myCommand.CommandText = $@"select id_пользователя from пользователи where логин = '{new_login}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при редактировании пользователя. \r\n\r\nЧеловек с таким логином уже есть в базе!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (new_phone != old_phone || new_email != old_email)
                {
                    DbConnection.myCommand.CommandText = $@"update пользователи 
                    set id_роли = (select id_роли from с_роли where роль = '{role}'),
                    фамилия = '{surname}', имя = '{name}', отчество = '{lastname}', email = '{new_email}', телефон = '{new_phone}',
                    логин = '{new_login}' where id_пользователя = '{id}'";
                }
                else
                {
                    DbConnection.myCommand.CommandText = $@"update пользователи 
                    set id_роли = (select id_роли from с_роли where роль = '{role}'),
                    фамилия = '{surname}', имя = '{name}', отчество = '{lastname}'
                    where id_пользователя = '{id}'";
                }
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Пользователь системы изменен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить пользователя.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// изменение пароля
        /// </summary>
        /// <param name="new_pass"></param>
        /// <returns></returns>
        static public bool ChangePass(string new_pass)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"update пользователи set пароль = md5('{new_pass}') 
                where логин = '{DbConnection.user}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Пароль успешно изменён!\r\n\r\n" +
                "Для вступления изменений в силу необходимо перезайти в программу.",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);


                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить пароль.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
