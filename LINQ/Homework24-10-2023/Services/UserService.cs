namespace LINQ.Homework24_10_2023.Services;

public class UserService : Database
{
    public static int CreateUser(User user)
    {
        connection.Open();

        string query = $"Insert into Users(user_name, user_pass, country, city) values ({user.Name}, {user.Password}, {user.Country}, {user.City});";
        SqlCommand command = new SqlCommand(query, connection);
        
        var res = command.ExecuteNonQuery();
        return res;
    }
    public static int GetId(string username)
    {
        connection.Open();
        connection.ConnectionString = ConnectionString;

        string query = $"Select id from Users where user_name = {username}";
        SqlCommand command = new SqlCommand(query, connection);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            string idstring = string.Empty;
            while (reader.Read())
            {
                idstring = reader.GetString(0);
                break;
            }
            bool check = int.TryParse(idstring, out int id);
            return id;
        }

    }
    public static bool isExist(string username)
    {
        return GetId(username) != 0;
    }
}
