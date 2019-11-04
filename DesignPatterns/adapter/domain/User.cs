using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.adapter.domain
{
    class User
    {
        public String username;
        public String fullName;
        public String workEmail;

        public User(string username, string fullName, string workEmail)
        {
            this.username = username;
            this.fullName = fullName;
            this.workEmail = workEmail;
        }
    }
}
