using Api.Settings;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
IConfiguration configuration = builder.Configuration;



builder.Services.AddScoped<IBookRepository, EFCoreBookRepository>();
builder.Services.AddScoped<IAuthorRepository, EFCoreAuthorRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCoreCategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, EFCoreCustomerRepository>();
builder.Services.AddScoped<IUserRepository, EFCoreUserRepository>();



builder.Services.AddOpenApi();
builder.Services.AddControllers();


builder.Services
.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("Default")));















builder.Services.Configure<BuyBookSettings>(configuration.GetSection(nameof(BuyBookSettings)));
builder.Services.Configure<PasswordSettings>(c =>
{
  c.Long=9;  
});





var app = builder.Build();



app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();

app.Run();
