namespace LINQ.ThirdDay
{
    public class Query
    {
        public static void Run()
        {
            var students = Student.GetAllStudents;
            var teachers = Teacher.GetAllTeachers();
            var result = teachers.GroupJoin(students,
                teacher => teacher.TechCourse,
                student => student.Course,
                (teacher, student) => new
                {
                    teachername = teacher.FirstName,
                    students = student
                });
            var result1 = students.Join(teachers,
                std => (std.Course, std.isDistance),
                teach => (teach.TechCourse, teach.isDistance),
                (std, teach) => new
                {
                    stdname = std,
                    students = teach
                });

            var result3 = from teacher in teachers
                          join student in students
                          on (teacher.TechCourse, teacher.isDistance) equals (student.Course, student.isDistance)
                          into teachergroup
                          select new
                          {
                              teachers = teachergroup,
                              std = teachergroup,
                          };
            Console.WriteLine();

           
            /*
             SELECT s.first_name, s.last_name, c.kindergarten, c.graduation_year, c.class, c.classroom
            FROM students s
            JOIN classes c
            ON s.kindergarten = c.kindergarten AND s.graduation_year = c.graduation_year AND s.class = c.class;
             */
            Console.WriteLine();
            teachers.Single();


            foreach (var item in result)
            {
                Console.WriteLine($"ismi: {item.teachername} ");
                foreach(var std in item.students)
                {
                    Console.WriteLine($"        {std.FirstName} {std.UniversityName}, isdistance {std.isDistance}, kursi: {std.Course}");
                }
            }
        }
    }
}
