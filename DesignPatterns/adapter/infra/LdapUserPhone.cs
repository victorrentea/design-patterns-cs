using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.adapter.infra
{
    class LdapUserPhone
    {
        public string type;
        public string val;
        public LdapUserPhone(string type, string val)
        {
            this.type = type;
            this.val = val;
        }
    }
}
