using HomeCash.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace HomeCash.Domain.RepositoryContracts
{
    public interface IHomeBaseRepository
    {
        public Task<HomeBase> GetHomeBaseById(Guid homeId);

        public Task CreateHomeBase(HomeBase homeBase);

        public Task DeleteHomeBase(Guid homeId);

        public Task UpdateHomeBase(HomeBase homeBase);
    }
}