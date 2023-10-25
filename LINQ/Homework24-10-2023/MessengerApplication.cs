using System.Data.SqlClient;

namespace LINQ.Homework24_10_2023
{
    public class MessengerApplication
    {
        private static string ConnectionString = "Server=DOTNET-DEVELOPE;Database=MessengerDemo;Trusted_Connection=True;";
        public void Run()
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
                                    "       Sender integer foreign key REFERENCES Users(id)," +
                                    "       Recepient integer foreign key REFERENCES Users(id)," +
                                    "       MessageText text," +
                                    "       Created_at datetime default getdate()," +
                                    "); " +
                                    "END" +
                                    "IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 's')\r\nBEGIN\r\nCREATE PROCEDURE sp_1\r\nAS\r\n.................\r\nEND\r\nGO"
                                    ;
            }
            Console.WriteLine("Assalomu alaykum. Ketmon messengeriga xush kelibsiz");
            Console.WriteLine("1.Tizimga kirish");
            
        }
        private static string currentUser;
        private void Greeting()
        {
            Console.WriteLine("Assalomu alaykum. Ketmon messengeriga xush kelibsiz");
            while(true)
            {
                Console.WriteLine("1.Tizimga kirish");
                Console.WriteLine("2.Ro'yxatdan o'tish");
                Console.Write("Buyruqni kiriting: ");
                var commands = new int[] { 1, 2 };
                bool check = int.TryParse(Console.ReadLine(), out int command);
                if (!(check && commands.Contains(command)))
                {
                    Console.Clear();
                    Console.WriteLine("Buyruqni bajarishda xatolik yuz berdi");
                    continue;
                }
                switch(command)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;
                }
            }

        }
        private void Login()
        {

        }
        private void Register()
        {

        }
        
    }
}
