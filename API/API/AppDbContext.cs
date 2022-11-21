using Microsoft.EntityFrameworkCore;
using API;

namespace API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<API.AdminModel> AdminModel { get; set; }
    }
}
