using NUnit.Framework;
using System;
using System.Reflection;

namespace AttriburesForTests
{
  public static class ModelConstructor<T> where T:new()
    {

    public static T GetModel(TestContext context)
    {
      T model = new T();
      Type modelType = model.GetType();
      PropertyInfo[] propertiesInfo = modelType.GetProperties();
      foreach ( var property in propertiesInfo)
      {
        object number = context.Test.Properties.Get(property.Name);
        property.SetValue(model, number);
      }
      return model;
    }

    }
}
