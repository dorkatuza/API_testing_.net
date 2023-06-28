using Xunit;
using AventStack.ExtentReports;
using ApiTesting.Support;

public class TestFixture : IDisposable
{
    public ExtentReports Extent { get; private set; }

    public TestFixture()
    {
        Extent = ExtentReportManager.GetExtent();
    }

    public void Dispose()
    {
        Extent.Flush();
    }
}
