using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ClientManagementSys.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)

//            .AddEntityFrameworkStores<ApplicationDbContext>()



// Add services to the container.
builder.Services.AddControllersWithViews();
void ConfigureServices(IServiceCollection services)
{
    #region database configuration              
    //string connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
    //services.AddAuthorization(options =>
    //{
    //    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    //});


    

    //services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    ////services.AddDefaultIdentity<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
    //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
    //services.AddIdentity<ApplicationUser, IdentityRole>()
    //     .AddRoles<IdentityRole>()
    //    .AddEntityFrameworkStores<ApplicationDbContext>();
    //services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>,
    //      ApplicationUserClaimsPrincipalFactory
    //      >();
    #endregion
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for Production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DashBoard}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
