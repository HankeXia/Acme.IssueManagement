using System;
using Acme.IssueManagement.Samples;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.IssueManagement.Controllers;

public class HomeController : AbpController
{
    private readonly ISampleAppService _sampleAppService;

    public HomeController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }


    public ActionResult Index()
    {
        return Redirect("~/swagger");
    }

    [HttpGet("testFastReport")]
    public IActionResult TestFastReport()
    {
        var result = _sampleAppService.Test();
        return File(result, "application/pdf", $"手术排班-{DateTime.Now:yyyyMMdd}");
    }
}
