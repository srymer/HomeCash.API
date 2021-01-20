using HomeCash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCash.Domain.RepositoryContracts
{
    public interface IShopRepository
    {
        public Task<IEnumerable<Shop>> GetShopsAsync();

        public Task<Shop> GetShopByIDAsync(Guid id);

        public Task CreateShopAsync(Shop shop);

        public Task DeleteShopAsync(Guid id);

        public Task UpdateShopAsync(Shop shop);
    }
}