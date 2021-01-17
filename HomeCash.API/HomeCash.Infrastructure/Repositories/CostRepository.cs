using HomeCash.Domain.Entities;
using HomeCash.Domain.RepositoryContracts;
using HomeCash.Infrastructure.EFCore.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCash.Infrastructure.Repositories
{
    public class CostRepository : ICostRepository
    {
        private readonly HomeCashDbContext _context;

        public CostRepository(HomeCashDbContext context)
        {
            _context = context;
        }

        public async Task CreateCost(Cost cost)
        {
            _context.Costs.Add(cost);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCost(Guid id)
        {
            var cost = await _context.Costs.FindAsync(id);
            _context.Costs.Remove(cost);
            await _context.SaveChangesAsync();
        }

        public async Task<Cost> GetCostByID(Guid id)
        {
            return await _context.Costs.FindAsync(id);
        }

        public async Task<IEnumerable<Cost>> GetCosts()
        {
            return await _context.Costs.ToListAsync();
        }

        public async Task UpdateUser(Cost cost)
        {
            _context.Update(cost);
            await _context.SaveChangesAsync();
        }
    }
}