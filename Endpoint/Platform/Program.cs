using Microsoft.EntityFrameworkCore;
using Platform;
using Platform.Models;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CalculationContext>(
    option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
        option.EnableSensitiveDataLogging(true);
    }
    );
builder.Services.AddResponseCaching();

builder.Services.AddTransient<SeedData>();

var app = builder.Build();
app.UseResponseCaching();


//app.MapGet("/sum/{count:int=1000000000}", SumEndpoint); 
app.MapEndpoint<Platform.SumEndpoint>("/sum/{count:int=1000000000}");
app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello World!");
});

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

bool cmdLineInit = (app.Configuration["INITDB"] ?? "false") == "true";

if (app.Environment.IsDevelopment() || cmdLineInit)
{
    var scope = app.Services.CreateScope();
    var seedData = scope.ServiceProvider.GetRequiredService<SeedData>();
    seedData.SeedDatabase();
}

if (!cmdLineInit)
{
    app.Run();
}
