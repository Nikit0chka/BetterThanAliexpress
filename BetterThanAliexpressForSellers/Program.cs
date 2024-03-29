using DataBase;

using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/Authorization");
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// var asdf = new DataBaseContext();
// asdf.Database.EnsureCreated();
// asdf.Admins.Add(new Admin { Password = "Admin", Login = "Admin" });
//
// asdf.Sellers.Add(new Seller()
//                  {
//                  CompanyAddress = "Seller",
//                  Email = "Seller",
//                  Inn = "Seller",
//                  Login = "Seller",
//                  Name = "Seller",
//                  Password = "Seller",
//                  PhoneNumber = "Seller",
//                  IsAdminConfirmed = false,
//                  Products = new List<Product>()
//                  });
//
// asdf.Buyers.Add(new Buyer()
//                 {
//                 DateOfBirthday = DateTime.Now,
//                 Email = "Buyer",
//                 Login = "Buyer",
//                 Name = "Buyer",
//                 Password = "Buyer",
//                 Surname = "Buyer",
//                 PhoneNumber = "Buyer",
//                 ProductBasket = new List<Product>()
//                 });
//
// asdf.ProductCategories.Add(new ProductCategory { Name = "alo", Products = new List<Product>() });
//
// asdf.SaveChanges();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();

app.MapControllerRoute(
                       name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(name: "MainPage",
                       pattern: "{controller=MainPage}/{action=MainPage}");

app.MapControllerRoute(name: "Authorization",
                       pattern: "{controller=Authorization}/{action=Authorization}");

app.MapControllerRoute(name: "Registration",
                       pattern: "{controller=Registration}/{action=Registration}");

app.MapControllerRoute(name: "ProductMange",
                       pattern: "{controller=ProductManage}/{action=ManageProduct}");

app.Run();
