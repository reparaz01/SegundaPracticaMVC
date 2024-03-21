using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PruebaExamen.Repositories;
using SegundaPracticaMVC.Data;
using SegundaPracticaMVC.Helpers;
using SegundaPracticaMVC.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Habilitamos session dentro de nuestro servidor
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Habilitamos la seguridad en servicios
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    CookieAuthenticationDefaults.AuthenticationScheme;

    options.DefaultSignInScheme =
    CookieAuthenticationDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
    CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();

// Add services to the container.
string connectionString =
    builder.Configuration.GetConnectionString("SqlHospital");

builder.Services.AddTransient<RepositoryUsuarios>();
builder.Services.AddTransient<RepositoryLibros>();

builder.Services.AddTransient<HelperPathProvider>();

builder.Services.AddDbContext<LibrosContext>
    (options => options.UseSqlServer(connectionString));

//Personalizamos nuestras rutas
builder.Services.AddControllersWithViews
    (options => options.EnableEndpointRouting = false)
    .AddSessionStateTempDataProvider();

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

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Libros}/{action=Index}/{id?}");
});

app.Run();