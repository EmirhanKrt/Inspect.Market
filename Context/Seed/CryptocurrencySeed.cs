using Inspect.Market.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Inspect.Market.Context.Seed
{
    public class CryptocurrencySeed : IEntityTypeConfiguration<Cryptocurrency>
    {
        public void Configure(EntityTypeBuilder<Cryptocurrency> builder)
        {
            builder.HasData(
                new Cryptocurrency()
                {
                    Id = 1,
                    Name = "Bitcoin",
                    Symbol = "BTC",
                    Slug = "bitcoin",
                    CirculationSupply = 19716053,
                    TotalSupply = 19716053,
                    MaxSupply = 21000000,
                    DecimalCount = 2,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Cryptocurrency()
                {
                    Id = 2,
                    Name = "Ethereum",
                    Symbol = "ETH",
                    Slug = "ethereum",
                    CirculationSupply = 122275693,
                    TotalSupply = 122275693,
                    MaxSupply = -1,
                    DecimalCount = 2,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Cryptocurrency()
                {
                    Id = 3,
                    Name = "Tether",
                    Symbol = "USDT",
                    Slug = "tether",
                    CirculationSupply = 112941691563,
                    TotalSupply = 116079124154,
                    MaxSupply = -1,
                    DecimalCount = 4,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Cryptocurrency()
                {
                    Id = 4,
                    Name = "Bnb",
                    Symbol = "BNB",
                    Slug = "bnb",
                    CirculationSupply = 147583562,
                    TotalSupply = 147583562,
                    DecimalCount = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Cryptocurrency()
                {
                    Id = 5,
                    Name = "Solana",
                    Symbol = "SOL",
                    Slug = "solana",
                    CirculationSupply = 462137999,
                    TotalSupply = 578771776,
                    MaxSupply = -1,
                    DecimalCount = 2,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Cryptocurrency()
                {
                    Id = 6,
                    Name = "USDC",
                    Symbol = "USDC",
                    Slug = "usd-coin",
                    CirculationSupply = 32706614766,
                    TotalSupply = 32706614766,
                    MaxSupply = -1,
                    DecimalCount = 4,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Cryptocurrency()
                {
                    Id = 7,
                    Name = "XRP",
                    Symbol = "XRP",
                    Slug = "xrp",
                    CirculationSupply = 55618185850,
                    TotalSupply = 99987512072,
                    MaxSupply = 100000000000,
                    DecimalCount = 4,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Cryptocurrency()
                {
                    Id = 8,
                    Name = "Dogecoin",
                    Symbol = "DOGE",
                    Slug = "dogecoin",
                    CirculationSupply = 144842056384,
                    TotalSupply = 144842056384,
                    MaxSupply = -1,
                    DecimalCount = 5,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Cryptocurrency()
                {
                    Id = 9,
                    Name = "Cardano",
                    Symbol = "ADA",
                    Slug = "cardano",
                    CirculationSupply = 35743190042,
                    TotalSupply = 36994116265,
                    MaxSupply = 45000000000,
                    DecimalCount = 4,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Cryptocurrency()
                {
                    Id = 10,
                    Name = "Fantom",
                    Symbol = "FTM",
                    Slug = "fantom",
                    CirculationSupply = 2803634836,
                    TotalSupply = 3175000000,
                    DecimalCount = 4,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
