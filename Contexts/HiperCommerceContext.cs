using Hiper.Commerce.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hiper.Commerce.Api.Data
{
    public class HiperCommerceContext : DbContext
    {
        public DbSet<AccessControlHistory> AccessControlHistories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HiperCommerceAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}