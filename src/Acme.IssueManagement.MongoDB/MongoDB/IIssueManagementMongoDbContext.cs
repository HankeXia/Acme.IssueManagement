using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Acme.IssueManagement.MongoDB;

[ConnectionStringName(IssueManagementDbProperties.ConnectionStringName)]
public interface IIssueManagementMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
