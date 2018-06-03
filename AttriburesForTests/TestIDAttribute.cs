using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttriburesForTests
{
 
  public class FixtureAttribute : PropertyAttribute
  {
    public FixtureAttribute(string fixture)
      :base(fixture)
    {
    }
  }

  public class UserStoryAttribute : PropertyAttribute
  {
    public UserStoryAttribute(string userStory)
      :base(userStory)
    {
    }
  }

  public class TestIdAttribute : PropertyAttribute
  {
    public TestIdAttribute(int testId)
      : base(testId)
    {
    }
  }

  public class RequirmentIdAttribute : PropertyAttribute
  {
    public RequirmentIdAttribute(string requirmentId)
      : base(requirmentId)
    {
    }
  }
}
