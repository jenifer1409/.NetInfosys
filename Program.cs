using Microsoft.EntityFrameworkCore;
using VehicleAPI.CoreServices.CoreData;
using VehicleAPI.CoreServices.ServiceInterface;
using VehicleAPI.Infrastructure.DataRepository;
using VehicleAPI.Infrastructure.RepositoryInterface;
using VehicleWebApplication.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VehicleContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("VehicleConnection")));




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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=VehicleStatusTrackers}/{action=Index}/{id?}");

app.Run();
