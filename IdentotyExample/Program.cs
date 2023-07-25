using IdentotyExample.Data;
using IdentotyExample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string defaultConnectionString = "server=127.0.0.1; port=3306; database=testbaza; user=root; password=root; Persist Security Info=False; Connect Timeout=300";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(defaultConnectionString, ServerVersion.AutoDetect(defaultConnectionString),
        mySqlOptionsAction => mySqlOptionsAction.EnableRetryOnFailure(3))
        .LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();


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
