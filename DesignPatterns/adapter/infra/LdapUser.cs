using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.adapter.infra
{
    class LdapUser
    {
        public string uId;
        public string fName;
        public string lName;
        public string creationDate;
        public string workEmail;
        public List<LdapUserPhone> emailAddresses = new List<LdapUserPhone>();
    }
}
