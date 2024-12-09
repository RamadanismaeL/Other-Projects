using ControleDeContatos.Data;
using ControleDeContatos.Helper;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//CONFIGURANDO BANCO DE DADOS, LEMBRANDO
// 1- Instalar o Mysql.Data>EntityFrameworkCore
// 2- Abrir nova pasta e criar um file para banco de dados
// 3- Configurar a conexao no appsettings.json
// 4- Configurar aqui
// Companhe abaixo
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<BancoContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

// 5 - Após criar digite no terminal do vsCode := ~ dotnet ef migrations add NomeDaMigracao
// 6 - No terminal := ~ dotnet ef database update

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Usado na sessão de Helper Para Mostrar nome ao Logar

builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ISessao, Sessao>(); //Parte do Helper
builder.Services.AddScoped<IEmail, Email>();

//builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Define o tempo de expiração da sessão, Se não definir o tempo de expiração da sessão o sistema usará o valor padrão do ASP.NET Core, que é geralmente 20 minutos. Após 20 minutos de inatividade, a sessão expirará automaticamente
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

/*builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new ResponseCacheAttribute
    {
        NoStore = true,
        Location = ResponseCacheLocation.None
    });
});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
