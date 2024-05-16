using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Acme.IssueManagement.MongoDB;

[ConnectionStringName(IssueManagementDbProperties.ConnectionStringName)]
public class IssueManagementMongoDbContext : AbpMongoDbContext, IIssueManagementMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureIssueManagement();
    }
}
