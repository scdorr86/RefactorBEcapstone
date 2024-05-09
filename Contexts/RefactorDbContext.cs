using RefactorBEcapstone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RefactorBEcapstone.Contexts
{
    public class RefactorDbContext : IdentityDbContext<AppUser>
    {
        public RefactorDbContext(DbContextOptions<RefactorDbContext> options) : base(options) { }
        public DbSet<ChristmasList> ChristmasLists { get; set; }
        public DbSet<ChristmasYear> ChristmasYears { get; set; }
        public DbSet<Models.Gift> Gifts { get; set; }
        public DbSet<Models.Giftee> Giftees { get; set; }
    }
}
