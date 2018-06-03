using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AttriburesForTests
{
    [TestFixture]
    public class BaseTest
    {
    private ReportHelper<TestReportModel> reportHelper = new ReportHelper<TestReportModel>();

    [OneTimeTearDown]
    protected void OneTimeTearDown()
    {
      //var testMethod = type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly 
      //  | BindingFlags.Public);

      //reportHelper.Report(testMethod);
      reportHelper.Report();
    }

    [TearDown]
    protected void TearDown()
    {
      reportHelper.Add(TestContext.CurrentContext);
    }

    }
}
