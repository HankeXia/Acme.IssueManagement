using Acme.IssueManagement.Localization;
using Volo.Abp.Application.Services;

namespace Acme.IssueManagement;

public abstract class IssueManagementAppService : ApplicationService
{
    protected IssueManagementAppService()
    {
        LocalizationResource = typeof(IssueManagementResource);
        ObjectMapperContext = typeof(IssueManagementApplicationModule);
    }
}
