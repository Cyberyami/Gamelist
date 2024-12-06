using BLL.DAL;
using BLL.Models;
using BLL.Services;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// IOC - Add database context and services before Build
var connectionString = "server=(localdb)\\mssqllocaldb;database=GameAPP;trusted_connection=true;";
builder.Services.AddDbContext<DB>(options => options.UseSqlServer(connectionString));

// Register the GameService
builder.Services.AddScoped<IService<Game, GamesModel>, GamesServices>();
builder.Services.AddScoped<IService<GameGenre, GenreModel>, GameGenreServices>();

var app = builder.Build(); // Now that services are registered, build the app

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
