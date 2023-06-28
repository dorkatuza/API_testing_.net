using Xunit;
using AventStack.ExtentReports;

public class BaseTest : IClassFixture<TestFixture>
{
    protected ExtentTest test;
    protected ExtentReports extent;

    public BaseTest(TestFixture fixture)
    {
        extent = fixture.Extent;
    }

    public void StartTest(string testName)
    {
        test = extent.CreateTest(testName);
    }

    public void EndTest()
    {
        extent.Flush();
    }
}
