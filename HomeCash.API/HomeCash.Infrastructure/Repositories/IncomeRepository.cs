using HomeCash.Domain.Entities;
using HomeCash.Domain.RepositoryContracts;
using HomeCash.Infrastructure.EFCore.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCash.Infrastructure.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly HomeCashDbContext _context;

        public IncomeRepository(HomeCashDbContext context)
        {
            _context = context;
        }

        public async Task CreateIncome(Income income)
        {
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteIncome(Guid id)
        {
            var income = await _context.Incomes.FindAsync(id);
            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();
        }

        public async Task<Income> GetIncomeByID(Guid id)
        {
            return await _context.Incomes.FindAsync(id);
        }

        public async Task<IEnumerable<Income>> GetIncomes()
        {
            return await _context.Incomes.ToListAsync();
        }

        public async Task UpdateIncome(Income income)
        {
            _context.Entry(income).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
