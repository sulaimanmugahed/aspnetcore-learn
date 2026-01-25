using Api.Settings;
using Data;
using Data.Repostories;
using Domain;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
IConfiguration configuration = builder.Configuration;



builder.Services.AddScoped<IBookRepository, EFCoreBookRepository>();
builder.Services.AddScoped<IAuthorRepository, EFCoreAuthorRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCoreCategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, EFCoreCustomerRepository>();
builder.Services.AddScoped<IBorrowingRepository, EFCoreBorrowingRepository>();



builder.Services.AddOpenApi();
builder.Services.AddControllers();


builder.Services
.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("Default")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
  options.Password.RequireDigit = false;
  options.Password.RequireUppercase = false;
  options.Password.RequireNonAlphanumeric = false;
  options.Password.RequiredLength = 5;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<BuyBookSettings>(configuration.GetSection(nameof(BuyBookSettings)));
builder.Services.Configure<PasswordSettings>(c =>
{
  c.Long = 9;
});





var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();



app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();

app.Run();
