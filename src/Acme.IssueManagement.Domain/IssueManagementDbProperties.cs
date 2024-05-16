namespace Acme.IssueManagement;

public static class IssueManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "IssueManagement";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "IssueManagement";
}
