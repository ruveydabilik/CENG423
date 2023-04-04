using Microsoft.EntityFrameworkCore;
using PartyInviter.Models;

var builder = WebApplication.CreateBuilder(args);

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

GuestResponse guest1 = new GuestResponse()
{
    Name = "Ahmet Hamdi",
    Email = "ahamdi@gmail.com",
    Phone = "05557863420",
    WillAttend = true,
};

Repository.AddResponse(guest1);

GuestResponse guest2 = new GuestResponse()
{
    Name = "Sinem",
    Email = "sinem@gmail.com",
    Phone = "05079856324",
    WillAttend = true,
};

Repository.AddResponse(guest2);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


