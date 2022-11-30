using ISE.CodingChallenge.API.Model;
using System.Text.Json;
using Group = ISE.CodingChallenge.API.Model.Group;

namespace ISE.CodingChallenge.API;

public class GroupService : IGroupService
{
    private LiteDB.ILiteCollection<Group> Collection
    {
        get
        {
            return DBService.Instance.Database.GetCollection<Group>("groups");
        }
    }

    private static UserService _userService = new UserService();

    internal Task<Group> GetGroupObject(string GroupId)
    {
        GroupId = GroupId.ToLower();
        return Task.Run(() =>
        {
            var col = Collection;
            var group = col.FindById(GroupId);
            if (group == null)
            {
                throw new KeyNotFoundException($"key '{GroupId}' not found in group collection");
            }
            return group;
        });
    }

    public Task AddGroup(string Name, string Description, string GroupId)
    {
        GroupId = GroupId.ToLower();
        return Task.Run(() =>
        {
            var col = Collection;
            var newGroup = new Group()
            {
                Name = Name,
                MailNickname = GroupId,
                Description = Description
            };
            col.Insert(GroupId, newGroup);

            TransactionService.AddGroupTransaction("AddGroup", newGroup);
        });
    }

    public async Task<string> GetGroup(string GroupId)
    {
        var group = await GetGroupObject(GroupId);
        TransactionService.AddGroupTransaction("GetGroup", group);
        return JsonSerializer.Serialize<GroupInfo>(group);
    }

    public async Task RemoveGroup(string GroupId)
    {
        GroupId = GroupId.ToLower();
        var group = await GetGroupObject(GroupId);
        Collection.Delete(GroupId);
        TransactionService.AddGroupTransaction("RemoveGroup", group);
    }
    public async Task AddGroupMember(string GroupId, string UserId)
    {
        GroupId = GroupId.ToLower();
        UserId = UserId.ToLower();
        var group = await GetGroupObject(GroupId);

        var user = await _userService.GetUserObject(UserId);

        if (user == null)
        {
            throw new KeyNotFoundException($"key '{UserId}' not found in user collection");
        }
        group.Members.Add(UserId.ToLower(), user);
        Collection.Update(GroupId, group);
        TransactionService.AddGroupTransaction("AddGroupMember", group, UserId);
    }
    public async Task<string> GetGroupMembers(string GroupId)
    {
        var group = await GetGroupObject(GroupId);
        var members = group.Members.Values;
        TransactionService.AddGroupTransaction("GetGroupMembers", group);
        return JsonSerializer.Serialize(members);
    }
    public async Task RemoveGroupMember(string GroupId, string UserId)
    {
        GroupId = GroupId.ToLower();
        UserId = UserId.ToLower();
        var group = await GetGroupObject(GroupId);
        group.Members.Remove(UserId);
        Collection.Update(GroupId, group);
        TransactionService.AddGroupTransaction("RemoveGroupMember", group, UserId);
    }
    public async Task AddGroupOwner(string GroupId, string UserId)
    {
        GroupId = GroupId.ToLower();
        UserId = UserId.ToLower();
        var group = await GetGroupObject(GroupId);

        var user = await _userService.GetUserObject(UserId);

        if (user == null)
        {
            throw new KeyNotFoundException($"key '{UserId}' not found in user collection");
        }
        group.Owners.Add(UserId.ToLower(), user);
        Collection.Update(GroupId, group);
        TransactionService.AddGroupTransaction("AddGroupMember", group, UserId);
    }
    public async Task<string> GetGroupOwners(string GroupId)
    {
        var group = await GetGroupObject(GroupId);
        var members = group.Owners.Values;
        TransactionService.AddGroupTransaction("GetGroupMembers", group);
        return JsonSerializer.Serialize(members);
    }
    public async Task RemoveGroupOwner(string GroupId, string UserId)
    {
        GroupId = GroupId.ToLower();
        UserId = UserId.ToLower();
        var group = await GetGroupObject(GroupId);
        group.Owners.Remove(UserId);
        Collection.Update(GroupId, group);
        TransactionService.AddGroupTransaction("RemoveGroupMember", group, UserId);
    }
}
