using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Acme.IssueManagement;

[DependsOn(
    typeof(IssueManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class IssueManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(IssueManagementApplicationContractsModule).Assembly,
            IssueManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IssueManagementHttpApiClientModule>();
        });

    }
}
