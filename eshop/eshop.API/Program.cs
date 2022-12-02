using eshop.Application;
using eshop.DataAccess.Data;
using eshop.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BU-CUMLE-COK-GIZLI-VE-ONEMLI")),
                        ValidAudience = "https://client.halkbank.com.tr",
                        ValidIssuer = "https://identity.halkbank.com.tr",
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };
                });


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<IUserService, UserService>();
var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<ShopDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddCors(option =>
{
    option.AddPolicy("allow", builder =>
    {
        /*
         * http://www.halkbank.com.tr
         * https://www.halkbank.com.tr
         * https://accounts.halkbank.com.tr
         * https://www.halkbank.com.tr:8181
         */
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
    });
});

var app = builder.Build();
//app.UseWelcomePage();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseCors("allow");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
