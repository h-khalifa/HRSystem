using DataBase;
using DataBase.Entities;
using DataBase.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services.AddControllersWithViews();

//di for database
builder.Services.AddScoped<IUOW, UOW>();
builder.Services.AddScoped<IBaseRepository<Employe>, BaseRepository<Employe>>();
builder.Services.AddScoped<IBaseRepository<Attendance>, BaseRepository<Attendance>>();
//builder.Services.AddScoped<DbContext, HREntities>();
builder.Services.AddDbContext<HREntities>();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

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
    pattern: "{controller=Employes}/{action=All}/{id?}");

app.Run();
