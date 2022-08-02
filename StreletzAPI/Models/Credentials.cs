using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI
{
    public class Credentials
    {
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string ConnectionId { get; set; }
        public string[] AllowedToBrodcastEvents { get; set; }
    }
}
