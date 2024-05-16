using Acme.IssueManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.IssueManagement;

public abstract class IssueManagementController : AbpControllerBase
{
    protected IssueManagementController()
    {
        LocalizationResource = typeof(IssueManagementResource);
    }
}
