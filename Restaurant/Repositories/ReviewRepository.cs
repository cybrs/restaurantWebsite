using Restaurant.Contracts;

using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        //public ReviewRepository(RepositoryContext repositoryContext)
        //   : base(repositoryContext)
        //{
        //}
    }
}
