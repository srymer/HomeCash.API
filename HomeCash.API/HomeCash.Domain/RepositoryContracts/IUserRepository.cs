using HomeCash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCash.Domain.RepositoryContracts
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsersByIdAsync(Guid id);

        public Task<User> GetUserByIdAsync(Guid id);
        public Task<User> GetUserByUserNameAsync(string userName);

        public Task CreateUserAsync(User user);

        public Task DeleteUserAsync(Guid id);

        public Task UpdateUserAsync(User user);
        
    }
}