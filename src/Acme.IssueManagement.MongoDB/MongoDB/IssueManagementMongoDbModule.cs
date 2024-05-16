using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Acme.IssueManagement.MongoDB;

[DependsOn(
    typeof(IssueManagementDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class IssueManagementMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<IssueManagementMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
