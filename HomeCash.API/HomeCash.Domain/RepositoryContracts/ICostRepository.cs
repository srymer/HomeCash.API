using HomeCash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCash.Domain.RepositoryContracts
{
    public interface ICostRepository
    {
        public Task<IEnumerable<Cost>> GetCostsAsync();

        public Task<Cost> GetCostByIDAsync(Guid id);

        public Task CreateCostAsync(Cost cost);

        public Task DeleteCostAsync(Guid id);

        public Task UpdateUserAsync(Cost cost);
    }
}