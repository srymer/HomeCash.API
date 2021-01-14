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

        public Task CreateUser(User user);

        public Task DeleteUser(Guid id);

        public Task UpdateUser(User user);
        
    }
}