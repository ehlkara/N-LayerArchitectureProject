using Microsoft.EntityFrameworkCore;
using NLayerArchitecture.Core.Repositories;
using NLayerArchitecture.Core.UnitOfWorks;
using NLayerArchitecture.Repository;
using NLayerArchitecture.Repository.Repositories;
using NLayerArchitecture.Repository.UnitOfWorks;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Configuration
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
     {
         options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
     });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
