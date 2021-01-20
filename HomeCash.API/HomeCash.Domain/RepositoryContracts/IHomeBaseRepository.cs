using HomeCash.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace HomeCash.Domain.RepositoryContracts
{
    public interface IHomeBaseRepository
    {
        public Task<HomeBase> GetHomeBaseByIdAsync(Guid homeId);

        public Task CreateHomeBaseAsync(HomeBase homeBase);

        public Task DeleteHomeBaseAsync(Guid homeId);

        public Task UpdateHomeBaseAsync(HomeBase homeBase);
    }
}