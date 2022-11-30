using ISE.CodingChallenge.API.Model;

namespace ISE.CodingChallenge.API.Tests;

public class UserServiceTest : IDisposable
{
    public UserServiceTest()
    {
        DBService.Instance.Clear();
    }
    [Fact]
    public async Task AddUserTest()
    {
        using var dbService = DBService.Instance;
        var service = new UserService();
        await service.AddUser("My Name", "my.name@my.me");
        var user = await service.GetUser("my.name@my.Me");
        Assert.NotNull(user);
        Assert.Equal("""{"Name":"My Name","MailNickname":"my.name@my.me"}""", user);

        await service.RemoveUser("my.name@my.Me");

        await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
        {
            await service.GetUser("my.name@my.Me");
        });
    }




    public void Dispose()
    {
        DBService.Instance.Clear();
        DBService.Instance.Dispose();
    }
}