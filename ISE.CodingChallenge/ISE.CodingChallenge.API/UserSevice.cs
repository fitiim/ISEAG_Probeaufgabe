using System.Text.Json;
using ISE.CodingChallenge.API.Model;

namespace ISE.CodingChallenge.API;

public class UserService : IUserService
{
    private LiteDB.ILiteCollection<User> Collection
    {
        get
        {
            return DBService.Instance.Database.GetCollection<User>("users");
        }
    }

    public Task AddUser(string Name, string MailNickname)
    {
        return Task.Run(() =>
        {
            var col = Collection;
            col.Insert(MailNickname.ToLower(), new User()
            {
                Name = Name,
                MailNickname = MailNickname
            });
            TransactionService.AddTransaction("AddUser", MailNickname);
        });
    }

    public async Task<string> GetUser(string MailNickname)
    {
        var user = await GetUserObject(MailNickname);
        TransactionService.AddTransaction("GetUser", MailNickname);
        return JsonSerializer.Serialize(user);
    }

    internal Task<User> GetUserObject(string MailNickname)
    {
        return Task.Run(() =>
        {
            var col = Collection;
            var user = col.FindById(MailNickname.ToLower());
            if (user == null)
            {
                throw new KeyNotFoundException($"key '{MailNickname}' not found in user collection");
            }
            return user;
        });
    }

    public Task<string> GetUsers()
    {
        return Task.Run(() =>
        {
            var col = Collection;
            var users = col.FindAll();
            if (users == null || users.Count() <= 0)
            {
                return "[]";
            }
            TransactionService.AddTransaction("GetUsers");
            return JsonSerializer.Serialize(users);
        });
    }

    public Task RemoveUser(string MailNickname)
    {
        return Task.Run(() =>
        {
            var col = Collection;
            var user = col.FindById(MailNickname);
            if (user == null)
            {
                throw new KeyNotFoundException($"key '{MailNickname}' not found in collection");
            }
            col.Delete(MailNickname);
            TransactionService.AddTransaction("RemoveUser", MailNickname);
        });
    }
}
