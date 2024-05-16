using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.IssueManagement.EntityFrameworkCore;

[ConnectionStringName(IssueManagementDbProperties.ConnectionStringName)]
public interface IIssueManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
