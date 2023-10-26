using System.Data.SqlClient;

namespace LINQ.Homework24_10_2023
{
    public class MessengerApplication
    {
        public void Run()
        {
            
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
