﻿using Microsoft.EntityFrameworkCore;
using API;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
        
    }
}
