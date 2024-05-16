using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.IssueManagement.EntityFrameworkCore;

[DependsOn(
    typeof(IssueManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class IssueManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<IssueManagementDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
