namespace LINQ.Homework24_10_2023.Services;

public class MessageService : Database
{
    public static void SendMessage(int sender, int recepient, string messageText)
    {
        connection.Open();
        string query = $"insert into Messages(sender, recepient, MessageText) values ({sender}, {recepient}, '{messageText}');";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.ExecuteNonQuery();
        connection.Close();
    }
    public static List<Message> GetMessages(int sender, int recepient)
    {
        connection.Open();
        string query = $"select m.sender, m.recepient, m.MessageText, m.Created_At, m.Id from messages m " +
            $"inner join users u " +
            $"on (m.sender={sender} and m.recepient={recepient}) or (m.sender={recepient} and m.recepient={sender}) " +
            $"order by m.created_at";
        
        SqlCommand cmd = new SqlCommand (query, connection);

        var messages = new List<Message>();

        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            {
                var message = new Message();
                message.Id = int.Parse(reader[4].ToString());
                message.SenderId = int.Parse(reader[0].ToString());
                message.RecepientId = int.Parse(reader[1].ToString());
                message.MessageText = reader[2].ToString();
                message.CreatedAt = DateTime.Parse(reader[3].ToString());
                messages.Add(message);
            }
        }
        connection.Close();
        return messages;
    }
}
