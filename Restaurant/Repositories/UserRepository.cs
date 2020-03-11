using Restaurant.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        //public UserRepository(RepositoryContext repositoryContext)
        //   : base(repositoryContext)
        //{
        //}
    }
}
