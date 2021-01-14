using HomeCash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCash.Domain.RepositoryContracts
{
    public interface IShopRepository
    {
        public Task<IEnumerable<Shop>> GetShops();

        public Task<Shop> GetShopByID(Guid id);

        public Task CreateShop(Shop shop);

        public Task DeleteShop(Guid id);

        public Task UpdateShop(Shop shop);
    }
}