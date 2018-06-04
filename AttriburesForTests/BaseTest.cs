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
    

    [TearDown]
    protected void TearDown()
    {
      ReportHelper.Report(TestContext.CurrentContext);
    }

    }
}
