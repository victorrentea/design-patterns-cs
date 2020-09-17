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
            List<User> list = searchByUsername(username);
            if (list.Count() != 1)
            {
                throw new Exception("There is no single user matching username " + username);
            }
            User user = list[0];

            if (user.workEmail != null)
            {
                Console.WriteLine("Send welcome email to " + user.workEmail);
            }
            Console.WriteLine("Insert user in my database");
        }


        public List<User> SearchUserInLdap(string username)
        {
            return searchByUsername(username);
        }
        
        // ------------------------------------ THOSE WHO ENTER, ABANDON ALL HOPE

        private static User buildUser(LdapUser ldapUser)
        {
            string fullName = ldapUser.fName + " " + ldapUser.lName.ToUpper();
            return new User(ldapUser.uId, fullName, ldapUser.workEmail);
        }

        private List<User> searchByUsername(string username)
        {
            return wsClient.Search(username.ToUpper(), null, null).Select(ldapUser => buildUser(ldapUser)).ToList();
        }
    }
}
