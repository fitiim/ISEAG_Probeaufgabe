using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.CodingChallenge.Service
{
    public class MappedCsv
    {
        public string first_name { get; set; }
        public string last_name { get; set; }

        public MappedCsv(string firstname, string lastname)
        {
            first_name = firstname;
            last_name = lastname;
        }
    }
}
