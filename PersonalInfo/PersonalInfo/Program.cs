using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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



var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//
//     SeedData.Initialize(services);
// }


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
    pattern: "{controller=Persons}/{action=Index}/{id?}");

app.Run();
