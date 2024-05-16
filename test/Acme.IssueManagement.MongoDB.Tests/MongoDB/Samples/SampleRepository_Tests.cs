using Acme.IssueManagement.Samples;
using Xunit;

namespace Acme.IssueManagement.MongoDB.Samples;

[Collection(MongoTestCollection.Name)]
public class SampleRepository_Tests : SampleRepository_Tests<IssueManagementMongoDbTestModule>
{
    /* Don't write custom repository tests here, instead write to
     * the base class.
     * One exception can be some specific tests related to MongoDB.
     */
}
