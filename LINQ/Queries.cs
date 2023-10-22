using System.Threading.Channels;

namespace LINQ
{
    public class Queries
    {
        public static void Run()
        {
            /*simple query
            List<int> numbers = new List<int>() { 3, 3, 4, 35, 5, 6, 4342, 1, 32, 543, 54, 435, 34, 54232 };

            List<string> names = new List<string> { "hello", "world", "coding" };


            //method syntax 

            //IEnumerable<int> query = numbers.Where(x=>x%2 == 0);
            

            //Select * from numbers;
            //var query = from x in numbers select x;
            
            
            //List<int> query2 = (from x in numbers select x).ToList();
            //List<int> query = (from x in numbers
            //                   where x%3 == 0 && x%2!=0
            //                   select x).ToList();

            //query syntax
            var qs = from number in numbers
                     where number == 1
                     select number;

            var strquery = from x in names
                           where x.Contains("wo")
                           select x;


            //mixed syntax
            var query = (from x in numbers select x).Where(x => x % 2 == 1);
            
            foreach(var number in query)
            {
                Console.WriteLine(number);
            }
            */

            var employees = Employee.GetEmployees();
            /*21-10-2023
            //var empSalary = from salary in employees
            //                select salary.Salary;

            //var empData = from salary in employees
            //              select (salary.FirstName, salary.Level, salary.Salary);

            //var empMethodData = employees.Select(x => (x.LastName, x.Age, x.Level)).ToList();
            //foreach(var emp in empMethodData)
            //{
            //    Console.WriteLine(emp.LastName + " "+ emp.Level + " "+ emp.Age);
            //}


            //var yearsalary = employees.Select(x => (x.FirstName, x.LastName, x.Age, x.Salary)).ToList();

            //foreach (var emp in yearsalary)
            //{
            //    Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.Age + " " + emp.Salary * 12);
            //}
            //var employeeSalary = yearsalary.OrderBy(x => x.Salary).ToList();

            //var employee = employeeSalary[0];
            //Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Age + " " + employee.Salary * 12);


            //var yearanonim = employees.Select(x => new
            //{
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    Age = x.Age,
            //    Salary = x.Salary * 12,
            //});
            //foreach(var emp in yearanonim)
            //{
            //    Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.Age + " " + emp.Salary * 12);

            //}

            //var companies = employees.SelectMany(
            //    x=> x.Companies,
            //    (parent, child) => new { parent.FirstName, child }).ToList();


            //var comps = from comp in employees
            //            from comp2 in comp.Companies
            //            select (comp.FirstName, comp2);


            //foreach(var comp in comps)
            //{
            //    Console.WriteLine(comp);
            //}


            //List<string> people = new List<string>() { "olim", "anvar", };
            //List<string> languages = new List<string>() { "russian", "english" };

            //var mix = people.SelectMany(lang => languages, (x,y) => new {x, y});
            //foreach(var item in mix)
            //{
            //    Console.WriteLine(item);
            //}

            */


            #region homework
            /*
            var colls = employees.SelectMany(x => x.Companies,
                (parent, child) => new { 
                    emp = parent,
                    comany = child
                })
                .SelectMany(y => y.emp.Languages, (parent, child) =>  new
                {
                    ismi = parent.emp.FirstName, 
                    comany = parent.comany,
                    tili = child
                });

            foreach (var coll in colls)
            {
                Console.WriteLine(coll);
            }
            */
            #endregion

            //var res = employees.ToLookup(item => item.Id).ToList();
            //foreach (var item in res)
            //{
            //    Console.Write(item.Key);
            //    foreach (var x in item)
            //    {
            //        Console.WriteLine(x.FirstName + " " + x.LastName);
            //    }
            //}
            //var sorting = employees.OrderByDescending(x => x.Age).ThenBy(x => x.FirstName);
            //foreach(var item in sorting)
            //{
            //    Console.WriteLine(item.FirstName + item.Age);
            //}

            

        }
    }
}
