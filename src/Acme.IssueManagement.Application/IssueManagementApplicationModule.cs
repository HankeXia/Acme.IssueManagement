using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Acme.IssueManagement;

[DependsOn(
    typeof(IssueManagementDomainModule),
    typeof(IssueManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class IssueManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<IssueManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<IssueManagementApplicationModule>(validate: true);
        });
    }
}
