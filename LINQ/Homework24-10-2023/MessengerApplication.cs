using LINQ.Homework24_10_2023.Services;
using Sharprompt;
using System.Data.SqlClient;

namespace LINQ.Homework24_10_2023
{
    public class MessengerApplication
    {
        public static void Run()
        {
            Database.Initiate();
            Greeting();
            
        }
        private static int currentUser;
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
                case "Exit":
                    return;
            }

        }
        private static void Login()
        {
            retylogin:
            Console.Write("Username ni kiriting: ");
            string username = Console.ReadLine();

            Console.Write("Passwordni kiriting: ");
            string pass = Console.ReadLine();

            var users = UserService.GetUsers();
            var user = users.FirstOrDefault(x=>x.Name==username && x.Password == pass);
            if (user == null) 
            {
                Console.WriteLine("Username yoki password xato kiritildi.");
                Console.Clear();
                Console.WriteLine("Qaytadan kiriting.");
                goto retylogin;
            }
            currentUser = user.Id;
            SendMessage();

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
                Console.WriteLine("Bunday username mavjud, boshqa usernameni kiriting");
                goto name;
            }

        pass:
            Console.WriteLine("Parolni kiriting (kamida 4ta belgi): ");
            user.Password = Console.ReadLine();
            if(user.Password.Length<4)
            {
                Console.WriteLine("Xato parol kiritildi.");
                goto pass;
            }

            Console.WriteLine("Davlatni kiriting: ");
            user.Country = Console.ReadLine();

            Console.WriteLine("Shaharni kiriting: ");
            user.City = Console.ReadLine();

            var res = UserService.CreateUser(user);
            Console.Clear();
            if (res==0)
            {
                Console.WriteLine("User yaratilmadi :(");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("User yaratildi :)");
            }
            Greeting();
        }
        private static void SendMessage()
        {
            recinput:
            Console.Write("Kimga xabar yozmoqchisiz: ");
            var recepient = Console.ReadLine();


            var users = UserService.GetUsers();
            var rec = users.FirstOrDefault(x=>x.Name ==  recepient);
            if (rec==null)
            {
                Console.WriteLine("Bunday user topilmadi!");
                goto recinput;
            }    
            var recId = rec.Id;

            Console.Clear();
            var messages = MessageService.GetMessages(currentUser, recId);
            messages= messages.DistinctBy(x=>x.Id).ToList();
            foreach(var message in messages)
            {
                if(message.RecepientId!=recId)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"FROM {rec.Name}:   {message.MessageText}");
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"FROM you: {message.MessageText}");

                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Xabar: ");
            var text = Console.ReadLine();


            MessageService.SendMessage(currentUser, recId, text);

            Console.Clear();
            Console.WriteLine("Xabar jo'natildi");

            var choice = Prompt.Select("", new[] {"Bosh sahifaga qaytish", "Yana xabar jo'natish", "Dasturni tugatish" });
            switch (choice)
            {
                case "Bosh sahifaga qaytish":
                    Console.Clear();
                    Greeting(); break;
                case "Yana xabar jo'natish":
                    Console.Clear();
                    SendMessage();return;
                case "Dasturni tugatish":
                    return;
            }

        }
        
        
    }
}
