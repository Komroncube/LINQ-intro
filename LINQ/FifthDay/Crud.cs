using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.FifthDay
{
    public class Crud
    {
        public static void GetByExpression(string tablename, string database, string condition)
        {
            using(SqlConnection connection = new SqlConnection()) 
            {
                connection.ConnectionString = $"Server=DOTNET-DEVELOPE;Database={database};Trusted_Connection=True;";
                connection.Open();

                string query = $"select * from {tablename} where {condition}";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                using(SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    var collection = reader.GetColumnSchema();
                    int count = reader.FieldCount;
                    while (reader.Read())
                    {
                        for(int i=0; i<count; i++)
                        {
                            Console.Write($"{reader[i]}\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        public static void InsertData(string tablename, string database, string data)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = $"Server=DOTNET-DEVELOPE;Database={database};Trusted_Connection=True;";
                connection.Open();

                var columnName = new List<string>();
                string columns;
                string query = $"select top 1 * from {tablename}";
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                int count = 0;
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    count = reader.FieldCount;
                    var collection = reader.GetColumnSchema();
                    columns = string.Join(",", collection.Select(x => x.ColumnName));
                }
                var values = data.Split(',');
                if (values.Length != count)
                {
                    Console.WriteLine("Xato data kiritildi");
                    return;
                }
                var createQuery = $"Insert into {tablename} ({columns}) values ({data}) ";
                sqlCommand = new SqlCommand(createQuery, connection);
                var res = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{res} rows affected");

            }
        }
    }
}
