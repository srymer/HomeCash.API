using HomeCash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCash.Domain.RepositoryContracts
{
    public interface ICostRepository
    {
        public Task<IEnumerable<Cost>> GetCosts();

        public Task<Cost> GetCostByID(Guid id);

        public Task CreateCost(Cost cost);

        public Task DeleteCost(Guid id);

        public Task UpdateUser(Cost cost);
    }
}