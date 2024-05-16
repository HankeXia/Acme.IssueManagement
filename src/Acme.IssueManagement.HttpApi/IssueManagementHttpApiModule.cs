using Localization.Resources.AbpUi;
using Acme.IssueManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Acme.IssueManagement;

[DependsOn(
    typeof(IssueManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class IssueManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(IssueManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<IssueManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
