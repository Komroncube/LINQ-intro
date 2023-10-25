using System.Data.SqlClient;

namespace LINQ.Homework24_10_2023
{
    public class Messenger
    {
        
        public void CreateUser()
        {
            Console.WriteLine("User ni yaratish.");
            Console.Write("Usernameni kiriting: ");
            var username = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection())
            {

            }
        }
        public static void Greeting()
        {

        }
    }
}

