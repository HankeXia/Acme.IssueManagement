using System.Data;
using System.IO;
using System.Threading.Tasks;
using FastReport.Data;
using FastReport.Export.Pdf;
using FastReport.Utils;
using FastReport;
using Microsoft.AspNetCore.Authorization;
using FastReport.RichTextParser;

namespace Acme.IssueManagement.Samples;

public class SampleAppService : IssueManagementAppService, ISampleAppService
{
    public Task<SampleDto> GetAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    [Authorize]
    public Task<SampleDto> GetAuthorizedAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    public byte[] Test()
    {

        RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
        using var webReport = new Report();
        var fonts = Directory.GetFiles(Path.Combine("fonts/"));
        //Each font is added to the report generator configuration
        foreach (var font in fonts)
        {
            FontManager.AddFont(font);
        }

        webReport.Load("OperationSchedule1.frx");

        var dataTable = new DataTable("table1");
        dataTable.Columns.Add("name");
        dataTable.Columns.Add("sex");


        for (int i = 0; i < 10; i++)
        {
            var row = dataTable.NewRow();
            row["name"] = "张老师" + i;
            row["sex"] = "女性" + i;
            dataTable.Rows.Add(row);
        }
        webReport.Report.Dictionary.DataSources.Clear();

        var dataSource = new TableDataSource()
        {
            Name = dataTable.TableName,
            ReferenceName = dataTable.TableName,
            Table = dataTable
        };
        webReport.Report.Dictionary.DataSources.Add(dataSource);
        var databand = webReport.Report.FindObject("Data1") as DataBand;
        if (databand != null)
        {
            databand.DataSource = dataSource;
        }
        webReport.Report.RegisterData(dataTable, dataTable.TableName);//添加数据

        webReport.Report.Prepare(true);

        using var pdfExport = new PDFExport(); 

        //webReport.Report.Save("OperationSchedule.frx");

        webReport.Report.Export(pdfExport, "test1.pdf");
        using var memoryStream = new MemoryStream();
        webReport.Report.Export(pdfExport, memoryStream);
        //var html = Encoding.UTF8.GetString(memoryStream);
        var pdfByte = memoryStream.ToArray();
        return pdfByte;
    }
}
