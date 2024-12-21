


// using Microsoft.EntityFrameworkCore.Design;

// namespace AuthZero.AppHost;

// public sealed class DataContextDesignTimeFactory :
// 	IDesignTimeDbContextFactory<AccountServiceContex.Database>
// {
//     public Data.Database CreateDbContext(string[] args)
//     {
//         var builder = DistributedApplication.CreateBuilder(args);
    
//         var postgres = builder
//             .AddPostgres("postgres")
//             .AddDatabase("migrations", databaseName: "migrations");

//         var optionsBuilder = new DbContextOptionsBuilder<Data.Database>();
//         optionsBuilder.UseNpgsql("migrations");
//         return new Data.Database(optionsBuilder.Options);
//     }
// }