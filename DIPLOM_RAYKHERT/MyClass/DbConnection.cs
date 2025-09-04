using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIPLOM_RAYKHERT.MyForm;
using MySql.Data.MySqlClient;

namespace DIPLOM_RAYKHERT.MyClass
{
    internal class DbConnection
    {
        static public MySqlCommand myCommand;
        static public MySqlConnection myConnection;
        static public MySqlDataAdapter MyDataAdapter;
        static public string user;
        static public string role;
        static public string fio;

        /// <summary>
        /// подключение к бд
        /// </summary>
        /// <param name="server_address"></param>
        /// <param name="database"></param>
        /// <param name="userr"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static public bool connect_Db(string server_address, string database,
            string userr, string password)
        {
            try
            {
                string ConnectionString = $@"Database={database}; 
                                            Datasource={server_address}; 
                                            user={userr}; 
                                            password={password};    
                                            charset=utf8;";
                myConnection = new MySqlConnection(ConnectionString);
                myConnection.Open();
                myCommand = new MySqlCommand();
                myCommand.Connection = myConnection;
                MyDataAdapter = new MySqlDataAdapter(myCommand);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                "Ошибка при подключении к базе данных! \r\n\r\nПерепроверьте адрес сервера и название базы данных",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false; 
            }
        }

        /// <summary>
        /// отключение от бд
        /// </summary>
        static public void close_Db()
        {
            myConnection.Close();
        }

        /// <summary>
        /// авторизация
        /// </summary>
        /// <param name="log"></param>
        /// <param name="pass"></param>
        static public void Authorization(string log, string pass)
        {
            try
            {
                myCommand.CommandText = $@"select роль from с_роли, пользователи
                                           where пользователи.id_роли = с_роли.id_роли 
                                           and пользователи.логин = '{log}' 
                                           and пользователи.пароль = md5('{pass}')";
                object result = myCommand.ExecuteScalar();
                if (result != null)
                {
                    role = result.ToString();
                    user = log;
                    DbConnection.myCommand.CommandText =
                        $@"select concat(пользователи.фамилия, ' ', пользователи.имя, ' ', пользователи.отчество) AS 'ФИО менеджера'
                        from пользователи where логин = '{log}'";
                    fio = Convert.ToString(myCommand.ExecuteScalar());
                } else
                {
                    role = null;
                    fio = "";
                }
            }
            catch
            {
                user = role = null;
                fio = "";
            }
        }
    }
}
