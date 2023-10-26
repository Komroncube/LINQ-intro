
namespace LINQ.Homework24_10_2023
{
    public class Database
    {
        protected static string ConnectionString = "Server=DOTNET-DEVELOPE;Database=MessengerDemo;Trusted_Connection=True;";
        private static SqlConnection _connect;
        protected static SqlConnection connection
        {
            get
            {
                return _connect ?? (_connect = new SqlConnection(ConnectionString));
            }
        }
        public static void Initiate()
        {
            using (SqlConnection connection = new SqlConnection("context connection=true"))
            {
                connection.Open();
                string query = " IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'DataBase') " +
                                    "BEGIN" +
                                    "    CREATE DATABASE [MessengerDemo]" +
                                    "    END" +
                                    "    GO" +
                                    "       USE [MessengerDemo]" +
                                    "    GO" +
                                    "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' and xtype='U')" +
                                    "BEGIN" +
                                    "    create table Users(" +
                                    "       Id integer IDENTITY(1,1) primary key," +
                                    "       USER_NAME varchar(255) UNIQUE," +
                                    "       USER_PASS VARCHAR(8)," +
                                    "       COUNTRY varchar(255)," +
                                    "       CITY varchar(255)," +
                                    "       CREATED_AT DATETIME DEFAULT GETDATE()," +
                                    "       UPDATE_AT DATETIME," +
                                    "    );" +
                                    "END" +
                                    "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Messages' and xtype='U')" +
                                    "BEGIN" +
                                    "    create table Messages (" +
                                    "       id integer IDENTITY(1,1) primary key," +
                                    "       SenderId integer foreign key REFERENCES Users(id)," +
                                    "       RecepientId integer foreign key REFERENCES Users(id)," +
                                    "       MessageText text," +
                                    "       Created_at datetime default getdate()," +
                                    "); " +
                                    "END";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

            }
        }
        public static int GetId(string username)
        {
            connection.Open();
            connection.ConnectionString = ConnectionString;

            string query = $"Select id from Users where user_name = {username}";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                string idstring = string.Empty;
                while(reader.Read())
                {
                    idstring = reader.GetString(0);

                }
                bool check = int.TryParse(idstring, out int id);
                return id;
            }

        }
    }
}
