using Inspect.Market.Context.Seed;
using Inspect.Market.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inspect.Market.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.TransactionType)
                .HasConversion<string>();

            modelBuilder.Entity<Holding>()
                .HasOne(h => h.Portfolio)
                .WithMany(p => p.Holdings)
                .HasForeignKey(h => h.PortfolioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Holding>()
                .HasOne(h => h.User)
                .WithMany()
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Holding>()
                .HasOne(h => h.Cryptocurrency)
                .WithMany()
                .HasForeignKey(h => h.CryptocurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Holding)
                .WithMany()
                .HasForeignKey(t => t.HoldingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Cryptocurrency)
                .WithMany()
                .HasForeignKey(t => t.CryptocurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Watchlist>()
                .HasOne(w => w.User)
                .WithMany()
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Watchlist>()
                .HasOne(w => w.Cryptocurrency)
                .WithMany()
                .HasForeignKey(w => w.CryptocurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Holding>()
                .HasMany(h => h.Transactions)
                .WithOne(t => t.Holding)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfiguration(new ApplicationRoleSeed());
            modelBuilder.ApplyConfiguration(new ApplicationUserSeed());
            modelBuilder.ApplyConfiguration(new ApplicationUserRoleSeed());

            modelBuilder.ApplyConfiguration(new CryptocurrencySeed());
        }
    }
}
