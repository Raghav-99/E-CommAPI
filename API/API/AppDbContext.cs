using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using API.Models.Models;

namespace API
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<SellerModel> SellerModel { get; set; }
        public DbSet<ProductsModel> ProductsModel { get; set; }
        public DbSet<CommodityMapModel> CommodityMapModel { get; set; }
        public DbSet<OrderHistoryModel> OrderHistoryModel { get; set; }
    }
}
