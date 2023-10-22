namespace LINQ
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public float Salary { get; set; }
        public string? Level { get; set; }
        public List<string>? Companies { get; set; }
        public List<string> Languages { get; set; }
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() 
                {
                    Id = 1001,
                    Age = 15,
                    FirstName = "Rustambek",
                    LastName = "Jurayev",
                    Salary = 200,
                    Level = "Stajor",
                    Companies = new List<string>
                    {
                        "item 1", "item 2"
                    },
                    Languages = new List<string>
                    {
                        "rus tili", "ingliz tili"
                    }
                },
                new Employee() 
                { 
                    Id = 1002, 
                    Age = 20, 
                    FirstName = "Sevinch", 
                    LastName = "Xaryriddinova", 
                    Salary = 300, 
                    Level = "Middle",
                    Companies = new List<string>
                    {
                        "item 1", "item 2"
                    },
                    Languages = new List<string>
                    {
                        "koreys tili", "xitoy tili"
                    }
                },
                //new Employee() { Id = 1003, Age = 20, FirstName = "Nurmuhammad", LastName = "Sharobiddinov", Salary = 240, Level = "Junior" },
                //new Employee() { Id = 1004, Age = 20, FirstName = "Bahriddin", LastName = "Abdusalomov", Salary = 1600, Level = "Strong Junior" },
                //new Employee() { Id = 1005, Age = 23, FirstName = "Nurmuhammad", LastName = "Sharobiddinov", Salary = 450, Level = "Middle" },
                //new Employee() { Id = 1005, Age = 23, FirstName = "Muhammad Abdulloh", LastName = "Komilov", Salary = 1700, Level = "Strong Middle" },
            };
            return employees;
        }
    }
}
