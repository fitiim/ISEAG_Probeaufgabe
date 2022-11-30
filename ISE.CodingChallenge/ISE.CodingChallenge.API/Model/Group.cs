using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.CodingChallenge.API.Model
{
    public class GroupInfo
    {
        public string MailNickname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    public class Group : GroupInfo
    {
        public IDictionary<string, User> Members { get; set; } = new Dictionary<string, User>();
        public IDictionary<string, User> Owners { get; set; } = new Dictionary<string, User>();
    }
}
