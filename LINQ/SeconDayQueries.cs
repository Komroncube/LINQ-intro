using System.Text.RegularExpressions;

namespace LINQ
{
    public class SeconDayQueries
    {
        public static void Run()
        {
            var students = Student.GetAllStudents;

            //method syntax
            //var res = students.OrderBy(x => x.FirstName).ToList();
            //res.ForEach(x => Console.WriteLine(x.FirstName));

            // query syntax + mixed

            //var qs = (from x in students
            //         orderby x.LastName ascending
            //         select x).Where(x=>x.Age>20).ToList();
            //qs.ForEach(x=> Console.WriteLine(x.LastName + " " + x.Age));

            //students.Reverse();

            //thenby
            //var result = students.OrderBy(x => x.Age)
            //                        .ThenBy(z => z.Course)
            //                        .ThenByDescending(y => y.FirstName)
            //                        .ToList();
            IEnumerable<Student> result;
            result = from x in students
                         orderby x.Contract descending, x.Age, x.FirstName
                         select x;
            /*
            1. ism bo'yicha
            2. kursiga qarab desc
            3. kontrakt asc
            4. yoshi desc
            */
            result = students.OrderBy(x=>x.FirstName)
                                .ThenByDescending(x=>x.Course)
                                .ThenBy(x=>x.Contract)
                                .ThenByDescending(x=>x.Age);

            var sq = from x in students
                     orderby x.FirstName, 
                                x.Course descending, 
                                x.Contract, 
                                x.Age descending
                     select x;

            var mix = (from x in students
                      orderby x.FirstName,
                                x.Course descending
                                select x).ThenBy(x=>x.Contract).ThenByDescending(x=>x.Age);


            //var avg = students.Average(x => x.Contract);
            //Console.WriteLine("O'rtacha {0}", avg);



            //result = students.DistinctBy(x => x.FirstName);
            //students.Distinct();

            //List<string> names = new List<string> { "hello", "world", "coding", "hello", "Hello"};

            //var res = names.DistinctBy(x=>x.ToLower());
            //var res2 = names.DistinctBy(x => Regex.IsMatch(x, "he"));

            //var res3 = names.DistinctBy(x => StringComparer.CurrentCultureIgnoreCase);
            //foreach (string name in res)
            //{
            //    Console.WriteLine(name);
            //}

            bool IsSirtqi = students.Any(x => x.isDistance);
            result = students.Where(x => x.isDistance);

            Console.WriteLine(IsSirtqi);


            foreach (var student in result)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", student.FirstName, student.LastName, student.Age, student.Course, student.Contract, student.isDistance);
            }

        }
    }
}
