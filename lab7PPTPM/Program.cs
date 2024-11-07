using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using lab7PPTPM.Data;
using lab7PPTPM.Model;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<lab7PPTPMContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("lab7PPTPMContext") ?? throw new InvalidOperationException("Connection string 'lab7PPTPMContext' not found.")));

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

// Инициализация данных должна быть выполнена после создания приложения
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    SeedData.Initialize(serviceProvider);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
