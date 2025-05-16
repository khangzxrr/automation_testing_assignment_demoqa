
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

public class ExtentReportFixture : IDisposable
{
    public ExtentReports Extent { get; private set; }
    public ExtentSparkReporter Spark { get; private set; }

    public ExtentReportFixture()
    {
        var reportDictionary = Path.Combine(AppContext.BaseDirectory, ConfigurationManager.Config.ExtentReport.ReportPath);

        if (!Directory.Exists(reportDictionary))
        {
            Directory.CreateDirectory(reportDictionary);
        }

        var reportPath = Path.Combine(reportDictionary, $"Extent_{DateTime.Now:yyyyMMdd_HHmmss}.html");

        Spark = new ExtentSparkReporter(reportPath);

        Extent = new ExtentReports();
        Extent.AttachReporter(Spark);

    }

    public void Dispose()
    {
        Extent.Flush();
    }
}
