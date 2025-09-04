using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Security.Cryptography;
using ZstdSharp.Unsafe;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class ZayavkiClass
    {
        static public DataTable dtZayavki = new DataTable();

        /// <summary>
        /// получение списка заявок на обучение
        /// </summary>
        static public void GetZayavkiList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_заявки_на_обучение, concat(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество)
                AS 'ФИО обучающегося', курсы.название, дата_заявки, с_статусы.статус, 
                concat(пользователи.фамилия, ' ', пользователи.имя, ' ', пользователи.отчество) AS 'ФИО менеджера'
                from заявка_на_обучение, обучающиеся, пользователи, курсы, с_статусы
                where заявка_на_обучение.id_обучающегося = обучающиеся.id_обучающегося and заявка_на_обучение.id_пользователя = пользователи.id_пользователя
                and заявка_на_обучение.id_курса = курсы.id_курса and заявка_на_обучение.id_статус = с_статусы.id_статуса
                order by дата_заявки DESC";
                dtZayavki.Clear();
                DbConnection.MyDataAdapter.Fill(dtZayavki);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список заявок на обучение.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление заявки
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="lastName"></param>
        /// <param name="kurs"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        static public bool AddZayavka(string name, string surname, string lastName, string kurs, string phone, string email)
        {
            int id_student;
            try
            {
                id_student = 0;

                // Проверяем наличие обучающегося по телефону
                DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся where телефон = '{phone}'";
                object phoneResult = DbConnection.myCommand.ExecuteScalar();

                // Проверяем наличие обучающегося по email
                DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся where email = '{email}'";
                object emailResult = DbConnection.myCommand.ExecuteScalar();

                // Функция для проверки заявки на курс по id обучающегося
                bool HasZayavka(int studentId)
                {
                    DbConnection.myCommand.CommandText = $@"
                    select count(*) from заявка_на_обучение 
                    where id_обучающегося = {studentId} 
                    and id_курса = (select id_курса from курсы where название = '{kurs}')";
                    int count = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());
                    return count >= 1;
                }

                // Обработка по телефону
                if (phoneResult != null && phoneResult != DBNull.Value)
                {
                    int studentIdByPhone = Convert.ToInt32(phoneResult);
                    if (HasZayavka(studentIdByPhone))
                    {
                        DbConnection.myCommand.CommandText = $@"
                        select concat(фамилия, ' ', имя, ' ', отчество) 
                        from обучающиеся 
                        where id_обучающегося = {studentIdByPhone}";
                        string fioo = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                        DbConnection.myCommand.CommandText = $@"
                        select id_заявки_на_обучение 
                        from заявка_на_обучение 
                        where id_обучающегося = {studentIdByPhone} 
                        and id_курса = (select id_курса from курсы where название = '{kurs}')";
                        string id_zayavki = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                        System.Windows.Forms.MessageBox.Show(
                            $"Ошибка при добавлении заявки. \r\n\r\nВ базе уже имеется заявка на прохождение курса «{kurs}» от {fioo}!" +
                            $"\r\n\r\nЕе уникальный номер: {id_zayavki}",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    DbConnection.myCommand.CommandText = $@"
                    select concat(фамилия, ' ', имя, ' ', отчество) 
                    from обучающиеся 
                    where id_обучающегося = {studentIdByPhone}";
                    string fio = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                    System.Windows.Forms.MessageBox.Show(
                        $"В базе данных существует обучащийся с данным номером телефона. Это {fio}! \r\n\r\nВ созданной заявке будет его ФИО",
                        "Уведомление",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    id_student = studentIdByPhone;
                }
                // Если по телефону не нашли, проверяем по email
                else if (emailResult != null && emailResult != DBNull.Value)
                {
                    int studentIdByEmail = Convert.ToInt32(emailResult);
                    if (HasZayavka(studentIdByEmail))
                    {
                        DbConnection.myCommand.CommandText = $@"
                        select concat(фамилия, ' ', имя, ' ', отчество) 
                        from обучающиеся 
                        where id_обучающегося = {studentIdByEmail}";
                        string fioo = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                        DbConnection.myCommand.CommandText = $@"
                        select id_заявки_на_обучение 
                        from заявка_на_обучение 
                        where id_обучающегося = {studentIdByEmail} 
                        and id_курса = (select id_курса from курсы where название = '{kurs}')";
                        string id_zayavki = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                        System.Windows.Forms.MessageBox.Show(
                            $"Ошибка при добавлении заявки. \r\n\r\nВ базе уже имеется заявка на прохождение курса «{kurs}» от {fioo}!" +
                            $"\r\n\r\nЕе уникальный номер: {id_zayavki}",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    DbConnection.myCommand.CommandText = $@"
                    select concat(фамилия, ' ', имя, ' ', отчество) 
                    from обучающиеся 
                    where id_обучающегося = {studentIdByEmail}";
                    string fio = Convert.ToString(DbConnection.myCommand.ExecuteScalar());

                    System.Windows.Forms.MessageBox.Show(
                        $"В базе данных существует обучащийся с данным адресом электронной почты. Это {fio}! \r\n\r\nВ созданной заявке будет его ФИО",
                        "Уведомление",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    id_student = studentIdByEmail;
                }
                else // Если не нашли ни по телефону, ни по email - добавляем нового обучающегося
                {
                    DbConnection.myCommand.CommandText = $@"insert into обучающиеся values 
                    (null, '{surname}', '{name}', '{lastName}', '{email}', '{phone}')";
                    DbConnection.myCommand.ExecuteNonQuery();

                    DbConnection.myCommand.CommandText = $@"
                    select id_обучающегося 
                    from обучающиеся 
                    order by id_обучающегося desc limit 1";
                    id_student = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());
                }

                DateTime now = DateTime.Now;
                string currentDate = now.ToString("yyyy-MM-dd");
                DbConnection.myCommand.CommandText = $@"insert into заявка_на_обучение values (null, '{id_student}', 
                (select id_курса from курсы where название = '{kurs}'), '{currentDate}', (select id_статуса from с_статусы where статус = 'Новая'), 
                (select id_пользователя from пользователи where логин = '{DbConnection.user}'))";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                    "Заявка занесена в базу!",
                    "Успешно",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                    "Не удалось добавить заявку на обучение.\r\n" +
                    "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                    "Если ошибка повторяется, обратитесь к администратору системы.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        /// запись на курс
        /// </summary>
        /// <param name="id_student"></param>
        /// <param name="kurs"></param>
        /// <returns></returns>
        static public bool ZapisNaKurs(string id_student, string kurs)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_курса from курсы where название = '{kurs}'";
                int id_kursa = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"select id_заявки_на_обучение from заявка_на_обучение 
                where id_обучающегося = '{id_student}' and id_курса = '{id_kursa}'";
                if (DbConnection.myCommand.ExecuteScalar() != null)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении заявки. \r\n\r\nВ базе имеется заявка от данного обучающегося" +
                    " на данный курс!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DateTime now = DateTime.Now;
                string currentDate = now.ToString("yyyy-MM-dd");

                DbConnection.myCommand.CommandText = $@"insert into заявка_на_обучение values (null,
                '{id_student}', '{id_kursa}', '{currentDate}', (select id_статуса from с_статусы where статус = 'Новая'), 
                (select id_пользователя from пользователи where логин = '{DbConnection.user}'))";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Обучающийся записан на курс!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось записать обучающегося на прохождение курса.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// изменение заявки
        /// </summary>
        /// <param name="id_zayavki"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="lastName"></param>
        /// <param name="new_phone"></param>
        /// <param name="new_email"></param>
        /// <param name="kurs"></param>
        /// <param name="data_zayavki"></param>
        /// <param name="manager_fio"></param>
        /// <param name="old_phone"></param>
        /// <param name="old_email"></param>
        /// <returns></returns>
        static public bool EditZayavka(string id_zayavki, string name, string surname, string lastName,
            string new_phone, string new_email, string kurs, string data_zayavki, string manager_fio,
            string old_phone, string old_email)
        {
            try
            {
                //ПОЛУЧАЕМ АЙДИ ЧЕЛА В ЗАЯВКЕ
                DbConnection.myCommand.CommandText = $@"select id_обучающегося from заявка_на_обучение
                where id_заявки_на_обучение = '{id_zayavki}'";
                int id_student = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                //ОБНОВЛЯЕМ ЧЕЛА В ЗАЯВКЕ
                if (new_phone != old_phone)
                {
                    //проверка уникальности нового номера
                    DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся where телефон = '{new_phone}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при редактировании обучающегося. \r\n\r\nЧеловек с таким номером телефона уже есть в базе!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }
                }
                if (new_email != old_email)
                {
                    //проверка уникальности нового емайла
                    DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся where email = '{new_email}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при редактировании обучающегося. \r\n\r\nЧеловек с таким адресом электронной почты уже есть в базе!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return false;
                    }
                }
                if (new_phone != old_phone || new_email != old_email)
                {
                    DbConnection.myCommand.CommandText = $@"
                    UPDATE обучающиеся
                    SET 
                        фамилия = '{surname}',
                        имя = '{name}',
                        отчество = '{lastName}',
                        email = '{new_email}',
                        телефон = '{new_phone}'
                    WHERE id_обучающегося = '{id_student}'";
                }
                else
                {
                    //обновляем без телефона и емайла
                    DbConnection.myCommand.CommandText = $@"update обучающиеся set фамилия = '{surname}', имя = '{name}', отчество = '{lastName}'
                    where id_обучающегося = '{id_student}'";
                }
                DbConnection.myCommand.ExecuteNonQuery();

                //ОБНОВЛЯЕМ ВСЮ ЗАЯВКУ
                DbConnection.myCommand.CommandText = $@"update заявка_на_обучение
                set 
                id_обучающегося = '{id_student}', 
                id_курса = (select id_курса from курсы where название = '{kurs}'),
                дата_заявки = '{data_zayavki}',
                id_пользователя = (select id_пользователя from пользователи where concat(фамилия, ' ', имя, ' ', отчество) = '{manager_fio}')
                where id_заявки_на_обучение = '{id_zayavki}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Заявка изменена!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить заявку на обучение.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// удаление заявки
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        static public bool DelZayavka(int idx)
        {
            int dogovor;
            try
            {
                dogovor = 0;
                DbConnection.myCommand.CommandText = $@"select номер_договора from договоры where id_заявки_на_обучение = '{idx}'";
                dogovor = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());
                if (dogovor >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    $"Ошибка при удалении заявки. \r\n\r\nНа основе данной заявки имеется сформированный договор." +
                    $" Для удаления заявки, необходимо удалить запись с договором под номером: {dogovor}." +
                    $"\r\n\r\nПосле удаления договора, повторите попытку снова.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"delete from заявка_на_обучение where id_заявки_на_обучение = '{idx}'";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Заявка удалена!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить заявку на обучение.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// одобрение заявки
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        static public bool ApproveZayavka(int idx)
        {
            int dogovor = 0;
            try
            {
                dogovor = 0;
                DbConnection.myCommand.CommandText = $@"select номер_договора from договоры where id_заявки_на_обучение = '{idx}'";
                dogovor = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());
                if (dogovor >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    $"Заявка уже одобрена!",
                    "Уведомление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"update заявка_на_обучение 
                set id_статус = (select id_статуса from с_статусы where статус = 'Одобрена')
                where id_заявки_на_обучение = '{idx}'";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Вы одобрили заявку! \r\n\r\nТеперь Вы можете сформировать договор на основе этой заявки.",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось одобрить заявку.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// отклонение заявки
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        static public bool DeclineZayavka(int idx)
        {
            int dogovor = 0;
            try
            {
                dogovor = 0;
                DbConnection.myCommand.CommandText = $@"select номер_договора from договоры where id_заявки_на_обучение = '{idx}'";
                dogovor = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());
                if (dogovor >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    $"Ошибка при отклонении заявки. \r\n\r\nНа основе данной заявки имеется сформированный договор." +
                    $" Для изменения статуса данной заявки, необходимо удалить запись с договором под номером: {dogovor}." +
                    $"\r\n\r\nПосле удаления договора, повторите попытку снова.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"update заявка_на_обучение 
                set id_статус = (select id_статуса from с_статусы where статус = 'Отклонена')
                where id_заявки_на_обучение = '{idx}'";
                DbConnection.myCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(
                "Вы отклонили заявку",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось отклонить заявку.\r\n" +
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
