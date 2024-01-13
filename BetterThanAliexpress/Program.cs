using BetterThanAliexpress.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>();
//
// var asdf = new DataBaseContext();
// asdf.Database.EnsureCreated();

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
                                                  pattern: "{controller=Authorization}/{action=Authorization}");

                     endpoints.MapControllerRoute(
                                                  name: "UserMainPage",
                                                  pattern: "{controller=UserMainPage}/{action=UserMainPage}");

                     endpoints.MapControllerRoute(name: "UserCart",
                                                  pattern: "{controller=UserCart}/{action=UserCart}");

                     endpoints.MapControllerRoute(name: "AdminMainPage",
                                                  pattern: "{controller=AdminMainPage}/{action=AdminMainPage}");
                 });

app.Run();
