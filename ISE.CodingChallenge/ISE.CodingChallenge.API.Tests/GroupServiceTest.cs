using ISE.CodingChallenge.API.Model;

namespace ISE.CodingChallenge.API.Tests;

public class GroupServiceTest : IDisposable
{
    public GroupServiceTest()
    {
        DBService.Instance.Clear();
    }
    [Fact]
    public async Task AddGroupTest()
    {
        using var dbService = DBService.Instance;
        var service = new GroupService();
        await service.AddGroup("my group", "meine gruppe", "grp-my-group@test.ch");
        var grp = await service.GetGroup("Grp-my-group@test.ch");
        Assert.NotNull(grp);
        Assert.Equal("""{"MailNickname":"grp-my-group@test.ch","Name":"my group","Description":"meine gruppe"}""", grp);

        await service.RemoveGroup("Grp-my-group@test.ch");

        await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
        {
            await service.GetGroup("Grp-my-group@test.ch");
        });
    }

    [Fact]
    public async Task AddGroupMemberTest()
    {
        using var dbService = DBService.Instance;
        var service = new GroupService();
        await service.AddGroup("my group", "meine gruppe", "grp-my-group2@test.ch");
        var userService = new UserService();
        await userService.AddUser("My Name", "my.name@my.me");
        await service.AddGroupMember("Grp-my-group2@test.ch", "my.name@my.me");
        var members = await service.GetGroupMembers("Grp-my-group2@test.ch");
        Assert.NotNull(members);
        Assert.Equal("""[{"Name":"My Name","MailNickname":"my.name@my.me"}]""", members);

        await service.RemoveGroupMember("Grp-my-group2@test.ch", "my.name@my.me");

        var empty = await service.GetGroupMembers("Grp-my-group2@test.ch");
        Assert.Equal("[]", empty);
    }




    public void Dispose()
    {
        //DBService.Instance.Clear();
        DBService.Instance.Dispose();
    }
}