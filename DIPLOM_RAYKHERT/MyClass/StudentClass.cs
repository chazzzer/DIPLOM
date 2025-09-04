using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Diagnostics;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class StudentClass
    {
        static public DataTable dtStudents = new DataTable();
        
        /// <summary>
        /// получение списка обучающихся
        /// </summary>
        static public void GetStudentList()
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_обучающегося, фамилия, имя, отчество, email, телефон
                from обучающиеся";
                dtStudents.Clear();
                DbConnection.MyDataAdapter.Fill(dtStudents);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список обучающихся.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение номера телефона обучающегося
        /// </summary>
        /// <param name="id_zayavki"></param>
        /// <returns></returns>
        static public string GetPhone(string id_zayavki)
        {
            try
            {
                string phone = "";

                DbConnection.myCommand.CommandText = $@"select id_обучающегося from заявка_на_обучение
                where id_заявки_на_обучение = '{id_zayavki}'";
                int id_student = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"select телефон from обучающиеся where id_обучающегося = '{id_student}'";
                phone = Convert.ToString(DbConnection.myCommand.ExecuteScalar());
;
                return phone;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить номер телефона обучающегося.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return "";
            }
        }

        /// <summary>
        /// получение адреса электронной почты обучающегося
        /// </summary>
        /// <param name="id_zayavki"></param>
        /// <returns></returns>
        static public string GetEmail(string id_zayavki)
        {
            try
            {
                string email = "";

                DbConnection.myCommand.CommandText = $@"select id_обучающегося from заявка_на_обучение
                where id_заявки_на_обучение = '{id_zayavki}'";
                int id_student = Convert.ToInt32(DbConnection.myCommand.ExecuteScalar());

                DbConnection.myCommand.CommandText = $@"select email from обучающиеся where id_обучающегося = '{id_student}'";
                email = Convert.ToString(DbConnection.myCommand.ExecuteScalar());
                
                return email;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить адрес электронной почты обучающегося.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return "";
            }
        }

        /// <summary>
        /// получение данных обучающихся по частичному попаданию
        /// </summary>
        /// <param name="fio"></param>
        static public void GetStudentListSortedByFIO(string fio)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_обучающегося, фамилия, имя, отчество, email, телефон
                from обучающиеся
                where concat(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество) like '%{fio}%'";
                dtStudents.Clear();
                DbConnection.MyDataAdapter.Fill(dtStudents);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список обучающихся с таким ФИО.\r\n" +
                "Проверьте введеные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// получение списка обучающихся с условиями
        /// </summary>
        /// <param name="fio"></param>
        /// <param name="kurs"></param>
        static public void GetStudentListSortedByFIOandKurs(string fio, string kurs)
        {
            try
            {
                //текущая дата
                DateTime now = DateTime.Now;
                string currentDate = now.ToString("yyyy-MM-dd");

                DbConnection.myCommand.CommandText = $@"select обучающиеся.id_обучающегося, фамилия, имя, отчество, email, телефон
                from обучающиеся, обучающиеся_в_группе, группы, курсы
                where обучающиеся.id_обучающегося = обучающиеся_в_группе.id_обучающегося 
                and обучающиеся_в_группе.id_группы = группы.id_группы and группы.id_курса = курсы.id_курса
                and курсы.название = '{kurs}' and группы.окончание_обучения < '{currentDate}'
                and concat(обучающиеся.фамилия, ' ', обучающиеся.имя, ' ', обучающиеся.отчество)  like '%{fio}%'";
                dtStudents.Clear();
                DbConnection.MyDataAdapter.Fill(dtStudents);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось получить список обучающихся.\r\n" +
                "Проверьте подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// добавление обучающегося
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="lastName"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        static public bool AddStudent(string name, string surname, string lastName, string phone, string email)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся where телефон = '{phone}'";
                //если чел с таким номером телефона уже существует
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении обучающегося. \r\n\r\nЧеловек с таким номером телефона уже имеется в таблице.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся where email = '{email}'";
                //если чел с таким email уже существует
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Ошибка при добавлении обучающегося. \r\n\r\nЧеловек с данным адресом электронной почты уже имеется в таблице.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"insert into обучающиеся values (null, '{surname}', '{name}', '{lastName}', 
                    '{email}', '{phone}')";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Обучающийся добавлен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось добавить обучающегося.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// редактирование обучающегося
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="lastName"></param>
        /// <param name="new_phone"></param>
        /// <param name="new_email"></param>
        /// <param name="old_phone"></param>
        /// <param name="old_email"></param>
        /// <returns></returns>
        static public bool EditStudent(int id, string name, string surname, string lastName, string new_phone, string new_email,
            string old_phone, string old_email)
        {
            try
            {
                if (new_phone != old_phone)
                {
                    //проверка уникальности нового номера
                    DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся where телефон = '{new_phone}'";
                    if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        $"Ошибка при редактировании обучающегося. \r\n\r\nЧеловек с таким номером телефона уже имеется в таблице.",
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
                        $"Ошибка при редактировании обучающегося. \r\n\r\nЧеловек с данным адресом электронной почты уже имеется в таблице.",
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
                    WHERE id_обучающегося = '{id}'";
                }
                else
                {
                    //обновляем без телефона и емайла
                    DbConnection.myCommand.CommandText = $@"update обучающиеся set фамилия = '{surname}', имя = '{name}', отчество = '{lastName}'
                    where id_обучающегося = '{id}'";
                }
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Обучающийся изменен!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось изменить обучающегося.\r\n" +
                "Проверьте введенные данные, подключение к базе данных и настройки сервера.\r\n\r\n" +
                "Если ошибка повторяется, обратитесь к администратору системы.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error); 
                return false;
            }
        }

        /// <summary>
        /// удаление обучающегося
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public bool DeleteStudent(int id)
        {
            try
            {
                DbConnection.myCommand.CommandText = $@"select id_обучающегося from заявка_на_обучение where id_обучающегося = '{id}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Не удалось удалить обучающегося.\r\n" +
                    "Попробуйте удалить информацию о заявке от данного обучающегося и повторите попытку.\r\n\r\n" +
                    "Если ошибка повторяется, обратитесь к администратору системы.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"select id_обучающегося from обучающиеся_в_группе where id_обучающегося = '{id}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Невозможно удалить обучающегося.\r\n\r\n" +
                    "Этот человек состоит в группе. Пожалуйста, сначала удалите его из группы, " +
                    "а затем повторите попытку удаления.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                DbConnection.myCommand.CommandText = $@"select id_обучающегося from сертификаты where id_обучающегося = '{id}'";
                if (Convert.ToInt32(DbConnection.myCommand.ExecuteScalar()) >= 1)
                {
                    System.Windows.Forms.MessageBox.Show(
                    "Невозможно удалить обучающегося.\r\n\r\n" +
                    "В разделе «Сертификаты» есть данные, связанные с этим человеком. " +
                    "Пожалуйста, сначала удалите их, а затем повторите попытку.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }

                DbConnection.myCommand.CommandText = $@"delete from обучающиеся where id_обучающегося = '{id}'";
                DbConnection.myCommand.ExecuteNonQuery();

                System.Windows.Forms.MessageBox.Show(
                "Обучающийся удален!",
                "Успешно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Не удалось удалить обучающегося.\r\n" +
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
