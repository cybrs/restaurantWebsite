using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services.Interfaces
{
    public class IUsersService
    {
        List<User> AllUsers { get; }
    }
}
