using Microsoft.EntityFrameworkCore;
using ShoppingMall.EFCore.Models;

namespace ShoppingMall.EFCore.Data
{
    public class ShoppingMallAPIContext : DbContext
    {
        public ShoppingMallAPIContext(DbContextOptions<ShoppingMallAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Mall> Mall { get; set; } = default!;
        public DbSet<UserRegistration> UserRegistration { get; set; }
        public DbSet<UserRole> UserRoles { get; set; } = default!;
    }
}
