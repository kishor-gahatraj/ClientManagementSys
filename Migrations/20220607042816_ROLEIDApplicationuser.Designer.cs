﻿// <auto-generated />
using System;
using ClientManagementSys.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClientManagementSys.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220607042816_ROLEIDApplicationuser")]
    partial class ROLEIDApplicationuser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClientManagementSys.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                            AccessFailedCount = 0,
                            Address = "Kathmandu",
                            ConcurrencyStamp = "b477da73-d6ea-49d6-a51e-09c0821bf289",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Admin1",
                            LastName = "Admin2",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM ",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEPy7LCgTlzd7jKqyh0HhQz8UX9O+JekwDFnHn4WpKFI0xJY4rM0hI+EV4iIETeX3sQ==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = true,
                            RoleId = "1",
                            SecurityStamp = "395b95cb-53a5-495e-b063-b98f72129ac9",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("ClientManagementSys.Models.AMC", b =>
                {
                    b.Property<int>("AMC_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AMC_Id"), 1L, 1);

                    b.Property<int>("Maintenance_Charge")
                        .HasColumnType("int");

                    b.Property<DateTime>("Maintenance_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Org_Id")
                        .HasColumnType("int");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.HasKey("AMC_Id");

                    b.HasIndex("Org_Id")
                        .IsUnique();

                    b.HasIndex("Product_Id")
                        .IsUnique();

                    b.ToTable("AMCs");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Counter_Table", b =>
                {
                    b.Property<int>("Counter_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Counter_Id"), 1L, 1);

                    b.Property<int>("Product_Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Total_Organization")
                        .HasColumnType("int");

                    b.Property<int>("Total_User")
                        .HasColumnType("int");

                    b.HasKey("Counter_Id");

                    b.ToTable("Counter_Tables");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Expenses", b =>
                {
                    b.Property<int>("Expenses_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Expenses_Id"), 1L, 1);

                    b.Property<string>("Expenditure_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Expenditure_Price")
                        .HasColumnType("int");

                    b.Property<int>("Org_Id")
                        .HasColumnType("int");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int>("Total_Price")
                        .HasColumnType("int");

                    b.HasKey("Expenses_Id");

                    b.HasIndex("Org_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Invoice", b =>
                {
                    b.Property<int>("Invoice_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Invoice_Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Debit")
                        .HasColumnType("int");

                    b.Property<int>("Invoice_No")
                        .HasColumnType("int");

                    b.Property<int>("Org_Id")
                        .HasColumnType("int");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.HasKey("Invoice_Id");

                    b.HasIndex("Org_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Org_Representative", b =>
                {
                    b.Property<int>("Representative_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Representative_Id"), 1L, 1);

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Org_Id")
                        .HasColumnType("int");

                    b.Property<string>("Representative_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Representative_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Representative_FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Representative_Status")
                        .HasColumnType("bit");

                    b.HasKey("Representative_Id");

                    b.HasIndex("Org_Id")
                        .IsUnique();

                    b.ToTable("Org_Representatives");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Organization", b =>
                {
                    b.Property<int>("Org_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Org_Id"), 1L, 1);

                    b.Property<string>("Org_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Org_Contact")
                        .HasColumnType("bigint");

                    b.Property<string>("Org_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Org_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Org_Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Product", b =>
                {
                    b.Property<int>("Product_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Product_CompleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_Price")
                        .HasColumnType("int");

                    b.Property<bool>("Product_Status")
                        .HasColumnType("bit");

                    b.HasKey("Product_Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Product_Version", b =>
                {
                    b.Property<int>("Product_VersionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_VersionId"), 1L, 1);

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Product_VersionId");

                    b.HasIndex("Product_Id");

                    b.ToTable("Product_Versions");
                });

            modelBuilder.Entity("ClientManagementSys.Models.ProductOrganization", b =>
                {
                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int>("Org_Id")
                        .HasColumnType("int");

                    b.HasKey("Product_Id", "Org_Id");

                    b.HasIndex("Org_Id");

                    b.ToTable("ProductOrganizations");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Progress_Report", b =>
                {
                    b.Property<int>("Report_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Report_Id"), 1L, 1);

                    b.Property<DateTime>("Completion_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Current_Milestone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<string>("Supervisor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Total_Milestone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Report_Id");

                    b.HasIndex("Product_Id")
                        .IsUnique();

                    b.ToTable("Progress_Reports");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "1",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "2",
                            Name = "HR",
                            NormalizedName = "Human Resource"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
                            RoleId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ClientManagementSys.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityRole");
                });

            modelBuilder.Entity("ClientManagementSys.Models.AMC", b =>
                {
                    b.HasOne("ClientManagementSys.Models.Organization", "Organization")
                        .WithOne("AMC")
                        .HasForeignKey("ClientManagementSys.Models.AMC", "Org_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientManagementSys.Models.Product", "Product")
                        .WithOne("AMC")
                        .HasForeignKey("ClientManagementSys.Models.AMC", "Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Expenses", b =>
                {
                    b.HasOne("ClientManagementSys.Models.Organization", "Organization")
                        .WithMany("Expenses")
                        .HasForeignKey("Org_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientManagementSys.Models.Product", "Product")
                        .WithMany("Expenses")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Invoice", b =>
                {
                    b.HasOne("ClientManagementSys.Models.Organization", "Organization")
                        .WithMany("Invoice")
                        .HasForeignKey("Org_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientManagementSys.Models.Product", "Product")
                        .WithMany("Invoice")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Org_Representative", b =>
                {
                    b.HasOne("ClientManagementSys.Models.Organization", "Organization")
                        .WithOne("Org_Representative")
                        .HasForeignKey("ClientManagementSys.Models.Org_Representative", "Org_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Product_Version", b =>
                {
                    b.HasOne("ClientManagementSys.Models.Product", "Product")
                        .WithMany("Product_Version")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ClientManagementSys.Models.ProductOrganization", b =>
                {
                    b.HasOne("ClientManagementSys.Models.Organization", "Organization")
                        .WithMany("ProductOrganization")
                        .HasForeignKey("Org_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientManagementSys.Models.Product", "Product")
                        .WithMany("ProductOrganization")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Progress_Report", b =>
                {
                    b.HasOne("ClientManagementSys.Models.Product", "Product")
                        .WithOne("ReportId")
                        .HasForeignKey("ClientManagementSys.Models.Progress_Report", "Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ClientManagementSys.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ClientManagementSys.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientManagementSys.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ClientManagementSys.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClientManagementSys.Models.Organization", b =>
                {
                    b.Navigation("AMC")
                        .IsRequired();

                    b.Navigation("Expenses");

                    b.Navigation("Invoice");

                    b.Navigation("Org_Representative")
                        .IsRequired();

                    b.Navigation("ProductOrganization");
                });

            modelBuilder.Entity("ClientManagementSys.Models.Product", b =>
                {
                    b.Navigation("AMC")
                        .IsRequired();

                    b.Navigation("Expenses");

                    b.Navigation("Invoice");

                    b.Navigation("ProductOrganization");

                    b.Navigation("Product_Version");

                    b.Navigation("ReportId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
