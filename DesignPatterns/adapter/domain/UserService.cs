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
        private readonly ExternalUserService ldapUserAdapter;
        public UserService(ExternalUserService wsClient)
        {
            this.ldapUserAdapter = wsClient;
        }

        public void ImportUserFromLdap(string username)
        {
            List<User> list = ldapUserAdapter.SearchByUsername(username);
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
            return ldapUserAdapter.SearchByUsername(username);
        }
        
    }
}
