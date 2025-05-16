using AventStack.ExtentReports;

public class UnifiedLog
{
    private ExtentTest Test { get; }

    public UnifiedLog(ExtentTest test)
    {
        Test = test;
    }

    public void Info(string info)
    {
        Serilog.Log.Information(info);
        Test.Info(info);
    }

    public void Pass(string pass)
    {
        Serilog.Log.Information(pass);
        Test.Pass(pass);
    }

    public void Fail(Exception ex)
    {
        Serilog.Log.Error(ex.Message);
        Test.Fail(ex);
    }

}
