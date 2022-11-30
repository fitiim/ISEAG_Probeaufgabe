using System.Text.Json;
using ISE.CodingChallenge.API.Model;

namespace ISE.CodingChallenge.API;

public class TransactionService
{
    private static LiteDB.ILiteCollection<Transaction> Collection
    {
        get
        {
            return DBService.Instance.Database.GetCollection<Transaction>("transactions");
        }
    }

    public static void AddTransaction(string Action, string EntityId = "", string Message = "")
    {
        var col = Collection;
        col.Insert(new Transaction()
        {
            Action = Action,
            EntityId = EntityId,
            Message = Message
        });
    }

    public static void AddGroupTransaction(string Action, Group Group, string Message = "")
    {
        var col = Collection;
        col.Insert(new Transaction()
        {
            Action = Action,
            Entity = Group,
            EntityId = Group.MailNickname,
            Message = Message
        });
    }

    public static string GetTransactions()
    {
        var col = Collection;
        var transactions = col.FindAll();
        if (transactions == null || transactions.Count() <= 0)
        {
            return "[]";
        }
        return JsonSerializer.Serialize(transactions);
    }
}
