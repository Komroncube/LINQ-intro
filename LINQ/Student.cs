namespace LINQ
{
    public class Student : IEquatable<Student>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Credit { get; set; }
        public decimal Contract { get; set; }
        public string UniversityName { get; set; }
        public string UniversityFaculty { get; set; }
        public string UniversityBranch { get; set; }
        public int Course { get; set; }
        public bool isDistance { get; set; }

        public static List<Student> GetAllStudents { get; set; } = new List<Student>()
        {

            new Student()
            {
                Id=1,
                FirstName = "Rustambek",
                LastName = "Jurayev",
                Age = 23,
                Credit = 4,
                Contract = 9_000_000,
                UniversityName = "MIT",
                UniversityBranch = "New-York",
                UniversityFaculty = "AI",
                Course = 2,
                isDistance = true,
            },
            new Student()
            {
                Id=2,
                FirstName = "Jonpo'lat",
                LastName = "Sobirov",
                Age = 20,
                Credit = 0,
                Contract = 8_500_000,
                UniversityName = "Agrar universiteti",
                UniversityBranch = "Farg'ona",
                UniversityFaculty = "Pillachilik",
                Course=3,
                isDistance = false,
            },
            new Student()
            {
                Id=3,
                FirstName = "Toshmat",
                LastName = "Yo'ldoshev",
                Age = 24,
                Credit = 3,
                Contract = 11_000_000,
                UniversityName = "INHA",
                UniversityBranch = "Toshkent",
                UniversityFaculty = "Logistika",
                Course = 4,
                isDistance= false,
            },
            new Student()
            {
                Id=4,
                FirstName = "Sevara",
                LastName = "Ahadova",
                Age = 22,
                Credit = 3,
                Contract = 12_000_000,
                UniversityName = "AJOU",
                UniversityBranch = "Navoiy",
                UniversityFaculty = "Kompyuter ilmi",
                Course = 5,
                isDistance= false,
            },
            new Student()
            {
                Id=5,
                FirstName = "Nigora",
                LastName = "Erkinova",
                Age = 23,
                Credit = 0,
                Contract = 8_000_000,
                UniversityName = "Milliy Universiteti",
                UniversityBranch = "Samarqand",
                UniversityFaculty = "Matematika",
                Course = 1,
                isDistance = true,
            },
            new Student()
            {
                Id=6,
                FirstName = "Oydin",
                LastName = "Akbarova",
                Age = 21,
                Credit = 4,
                Contract = 16_000_000,
                UniversityName = "SamDu",
                UniversityBranch = "Samarqand",
                UniversityFaculty = "Menejment",
                Course = 2,
                isDistance = false,
            },
            new Student { Id = 1, FirstName = "AbduRustambek", LastName = "Jurayev", Age = 23, Credit = 8,
                    Contract = 9_000_000, UniversityBranch = "Toshkent", UniversityName = "Irrigatsiya",
                    UniversityFaculty = "Qishloq xo'jaligi", Course = 1, isDistance = true },

                new Student { Id = 2, FirstName = "Nurmuhammad", LastName = "SHarobiddinov", Age = 20, Credit = 8,
                    Contract = 9_000_000, UniversityBranch = "Anjan", UniversityName = "ADU",
                    UniversityFaculty = "Komputer Science", Course = 3, isDistance = true },

                new Student { Id = 3, FirstName = "Hushnud", LastName = "Kamolov", Age = 33, Credit = 21,
                    Contract = 10_200_000, UniversityBranch = "Samarqand", UniversityName = "SAMDU",
                    UniversityFaculty = "Fizika", Course = 2, isDistance = false },

                new Student { Id = 4, FirstName = "Mirqosim", LastName = "Uzoqov", Age = 28, Credit = 40,
                    Contract = 7_000_100, UniversityBranch = "Buhoro", UniversityName = "INHA",
                    UniversityFaculty = "Logistika", Course = 4, isDistance = false},

                new Student { Id = 4, FirstName = "Abdusalom", LastName = "Abdusalomov", Age = 28, Credit = 40,
                    Contract = 7_000_100, UniversityBranch = "Buhoro", UniversityName = "INHA",
                    UniversityFaculty = "Logistika", Course = 4 , isDistance = true},

                new Student { Id = 4, FirstName = "Bahriddin", LastName = "Axunov", Age = 28, Credit = 40,
                    Contract = 7_000_100, UniversityBranch = "Buhoro", UniversityName = "INHA",
                    UniversityFaculty = "Logistika", Course = 4 , isDistance = false},

                new Student { Id = 5, FirstName = "Jonpo'lat", LastName = "Jurayev", Age = 23, Credit = 10,
                    Contract = 9_000_000, UniversityBranch = "Namangan", UniversityName = "Madrasa",
                    UniversityFaculty = "Tafseer", Course = 1 , isDistance = false},

                new Student { Id = 6, FirstName = "Sevinch", LastName = "Xayriddinova", Age = 31, Credit = 15,
                    Contract = 15_300_700, UniversityBranch = "Qashqadaryo", UniversityName = "TATU",
                    UniversityFaculty = "Komputer Injiniringi", Course = 3 , isDistance = false},

                new Student { Id = 7, FirstName = "Farxodbek", LastName = "Madrahimov", Age = 27, Credit = 32,
                    Contract = 4_000_000, UniversityBranch = "Xorazm", UniversityName = "Urganch University",
                    UniversityFaculty = "Matematika", Course = 5 , isDistance = false},

                new Student { Id = 8, FirstName = "Farxodbek", LastName = "Rustamov", Age = 19, Credit = 57,
                    Contract = 13_000_000, UniversityBranch = "Farg'ona", UniversityName = "KIUF",
                    UniversityFaculty = "Kareys tili", Course = 2 , isDistance = false},
        };

        public bool Equals(Student? other)
        {
            // Taqqoslanayotgan obyektlarni null yoki null emasligini tekshirish
            if (ReferenceEquals(other, null)) return false;

            // Taqqoslanayotgan obyektlar aynan bitta ma'lumotning havolasimi yoki yo'qligini tekshirish        
            if (ReferenceEquals(this, other)) return true;

            // Taqqoslanayotgan obyektlarning barcha xususiyat (property)lari bir xil ekanligini tekshirish
            return Id.Equals(other.Id)
                    && FirstName.Equals(other.FirstName)
                    && LastName.Equals(other.LastName)
                    && Age.Equals(other.Age)
                    && Credit.Equals(other.Credit)
                    && Contract.Equals(other.Contract)
                    && UniversityName.Equals(other.UniversityName);
                    
                    
                    ;
        }
    }
}
