namespace LINQ.Homework24_10_2023.Services;

public class UserService : Database
{
    public static int CreateUser(User user)
    {
        connection.Open();

        string query = $"Insert into Users(user_name, user_pass, country, city) values ('{user.Name}', '{user.Password}', '{user.Country}', '{user.City}');";
        SqlCommand command = new SqlCommand(query, connection);
        
        var res = command.ExecuteNonQuery();
        connection.Close();
        return res;
    }
    public static List<User> GetUsers() 
    {
        connection.Open();
        var users = new List<User>();
        string query = $"Select id, user_name, user_pass from users";
        SqlCommand command = new SqlCommand(query, connection);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while(reader.Read())
            {
                var user = new User();
                user.Id = int.Parse(reader[0].ToString());
                user.Name = reader[1].ToString();
                user.Password = reader[2].ToString();
                users.Add(user);
            }
        }
        connection.Close();
        return users;
    }
    public static bool isExist(string username)
    {
        var users = GetUsers();
        User? user = users.FirstOrDefault(x=>x.Name==username);
        return user != null;

    }
}
