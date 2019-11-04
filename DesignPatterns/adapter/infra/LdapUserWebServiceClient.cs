using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.adapter.infra
{
    class LdapUserWebServiceClient
    {
        public List<LdapUser> Search(String uId, String fName, String lName)
        {
            // Imagine a search URL is formed here and a GET is then performed
            // Then, the response JSON list is converted to LdapUser objects
            return new List<LdapUser>(){ DummyData.ldapUser1}/*, DummyData.ldapUser2*/;
        }
    }
}
