using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public static void DeleteTable(string tablename, string database)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = $"Server=DOTNET-DEVELOPE;Database={database};Trusted_Connection=True;";
                connection.Open();
                string query = $"drop table {tablename}";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.ExecuteNonQuery();
            }


        }
        public static void UpdateTable(string tablename, string database, string updatetext)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = $"Server=DOTNET-DEVELOPE;Database={database};Trusted_Connection=True;";
                connection.Open();

                var columnName = new List<string>();
                List<string> columns;
                string query = $"select top 1 * from {tablename}";
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                int count = 0;
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    count = reader.FieldCount;
                    var collection = reader.GetColumnSchema();
                    columns = collection.Select(x => x.ColumnName).ToList();
                }
                var values = updatetext.Split(',');
                if (values.Length != count)
                {
                    Console.WriteLine("Xato data kiritildi");
                    return;
                }
                var joinedItems = columns.Skip(1).Zip(values.Skip(1), (item1, item2) => $"{item1} = {item2.Trim()}");
                var update = string.Join(",", joinedItems);
                
                var createQuery = $"Update {tablename} set {update} where {columns[0]} = {values[0]}";
                sqlCommand = new SqlCommand(createQuery, connection);
                
                var res = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{res} rows affected");


            }
        }
    }
}
