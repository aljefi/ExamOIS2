using App.DAL.EF;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//      options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.")));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

// ================================= Ehitati valmis veebirakendus
var app = builder.Build();
// =================================

// await SetupAppData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


static async Task SetupAppData(WebApplication app)
{
    using var serviceScope = app.Services.CreateScope();
    var services = serviceScope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();

    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

    // Ensure the Admin role exists
    var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
    if (!adminRoleExists)
    {
        var adminRoleResult = await roleManager.CreateAsync(new AppRole {Name = "Admin"});
        if (!adminRoleResult.Succeeded)
            Console.WriteLine("Failed to create Admin role.");
    }

    // Create an admin user
    var adminUser = new AppUser
        {UserName = "admin@eesti.ee", Email = "admin@eesti.ee", FirstName = "Admin", LastName = "Eesti"};
    var adminUserExists = await userManager.FindByEmailAsync(adminUser.Email);
    if (adminUserExists == null)
    {
        var createUserResult = await userManager.CreateAsync(adminUser, "Asd_123456");
        if (createUserResult.Succeeded)
        {
            var addToRoleResult = await userManager.AddToRoleAsync(adminUser, "Admin");
            if (!addToRoleResult.Succeeded)
                Console.WriteLine("Failed to add user to Admin role.");
        }
        else
        {
            Console.WriteLine("Failed to create Admin user.");
        }
    }

    // Ensure the Teacher role exists
    var teacherRoleExists = await roleManager.RoleExistsAsync("Teacher");
    if (!teacherRoleExists)
    {
        var teacherRoleResult = await roleManager.CreateAsync(new AppRole {Name = "Teacher"});
        if (!teacherRoleResult.Succeeded)
            Console.WriteLine("Failed to create Teacher role.");
    }

    // Create a teacher user
    var teacherUser = new AppUser
        {UserName = "teacher@eesti.ee", Email = "teacher@eesti.ee", FirstName = "Teacher", LastName = "Eesti"};
    var teacherUserExists = await userManager.FindByEmailAsync(teacherUser.Email);
    if (teacherUserExists == null)
    {
        var createUserResult = await userManager.CreateAsync(teacherUser, "Asd_123456");
        if (createUserResult.Succeeded)
        {
            var addToRoleResult = await userManager.AddToRoleAsync(teacherUser, "Teacher");
            if (!addToRoleResult.Succeeded)
                Console.WriteLine("Failed to add user to Teacher role.");
        }
        else
        {
            Console.WriteLine("Failed to create Teacher user.");
        }
    }
}