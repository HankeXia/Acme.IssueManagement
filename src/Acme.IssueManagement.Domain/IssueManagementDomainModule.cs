using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Acme.IssueManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(IssueManagementDomainSharedModule)
)]
public class IssueManagementDomainModule : AbpModule
{

}
