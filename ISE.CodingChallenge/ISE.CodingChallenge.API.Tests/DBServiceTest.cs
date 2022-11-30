using ISE.CodingChallenge.API.Model;

namespace ISE.CodingChallenge.API.Tests;

public class DBServiceTest
{
    [Fact]
    public void ClearDBTest()
    {
        using var dbService = DBService.Instance;
        var col = dbService.Database.GetCollection<User>("users");
        col.Insert((new Guid()).ToString(), new User
        {
            MailNickname="tess.tickle@fun.ny",
            Name = "Tess Tickle"
        });

        Assert.True(col.Count() > 0);

        DBService.Instance.Clear();
        col = dbService.Database.GetCollection<User>("users");
        Assert.True(col.Count() == 0);
    }
}