
using AuthZero.AccountService.Domain.AggregatesModel;
using AuthZero.AccountService.Domain.AggregatesModel.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthZero.AccountService.Infrastructure.EntitiesConfiguration;

/// <summary>
/// The configuration for the user entity. <see cref="User"/>
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        // Auto-increment the ID
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>(
                "User_Roles", // Table name for the join table between users and roles
                userRole => 
                    userRole
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("Role_Id") // Foreign key for Role
                    .OnDelete(DeleteBehavior.Cascade),
                userRole => userRole
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("User_Id") // Foreign key for User
                    .OnDelete(DeleteBehavior.Cascade),
                userRole =>
                {
                    userRole.HasKey("User_Id", "Role_Id");
                    userRole.Property<DateTime>("Last_Update_At").HasDefaultValueSql("GETDATE()");
                    userRole.Property<DateTime>("Created_Date").HasDefaultValueSql("GETDATE()");
                });

        builder
            .Property(x => x.EmailAddress)
            .HasColumnName("Email_Address")
            .IsRequired();

        // Unique constraint on email address
        builder
            .HasIndex(x => x.EmailAddress)
            .IsUnique();

        builder
            .Property(x => x.FirstName)
            .HasColumnName("First_Name");

        builder
            .Property(x => x.LastName)
            .HasColumnName("Last_Name");

        builder
            .Property(x => x.PasswordHash)
            .HasColumnName("Password_Hash")
            .IsRequired();

        builder
            .Property(x => x.Salt)
            .IsRequired();

        builder
            .Property(x => x.AvatarUrl)
            .HasColumnName("Avatar_Url");

        builder
            .Property(x => x.LastLogin)
            .HasColumnName("Last_Login");

        builder
            .Property(x => x.Bio);

        builder
            .Property(x => x.LastUpdateAt)
            .HasColumnName("Last_Update_At");

        builder
            .Property(x => x.CreatedAt)
            .HasColumnName("Created_At")
            .HasDefaultValue(DateTime.UtcNow);
    }
}