using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AttriburesForTests
{
    public class Tests : BaseTest
    {
   
    [Test]
    [Fixture("sdsadsadasd")]
    [UserStory("USasdadas2222")]
    [RequirmentId("1.sdsd15.1")]
    [TestId(27775)]
    public void Test()
    {
      Thread.Sleep(2000);
    }

    [Test]
    [Fixture("sdsadsadasd")]
    [UserStory("USasdadas2222")]
    [RequirmentId("1.sdsd15.1")]
    [TestId(27775)]
    public void ts()
    {
      Thread.Sleep(2000);
    }
  }
}
