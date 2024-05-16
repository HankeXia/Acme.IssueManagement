using Volo.Abp.Reflection;

namespace Acme.IssueManagement.Permissions;

public class IssueManagementPermissions
{
    public const string GroupName = "IssueManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(IssueManagementPermissions));
    }
}
