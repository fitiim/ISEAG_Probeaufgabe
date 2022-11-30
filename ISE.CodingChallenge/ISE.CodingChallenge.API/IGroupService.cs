using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.CodingChallenge.API
{
    public interface IGroupService
    {
        /// <summary>
        /// get group json-string by groupId/mailnickname
        /// </summary>
        /// <param name="GroupId">mailnickname of the group</param>
        /// <returns>json serialzed group</returns>
        Task<string> GetGroup(string GroupId);
        Task RemoveGroup(string GroupId);
        Task AddGroup(string Name, string Description, string GroupId);
        Task<string> GetGroupMembers(string GroupId);
        Task AddGroupMember(string GroupId, string UserId);
        Task RemoveGroupMember(string GroupId, string UserId);

        Task<string> GetGroupOwners(string GroupId);
        Task AddGroupOwner(string GroupId, string UserId);
        Task RemoveGroupOwner(string GroupId, string UserId);
    }
}
