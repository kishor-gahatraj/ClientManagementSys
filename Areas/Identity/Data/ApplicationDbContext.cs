using ClientManagementSys.Areas.Identity.Data;
using ClientManagementSys.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientManagementSys.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ProductOrganization>().HasKey(sc => new { sc.Product_Id, sc.Org_Id });

      
    
      
    

        base.OnModelCreating(builder);
        this.SeedUsers(builder);
        this.SeedUserRoles(builder);
        this.SeedRoles(builder);
        this.SeedCounter(builder);

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfugration());
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Product_Version> Product_Versions { get; set; }
    public DbSet<Expenses> Expenses { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<AMC> AMCs { get; set; }
    public DbSet<Progress_Report> Progress_Reports { get; set; }
    public DbSet<ProductOrganization> ProductOrganizations { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Org_Representative> Org_Representatives { get; set; }
    public DbSet<Counter_Table> Counter_Tables { get; set; }

    private void SeedCounter(ModelBuilder builder)
    {
        Counter_Table counter_Table = new Counter_Table()
        {
            Counter_Id = 1,
            Product_Quantity=0,
            Total_Organization=0,
            Total_User=1,


         };

        
        builder.Entity<Counter_Table>().HasData(counter_Table);

    }


    private void SeedUsers(ModelBuilder builder)
    {
        ApplicationUser user = new ApplicationUser()
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
           
            UserName = "Admin",
            Address = "Kathmandu",
            FirstName = "Admin1",
            LastName = "Admin2",
            Email = "admin@gmail.com",
            NormalizedUserName = "admin".ToUpper(),
            NormalizedEmail = "admin@gmail.com ".ToUpper(),
            EmailConfirmed = true,
            PhoneNumber = "1234567890",
            PhoneNumberConfirmed = true,
            LockoutEnabled = false,

        };

        user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, "Admin123!");
        builder.Entity<ApplicationUser>().HasData(user);
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = "1", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
            new IdentityRole() { Id = "2", Name = "Employee", ConcurrencyStamp = "2", NormalizedName = "Employee" }
            );
    }

    private void SeedUserRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { RoleId = "1", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
            );
    }


}
internal class ApplicationUserEntityConfugration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        //builder.Property(e => e.FirstName)
        //    .IsRequired()
        //    .HasMaxLength(50);

        //builder.Property(e => e.LastName)
        //   .IsRequired()
        //   .HasMaxLength(50);

        //builder.Property(e => e.Address)

        //   .HasMaxLength(255);



    }
}
