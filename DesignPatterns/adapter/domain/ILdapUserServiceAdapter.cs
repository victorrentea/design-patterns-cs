using System.Collections.Generic;

namespace DesignPatterns.adapter.domain
{
    interface ILdapUserServiceAdapter
    {
        List<User> searchByUsername(string username);
    }
}