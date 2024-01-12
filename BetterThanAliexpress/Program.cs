using BetterThanAliexpress.EntityFramework;

using Microsoft.EntityFrameworkCore;

using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var asdf = new DataBaseContext();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>();



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

app.UseEndpoints(endpoints =>
                 {
                     endpoints.MapControllerRoute(
                                                  name: "default",
                                                  pattern: "{controller=Home}/{action=Index}/{id?}");

                     endpoints.MapControllerRoute(
                                                  name: "UserRegistration",
                                                  pattern: "{controller=UserRegistration}/{action=UserRegistration}");

                     endpoints.MapControllerRoute(
                                                  name: "UserAuthorization",
                                                  pattern: "{controller=UserAuthorization}/{action=UserAuthorization}");
                 });

app.Run();
