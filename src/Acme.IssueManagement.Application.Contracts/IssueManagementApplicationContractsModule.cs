using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Acme.IssueManagement;

[DependsOn(
    typeof(IssueManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class IssueManagementApplicationContractsModule : AbpModule
{

}
