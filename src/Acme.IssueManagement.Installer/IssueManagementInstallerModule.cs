using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Acme.IssueManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class IssueManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IssueManagementInstallerModule>();
        });
    }
}
