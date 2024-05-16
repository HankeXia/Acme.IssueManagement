using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.IssueManagement.EntityFrameworkCore;

public class IssueManagementHttpApiHostMigrationsDbContext : AbpDbContext<IssueManagementHttpApiHostMigrationsDbContext>
{
    public IssueManagementHttpApiHostMigrationsDbContext(DbContextOptions<IssueManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureIssueManagement();
    }
}
