using Volo.Abp.Modularity;

namespace Acme.IssueManagement;

[DependsOn(
    typeof(IssueManagementApplicationModule),
    typeof(IssueManagementDomainTestModule)
    )]
public class IssueManagementApplicationTestModule : AbpModule
{

}
