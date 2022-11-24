using API;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(optionsAction: 
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("rem_raghav")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

/*builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    *//*options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);*//*

    options.ReturnUrlParameter = null;
    *//*options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;*//*
});*/

builder.Services.AddCors(setupAction: options => options.AddPolicy("AllowAnyOrigin", 
    policy => policy.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
