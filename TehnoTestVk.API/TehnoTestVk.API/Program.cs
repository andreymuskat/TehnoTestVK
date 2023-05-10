using Microsoft.AspNetCore.Identity;
using TechnoTestVk.DAL;
using TechnoTestVk.DAL.Interfaces;
using TehnoTest.BLL;
using TehnoTest.BLL.Interfaces;
using TehnoTestVk.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<Context>();

builder.Services.AddAutoMapper(typeof(MapperApiProfile), typeof(MapperBllProfile));

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
