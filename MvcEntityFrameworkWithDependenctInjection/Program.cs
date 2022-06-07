using MvcEntityFrameworkWithDependenctInjection.Models;

var builder = WebApplication.CreateBuilder(args);


// Dependency Injectionlar
// Add services to the container.
builder.Services.AddControllersWithViews();

// controllerimizin bekledi�i instanci g�nderiyoruz..(DI)
builder.Services.AddDbContext<AppDbContext>(); // AppDbContext instancei olu�turulur ve ctorunda parametre bekleyenlere g�nderilir...


// Middleware 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
