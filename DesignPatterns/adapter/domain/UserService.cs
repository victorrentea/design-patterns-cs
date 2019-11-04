using DesignPatterns.adapter.infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.adapter.domain
{
    class UserService
    {
        private readonly LdapUserWebServiceClient wsClient;

        public void ImportUserFromLdap(string username)
        {
            List<LdapUser> list = wsClient.Search(username.ToUpper(), null, null);
            if (list.Count() != 1)
            {
                throw new Exception("There is no single user matching username " + username);
            }
            LdapUser ldapUser = list[0];
            string fullName = ldapUser.fName + " " + ldapUser.lName.ToUpper();
            User user = new User(ldapUser.uId, fullName, ldapUser.workEmail);

            if (user.workEmail != null)
            {
                Console.WriteLine("Send welcome email to " + user.workEmail);
            }
            Console.WriteLine("Insert user in my database");
        }

        public List<User> SearchUserInLdap(string username)
        {
            List<LdapUser> list = wsClient.Search(username.ToUpper(), null, null);
            List<User> results = new List<User>();
            foreach (LdapUser ldapUser in list)
            {
                string fullName = ldapUser.fName + " " + ldapUser.lName.ToUpper();
                User user = new User(ldapUser.uId, fullName, ldapUser.workEmail);
                results.Add(user);
            }
            return results;
        }

    }
}
