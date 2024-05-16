using Acme.IssueManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.IssueManagement.Permissions;

public class IssueManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(IssueManagementPermissions.GroupName, L("Permission:IssueManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IssueManagementResource>(name);
    }
}
