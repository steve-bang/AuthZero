

using AuthZero.AccountService.Domain.AggregatesModel;
using AuthZero.AccountService.Domain.AggregatesModel.User;
using AuthZero.AccountService.Domain.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AuthZero.AccountService.Infrastructure;

/// <summary>
/// The database context for the account service.
/// How to use migrations:
/// 1. Move to the AuthZero.AccountService.Infrastructure folder and run the following command:
/// 2. dotnet ef migrations add your-migraiton --startup-project ../AuthZero.AccountService.WebApi --context AccountServiceContext
/// </summary>
public class AccountServiceContext(
    DbContextOptions<AccountServiceContext> options,
    IMediator _mediator
    ): DbContext(options), IUnitOfWork
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Set the default schema
        modelBuilder.HasDefaultSchema("AuthZero");
        
        // Apply the configurations from the assembly
        modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(AccountServiceContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    optionsBuilder
        .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }


    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        // Dispatch Domain Events collection. 
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
        // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
        // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
        await _mediator.DispatchDomainEventsAsync(this);

        // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
        // performed through the DbContext will be committed
        _ = await base.SaveChangesAsync(cancellationToken);

        return true;
    }
}