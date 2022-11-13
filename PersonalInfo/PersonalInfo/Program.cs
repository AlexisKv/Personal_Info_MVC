using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalInfo.Core;
using PersonalInfo.Core.Models;
using PersonalInfo.Data;
// using PersonalInfo.SeedData;
using PersonalInfo.Core.Services;
using PersonalInfo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddDbContext<DataBaseContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPersonalInfoDbContext, DataBaseContext>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IEntityService<Person>, EntityService<Person>>();
builder.Services.AddScoped<IEntityService<Addresses>, EntityService<Addresses>>();
builder.Services.AddScoped<IPersonsService, PersonsService>();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Persons}/{action=Index}/{id?}");

app.Run();
