using HomeCash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCash.Domain.RepositoryContracts
{
    public interface IIncomeRepository
    {
        public Task<IEnumerable<Income>> GetIncomesAsync();

        public Task<Income> GetIncomeByIDAsync(Guid id);

        public Task CreateIncomeAsync(Income income);

        public Task DeleteIncomeAsync(Guid id);

        public Task UpdateIncomeAsync(Income income);
    }
}