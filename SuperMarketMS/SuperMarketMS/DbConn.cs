using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace SuperMarketMS
{
    public class DbConn
    {

        public MySqlConnection connection;
        public DbConn()
        {
            Initialize();
        }
        private void Initialize()
        {
            //public String connString = "server=127.0.0.1; database=bar; uid=root; password=1234; port=3306;";
            string server = ConfigurationManager.AppSettings.Get("dbServer");
            string database = ConfigurationManager.AppSettings.Get("dbName"); ;
            string uid = ConfigurationManager.AppSettings.Get("dbUser"); ;
            string password = ConfigurationManager.AppSettings.Get("dbPassword"); ;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + 
                uid + ";" + "PASSWORD=" + password + ";";
             connection = new MySqlConnection(connectionString);
        }
        public bool OpenConnection()
        {
            try
            {
                connection.Close();
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }  
}
