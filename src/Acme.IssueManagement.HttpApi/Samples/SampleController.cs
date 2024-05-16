using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.IssueManagement.Samples;

[Area(IssueManagementRemoteServiceConsts.ModuleName)]
[RemoteService(Name = IssueManagementRemoteServiceConsts.RemoteServiceName)]
[Route("api/IssueManagement/sample")]
public class SampleController : AbpControllerBase
{
    private readonly ISampleAppService _sampleAppService;

    public SampleController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }


}
