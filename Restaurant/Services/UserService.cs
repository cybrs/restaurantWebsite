using Restaurant.Contracts;
using Restaurant.Models;
using Restaurant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class UserService : IUsersService
    {
        private IUserRepository _usersRepository;

        public UserService(IUserRepository singersRepository)
        {
            _usersRepository = singersRepository;
        }

        public List<User> GetAllUsers()
        {
            return _usersRepository.FindAll().ToList();
        }
    }
}
