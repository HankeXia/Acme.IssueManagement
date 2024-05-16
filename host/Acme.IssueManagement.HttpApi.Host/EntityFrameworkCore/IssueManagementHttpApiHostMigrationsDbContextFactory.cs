using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Acme.IssueManagement.EntityFrameworkCore;

public class IssueManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<IssueManagementHttpApiHostMigrationsDbContext>
{
    public IssueManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<IssueManagementHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("IssueManagement"));

        return new IssueManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
