using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AttriburesForTests
{
    public class AttributeTests : BaseTest
    {
    [Ignore("Is not implemented yet")]
    [Test]
    [Fixture("F7723")]
    [UserStory("US2222")]
    [RequirmentId("1.15.1")]
    [TestId(25)]
    public void Test()
    {
      Thread.Sleep(2000);
    }

    [Test]
    [Fixture("F7756")]
    [UserStory("US2017")]
    [RequirmentId("2.18.7")]
    [TestId(99)]
    public void Test2()
    {
      Thread.Sleep(2000);
    }

  }
}
