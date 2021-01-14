using HomeCash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCash.Domain.RepositoryContracts
{
    public interface IIncomeRepository
    {
        public Task<IEnumerable<Income>> GetIncomes();

        public Task<Income> GetIncomeByID(Guid id);

        public Task CreateIncome(Income income);

        public Task DeleteIncome(Guid id);

        public Task UpdateIncome(Income income);
    }
}