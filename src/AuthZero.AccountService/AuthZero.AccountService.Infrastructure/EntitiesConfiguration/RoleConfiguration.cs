
using AuthZero.AccountService.Domain.AggregatesModel;
using AuthZero.AccountService.Domain.AggregatesModel.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthZero.AccountService.Infrastructure.EntitiesConfiguration;

/// <summary>
/// The configuration for the role entity. <see cref="Role"/>
/// </summary>
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);

        // Auto-increment the ID
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}