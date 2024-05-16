using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Acme.IssueManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(IssueManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class IssueManagementConsoleApiClientModule : AbpModule
{

}
