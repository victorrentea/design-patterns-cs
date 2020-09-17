using DesignPatterns.adapter.infra;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.adapter.domain
{
    // ------------------------------------ THOSE WHO ENTER, ABANDON ALL HOPE
    class LdapUserServiceAdapter : ExternalUserService
    {
        private readonly LdapUserWebServiceClient wsClient;
        public LdapUserServiceAdapter(LdapUserWebServiceClient wsClient)

        {
            this.wsClient = wsClient;
        }
        public List<User> SearchByUsername(string username)
        {
            return wsClient.Search(username.ToUpper(), null, null).Select(ldapUser => buildUser(ldapUser)).ToList();
        }
        private static User buildUser(LdapUser ldapUser)
        {
            string fullName = ldapUser.fName + " " + ldapUser.lName.ToUpper();
            return new User(ldapUser.uId, fullName, ldapUser.workEmail);
        }

    }
}
