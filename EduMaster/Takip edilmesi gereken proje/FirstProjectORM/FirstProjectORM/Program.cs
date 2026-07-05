using FirstProjectORM.Data.Repository;
using FirstProjectORM.Data.Repository.IRepository;
using FirstProjectORM.Data.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

/// 1.Serilog Yapýlandýrmasýný appsettings'den oku
Log.Logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
.CreateLogger();

// 2. .NET Core'un kendi log mekanizmasýný Serilog ile deðiþtir
builder.Host.UseSerilog();/// 1.Serilog Yapýlandýrmasýný appsettings'den oku
Log.Logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
.CreateLogger();

// 2. .NET Core'un kendi log mekanizmasýný Serilog ile deðiþtir
builder.Host.UseSerilog();


//dý yaþan döngüsünü ekliyoruz
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.
UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
