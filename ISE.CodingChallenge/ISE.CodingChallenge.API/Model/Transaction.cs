using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.CodingChallenge.API.Model
{
    internal class Transaction
    {
        public string Message { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public object? Entity { get; set; }
        public string EntityId { get; set; } = string.Empty;
    }
}
