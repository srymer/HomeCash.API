using HomeCash.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HomeCash.Infrastructure.EFCore.DbContexts
{
    public class HomeCashDbContext : DbContext
    {
        public HomeCashDbContext(DbContextOptions<HomeCashDbContext> options) : base(options)
        {
        }

        public DbSet<HomeBase> HomeBases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HomeBase>().HasKey(i => i.HomeBaseId).HasName("Id_HomeBase");
            modelBuilder.Entity<HomeBase>().Property(x => x.HomeBaseId).HasColumnName("Id_HomeBase").IsRequired();
            modelBuilder.Entity<HomeBase>().Property(x => x.HomeName).HasColumnName("HomeName").IsRequired();

            modelBuilder.Entity<User>().HasKey(i => i.Id).HasName("Id_User");
            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("Id_User").IsRequired();
            modelBuilder.Entity<User>().Property(x => x.UserName).HasColumnName("Username").IsRequired();
            modelBuilder.Entity<User>().Property(x => x.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            modelBuilder.Entity<User>().Property(x => x.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Role).HasColumnName("Role").IsRequired();
            modelBuilder.Entity<User>().HasOne(x => x.HomeBase).WithMany(x => x.Users).HasForeignKey(x => x.HomeBaseId).HasConstraintName("Fid_HomeBase_FK1");

            modelBuilder.Entity<Cost>().HasKey(i => i.Id).HasName("Id_Cost");
            modelBuilder.Entity<Cost>().Property(x => x.Id).HasColumnName("Id_Cost").IsRequired();
            modelBuilder.Entity<Cost>().Property(x => x.Type).HasColumnName("Type").IsRequired();
            modelBuilder.Entity<Cost>().Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            modelBuilder.Entity<Cost>().Property(x => x.GeneratedByUserId).HasColumnName("Vid_GeneratedByUser").IsRequired();
            modelBuilder.Entity<Cost>().Property(x => x.CreatedByUserId).HasColumnName("Vid_CreatedByUser").IsRequired();
            modelBuilder.Entity<Cost>().Property(x => x.Amount).HasColumnName("Amount").IsRequired();
            modelBuilder.Entity<Cost>().Property(x => x.HomeBaseId).HasColumnName("Vid_HomeBase").IsRequired();
            modelBuilder.Entity<Cost>().Property(x => x.ShopId).HasColumnName("Vid_Shop").IsRequired();
            modelBuilder.Entity<Cost>().HasOne(x => x.HomeBase).WithMany(x => x.Costs).HasForeignKey(x => x.HomeBaseId).HasConstraintName("Fid_HomeBase_FK2");

            modelBuilder.Entity<Income>().HasKey(i => i.Id).HasName("Id_Income");
            modelBuilder.Entity<Income>().Property(x => x.Id).HasColumnName("Id_Income").IsRequired();
            modelBuilder.Entity<Income>().Property(x => x.Type).HasColumnName("Type").IsRequired();
            modelBuilder.Entity<Income>().Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            modelBuilder.Entity<Income>().Property(x => x.GeneratedByUserId).HasColumnName("Vid_GeneratedByUser").IsRequired();
            modelBuilder.Entity<Income>().Property(x => x.CreatedByUserId).HasColumnName("Vid_CreatedByUser").IsRequired();
            modelBuilder.Entity<Income>().Property(x => x.Amount).HasColumnName("Amount").IsRequired();
            modelBuilder.Entity<Income>().Property(x => x.HomeBaseId).HasColumnName("Vid_HomeBase").IsRequired();
            modelBuilder.Entity<Income>().HasOne(x => x.HomeBase).WithMany(x => x.Incomes).HasForeignKey(x => x.HomeBaseId).HasConstraintName("Fid_HomeBase_FK3");

            modelBuilder.Entity<Shop>().ToTable("Shops", "dictionary");
            modelBuilder.Entity<Shop>().HasKey(i => i.Id).HasName("Id_Shop");
            modelBuilder.Entity<Shop>().Property(x => x.Id).HasColumnName("Id_Shop").IsRequired();
            modelBuilder.Entity<Shop>().Property(x => x.Name).HasColumnName("Name").IsRequired();
        }
    }
}