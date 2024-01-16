using BetterThanAliexpress.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>();

// var asdf = new DataBaseContext();
// asdf.Admins.Add(new Admin { Password = "Admin", Login = "Admin" });
// asdf.Database.EnsureCreated();
// asdf.SaveChanges();

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

app.MapControllerRoute(name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(name: "UserRegistration",
                       pattern: "{controller=UserRegistration}/{action=UserRegistration}");

app.MapControllerRoute(name: "UserAuthorization",
                       pattern: "{controller=Authorization}/{action=Authorization}");

app.MapControllerRoute(name: "UserMainPage",
                       pattern: "{controller=UserMainPage}/{action=UserMainPage}");

app.MapControllerRoute(name: "UserCart",
                       pattern: "{controller=UserCart}/{action=UserCart}");

app.MapControllerRoute(name: "AdminMainPage",
                       pattern: "{controller=AdminMainPage}/{action=AdminMainPage}")
;

app.MapControllerRoute(name: "SellerMainPage",
                       pattern: "{controller=SellerMainPage}/{action=SellerMainPage}");

app.Run();
