/*
*@author Ramadan ismaeL
*/

using System.Text;
using controleDeContactos.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
string erro = "9c6d5d2983b7fab36afea72639222fe6958cb8c2289d2739f630d859e5644963712c6b1279020bca3c62088fb18902354ca96231e182a0c21cc9a0f37c7ca3fe";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(ram =>
{
    ram.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sistema De Controle De Contactos",
        Version = "v1",
        Description = "API para gerenciamento de contactos com autenticação JWT.",
        Contact = new OpenApiContact
        {
            Name = "System Administrator",
            Email = "ramadan.ismael02@gmail.com"
            //Url = new Uri("https://www.controldecontactos.com")
        }
    });
    var security = new OpenApiSecurityScheme
    {
        Name = "Autenticação JWT",
        Description = "Entre com o JWT Bearer token no formato: 'Bearer {token}'",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    ram.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, security);
    ram.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { security, new[] {"Bearer"} }
    });
});
builder.Services.AddControllers();

var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var server = Environment.GetEnvironmentVariable("DB_SERVER");
Console.WriteLine($"User: {user}, Password: {password}, Port: {port}");
string? connect = $"server={server};port={port};database=db_ControleDeContactos;user={user};password={password};Persist Security Info=False;Connect Timeout=300";

builder.Services.AddDbContextPool<ControleDeContactos>(options => options.UseMySql(connect, ServerVersion.AutoDetect(connect)));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "System_Developer_Solution",
        ValidAudience = "Controle_De_Contactos",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(erro))
    };
});

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
//app.MapControllersRoute();
app.Run();