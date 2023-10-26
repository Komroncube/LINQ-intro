namespace LINQ.Homework24_10_2023.Services;

public class MessageService : Database
{
    public static void SendMessage(string sender, string recepient, string messageText)
    {
        int senderid = GetId(sender);
        int recieverid = GetId(recepient);
        connection.Open();
        string query = $"insert into Users(senderid, recepientid, MessageText) values ({senderid}, {recieverid}, {messageText});";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.ExecuteNonQuery();
    }
    public static void GetMessages()
    {

    }
}
