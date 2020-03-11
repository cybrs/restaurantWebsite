using Restaurant.Contracts;

using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        //public AdminRepository(ApplicationDbContext repositoryContext)
        //   : base(repositoryContext)
        //{
        //}
    }
}
