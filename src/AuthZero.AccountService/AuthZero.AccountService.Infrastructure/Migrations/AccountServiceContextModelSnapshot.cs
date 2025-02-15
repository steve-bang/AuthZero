﻿// <auto-generated />
using System;
using AuthZero.AccountService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuthZero.AccountService.Infrastructure.Migrations
{
    [DbContext(typeof(AccountServiceContext))]
    partial class AccountServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("AuthZero")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthZero.AccountService.Domain.AggregatesModel.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles", "AuthZero");
                });

            modelBuilder.Entity("AuthZero.AccountService.Domain.AggregatesModel.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Avatar_Url");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 12, 31, 9, 26, 15, 329, DateTimeKind.Utc).AddTicks(4070))
                        .HasColumnName("Created_At");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Email_Address");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("First_Name");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2")
                        .HasColumnName("Last_Login");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Last_Name");

                    b.Property<DateTime?>("LastUpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("Last_Update_At");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password_Hash");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Users", "AuthZero");
                });

            modelBuilder.Entity("User_Roles", b =>
                {
                    b.Property<Guid>("User_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Role_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("Last_Update_At")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("User_Id", "Role_Id");

                    b.HasIndex("Role_Id");

                    b.ToTable("User_Roles", "AuthZero");
                });

            modelBuilder.Entity("User_Roles", b =>
                {
                    b.HasOne("AuthZero.AccountService.Domain.AggregatesModel.Role", null)
                        .WithMany()
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthZero.AccountService.Domain.AggregatesModel.User.User", null)
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
