using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebSalesControl.Data;
using WebSalesControl.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebSalesControlContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebSalesControlContext") ?? throw new InvalidOperationException("Connection string 'WebSalesControlContext' not found."), 
    builder => builder.MigrationsAssembly("WebSalesControl")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependencies services
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();

// Https configs
builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
    options.HttpsPort = 5001;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{ // Dependencies Execute
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<WebSalesControlContext>();
        var seedingService = new SeedingService(context);
        seedingService.Seed();
    }
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
