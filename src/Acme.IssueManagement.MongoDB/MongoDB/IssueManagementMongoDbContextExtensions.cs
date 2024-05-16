using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Acme.IssueManagement.MongoDB;

public static class IssueManagementMongoDbContextExtensions
{
    public static void ConfigureIssueManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
