using IdentotyExample.Clients;
using IdentotyExample.Data;
using IdentotyExample.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string defaultConnectionString = "server=127.0.0.1; port=3306; database=testbaza; user=root; password=root; Persist Security Info=False; Connect Timeout=300";
builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(defaultConnectionString, ServerVersion.AutoDetect(defaultConnectionString),
        mySqlOptionsAction => mySqlOptionsAction.EnableRetryOnFailure(3))
        .LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["JWT:JwtPrivateKey"])
                        ),
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();


//builder.Services.AddSingleton<AlohaApiClient>();

//builder.Services.AddHttpClient("AlohaApiClient", client =>
//{
//    client.BaseAddress = new Uri("https://api.alohaorderonline.com/");
//    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//    client.DefaultRequestHeaders.Add("PlatformType", "application/json");
//    string username = "api-demo@ds.com";
//    string password = "DigitalNCRDigital123@";
//    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
//    client.DefaultRequestHeaders.Add("X-Api-CompanyCode", "DLEC001");
//    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
//});

builder.Services.AddHttpClient("AlohaApiClient", client =>
{
    client.BaseAddress = new Uri("https://api.alohaorderonline.com");
    client.Timeout = TimeSpan.FromSeconds(120);
    client.DefaultRequestHeaders.Add("X-Api-CompanyCode", "DLEC001");
    client.DefaultRequestHeaders.Add("PlatformType", "application/json");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    string username = "api-demo@ds.com";
    string password = "DigitalNCRDigital123@";
    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
});

builder.Services.AddSingleton<AlohaApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
