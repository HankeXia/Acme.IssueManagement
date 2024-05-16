using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.IssueManagement.EntityFrameworkCore;

[ConnectionStringName(IssueManagementDbProperties.ConnectionStringName)]
public class IssueManagementDbContext : AbpDbContext<IssueManagementDbContext>, IIssueManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public IssueManagementDbContext(DbContextOptions<IssueManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureIssueManagement();
    }
}
