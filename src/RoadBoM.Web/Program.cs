using Microsoft.EntityFrameworkCore;
using RoadBoM.Web.Context;
using RoadBoM.Web.DataAccess;
using RoadBoM.Web.Models.Entities;
using RoadBoM.Web.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<RoadBoMContext>(options => options.UseSqlServer(connectionstring));
builder.Services.AddScoped<IRoadRepository, RoadRepository>();
builder.Services.AddScoped<IMeasurementBillRepository, MeasurementBillRepository>();
builder.Services.AddScoped<IBillCategoryRepository, BillCategoryRepository>();
builder.Services.AddScoped<IBillItemRepository, BillItemRepository>();
builder.Services.AddScoped<IBillItemRateRepository, BillItemRateRepository>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
