using LINQ.Homework24_10_2023.Services;
using Sharprompt;
using System.Data.SqlClient;

namespace LINQ.Homework24_10_2023
{
    public class MessengerApplication
    {
        public static void Run()
        {
            
            Console.WriteLine("Assalomu alaykum. Ketmon messengeriga xush kelibsiz");
            Greeting();
            
        }
        private static string currentUser;
        private static void Greeting()
        {
            Console.WriteLine("Assalomu alaykum. Ketmon messengeriga xush kelibsiz");
            var choice = Prompt.Select("", new[] { "Kirish", "Ro'yxatdan o'tish", "Exit" });
            switch (choice)
            {
                case "Kirish":
                    Console.Clear();
                    Login();
                    break;
                case "Ro'yxatdan o'tish":
                    Console.Clear();
                    Register(); 
                    break;
            }

        }
        private static void Login()
        {

        }
        private static void Register()
        {
            var user = new User();
            name:
            Console.Write("Username: ");
            user.Name = Console.ReadLine();

            bool check = UserService.isExist(user.Name);
            if(check)
            {
                Console.WriteLine("Username ni qaytadan kiriting");
            }

            Console.WriteLine("Parolni kiriting: ");
        }
        
    }
}
