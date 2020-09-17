using DesignPatterns.adapter.infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.adapter.domain
{
    // Holy sacred Domain Service holding my essential precious domain logic
    class UserService
    {
        private readonly LdapUserWebServiceClient wsClient;
        public UserService(LdapUserWebServiceClient wsClient)
        {
            this.wsClient = wsClient;
        }

        public void ImportUserFromLdap(string username)
        {
            List<LdapUser> list = searchByUsername(username);
            if (list.Count() != 1)
            {
                throw new Exception("There is no single user matching username " + username);
            }
            User user = buildUser(list[0]);

            if (user.workEmail != null)
            {
                Console.WriteLine("Send welcome email to " + user.workEmail);
            }
            Console.WriteLine("Insert user in my database");
        }


        public List<User> SearchUserInLdap(string username)
        {
            List<LdapUser> list = searchByUsername(username);
            List<User> results = new List<User>();
            foreach (LdapUser ldapUser in list)
            {
                results.Add(buildUser(ldapUser));
            }
            return results;
        }

        private static User buildUser(LdapUser ldapUser)
        {
            string fullName = ldapUser.fName + " " + ldapUser.lName.ToUpper();
            return new User(ldapUser.uId, fullName, ldapUser.workEmail);
        }

        private List<LdapUser> searchByUsername(string username)
        {
            return wsClient.Search(username.ToUpper(), null, null);
        }
    }
}
