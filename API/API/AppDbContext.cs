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
        public DbSet<API.LoginModel> LoginModel { get; set; }
        public DbSet<API.UserModel> UserModel { get; set; }
        public DbSet<API.RegisterModel> RegisterModel { get; set; }
        public DbSet<API.SellerModel> SellerModel { get; set; }
        public DbSet<API.ProductsModel> ProductsModel { get; set; }
        public DbSet<API.CommodityMapModel> CommodityMapModel { get; set; }
        public DbSet<OrderHistoryModel> OrderHistoryModel { get; set; }
    }
}
