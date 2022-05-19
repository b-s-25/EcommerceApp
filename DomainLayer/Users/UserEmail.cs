using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Users
{
    public class UserEmail
    {
        public List<string> toEmails { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public List<KeyValuePair<string, string>> placeHolders { get; set; }
    }
}
