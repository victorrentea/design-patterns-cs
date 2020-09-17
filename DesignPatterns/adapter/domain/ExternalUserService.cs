using System.Collections.Generic;

namespace DesignPatterns.adapter.domain
{
    interface ExternalUserService
    {

        List<User> SearchByUsername(string username);
    }
}