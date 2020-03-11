using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Contracts
{
    public interface IRepositoryWrapper
    {
        IAdminRepository Admin { get; }
        IMenuRepository Menu { get; }
        IReviewRepository Review { get; }
        IUserRepository User { get; }
    }
}
