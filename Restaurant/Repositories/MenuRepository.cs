using Restaurant.Contracts;

using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        //public MenuRepository(ApplicationDbContext repositoryContext)
        //   : base(repositoryContext)
        //{
        //}
    }
}
