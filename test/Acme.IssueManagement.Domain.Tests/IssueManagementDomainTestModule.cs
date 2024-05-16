using Acme.IssueManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.IssueManagement;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(IssueManagementEntityFrameworkCoreTestModule)
    )]
public class IssueManagementDomainTestModule : AbpModule
{

}
