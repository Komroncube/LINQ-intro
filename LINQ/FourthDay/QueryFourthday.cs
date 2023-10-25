using System.Collections;
using System.Data.SqlClient;

namespace LINQ.FourthDay
{
    public class QueryFourthday
    {
        public static void Run()
        {
            //ArrayList arrayList = new ArrayList() { 2, 4, 5, 6, 7, 8, 9 };
            //var result = arrayList.Cast<int>();
            ////foreach (var item in result)
            ////{
            //// //   Console.WriteLine(item);
            ////}
            //var students = Student.GetAllStudents;
            ////var result2 = students.ToDictionary<Student, int>(x => x.Id);
            //var dicts = new Dictionary<int, string>();
            //dicts.Add(1, "hello");
            //dicts.Add(2, "super");

            //Console.WriteLine(dicts);


            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=DOTNET-DEVELOPE;Database=LMS;Trusted_Connection=True;";
                connection.Open();

                string query = "select * from fruits";
                SqlCommand cmd = new SqlCommand(query, connection);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var n = reader.FieldCount;
                        for(int i  = 0; i < n; i++)
                        {
                            Console.Write("{0}\t", reader[i]);
                        }
                        Console.WriteLine();
                    }
                }
            }

        }
    }
}
