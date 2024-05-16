using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.IssueManagement.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();

    byte[] Test();
}
