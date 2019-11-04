using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.adapter.infra
{
    class DummyData
    {
        public static LdapUser ldapUser1 = new LdapUser {
            fName = "John",
            lName = "DOE",
            uId = "jdoe",
            creationDate = "2019-01-01",
            workEmail = "0123456789",
            emailAddresses = { new LdapUserPhone("WORK", "jdoe@bigcorp.com")}
        };
        public static LdapUser ldapUser2 = new LdapUser {
            fName = "Jane",
            lName = "DOE",
            uId = "janedoe",
            creationDate = "2019-01-02",
            workEmail = "0123456789"
        };
    }
}
