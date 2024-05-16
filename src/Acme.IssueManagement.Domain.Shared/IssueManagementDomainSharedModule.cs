using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Acme.IssueManagement.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Acme.IssueManagement;

[DependsOn(
    typeof(AbpValidationModule)
)]
public class IssueManagementDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IssueManagementDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<IssueManagementResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/IssueManagement");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("IssueManagement", typeof(IssueManagementResource));
        });
    }
}
