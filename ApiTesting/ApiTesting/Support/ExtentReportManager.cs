using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace ApiTesting.Support
{
    public class ExtentReportManager
    {
        private static ExtentReports extent;

        public static ExtentReports GetExtent()
        {
            if (extent == null)
            {
                string reportPath = @"C:\Users\Dorottya_Pecsi\Documents\ApiTesting\Reports\Report.html";
                var htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
            return extent;
        }
    }
}
