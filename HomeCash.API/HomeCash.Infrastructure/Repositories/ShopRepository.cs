using HomeCash.Domain.Entities;
using HomeCash.Domain.RepositoryContracts;
using HomeCash.Infrastructure.EFCore.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCash.Infrastructure.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly HomeCashDbContext _context;

        public ShopRepository(HomeCashDbContext context)
        {
            _context = context;
        }

        public async Task CreateShopAsync(Shop shop)
        {
            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShopAsync(Guid id)
        {
            var shop = await _context.Shops.FindAsync(id);
            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();
        }

        public async Task<Shop> GetShopByIDAsync(Guid id)
        {
            return await _context.Shops.FindAsync(id);
        }

        public async Task<IEnumerable<Shop>> GetShopsAsync()
        {
            return await _context.Shops.ToListAsync();
        }

        public async Task UpdateShopAsync(Shop shop)
        {
            _context.Entry(shop).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}