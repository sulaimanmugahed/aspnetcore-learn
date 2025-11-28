using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddScoped(typeof(IRepository<>),typeof(EFCoreRepository<>));



builder.Services.AddScoped<IBookRepository, EFCoreBookRepository>();
builder.Services.AddScoped<IAuthorRepository, EFCoreAuthorRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCoreCategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, EFCoreCustomerRepository>();
builder.Services.AddScoped<IUserRepository, EFCoreUserRepository>();




builder.Services.AddOpenApi();
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    }); ;


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Basic17NovDatabase2;Trusted_Connection=True;"));




var app = builder.Build();



app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();

app.Run();
