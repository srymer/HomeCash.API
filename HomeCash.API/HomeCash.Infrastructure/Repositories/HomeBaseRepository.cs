using HomeCash.Domain.Entities;
using HomeCash.Domain.RepositoryContracts;
using HomeCash.Infrastructure.EFCore.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HomeCash.Infrastructure.Repositories
{
    public class HomeBaseRepository : IHomeBaseRepository
    {
        private readonly HomeCashDbContext _context;

        public HomeBaseRepository(HomeCashDbContext context)
        {
            _context = context;
        }

        public async Task CreateHomeBaseAsync(HomeBase homeBase)
        {
            _context.HomeBases.Add(homeBase);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHomeBaseAsync(Guid homeId)
        {
            var homeBase = await _context.HomeBases.FindAsync(homeId);
            _context.HomeBases.Remove(homeBase);
            await _context.SaveChangesAsync();
        }

        public async Task<HomeBase> GetHomeBaseByIdAsync(Guid homeId)
        {
            return await _context.HomeBases.FindAsync(homeId);
        }

        public async Task UpdateHomeBaseAsync(HomeBase homeBase)
        {
            _context.Entry(homeBase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}