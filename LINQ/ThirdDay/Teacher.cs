namespace LINQ.ThirdDay
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string Spetiality { get; set; }
        public int TechCourse { get; set; }
        public bool isDistance { get; set; }
        public static List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher { Id = 1, FirstName = "Asror", Age = 27, Spetiality = "Dasturlash", TechCourse = 1, isDistance=true },
                new Teacher { Id = 2, FirstName = "Muhammad Abdulloh", Age = 23, Spetiality = "DotNet", TechCourse = 2, isDistance = true },
                new Teacher { Id = 3, FirstName = "Rustambek", Age = 15, Spetiality = "Backend", TechCourse = 4 , isDistance = false},
                new Teacher { Id = 4, FirstName = "Nodir", Age = 29, Spetiality = "Frontend", TechCourse = 3 , isDistance = false}
            };

            return teachers;

        }

    }

    
}
