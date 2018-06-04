using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using System.Linq;
using System.Text;

namespace AttriburesForTests
{
  /// <summary>
  /// Provides an ability to write data from model to excel file with .xlsx extension
  /// </summary>
  /// <typeparam name="T">Type of model</typeparam>
    public static class ReportHelper
    {
    private static object locker = new object();
    
    private static string path = $@"{Environment.CurrentDirectory}\..\..\..\..\Report.html";

    private static string table = "<table border=\"1\" style=\"border-collapse:collapse\">{0}</table>";

    private static string row = "<tr>{0}</tr>";

    private static string headerRow = "<tr style=\"font-weight:bold\">{0}</tr>";

    private static string item = "<td>{0}</td>";

    /// <summary>
    /// Data inside the table
    /// </summary>
    private static StringBuilder allData;

    private static PropertyInfo[] properties;

    public static void Report(TestContext context)
    {
      WriteData(GetFormat(table, GetView(context)));
    }

    private static string GetView(TestContext context)
    {
      StringBuilder builder = new StringBuilder();
      foreach(var property in properties)
      {
        builder.Append(GetFormat(item, context.Test.Properties[property.Name].FirstOrDefault()));
      }
      return allData.Append(GetFormat(row, builder.ToString())).ToString();
    }

    private static string GetFormat(string format, object value) => string.Format(format, value);

    private static void WriteData(string data)
    {
      lock (locker)
      {
        using (StreamWriter writer = new StreamWriter(path))
        {
          writer.Write(data);
        }
      }
    }

    static ReportHelper()
    {
      if (File.Exists(path))
      {
        File.Delete(path);
      }
      File.Create(path).Dispose();
      properties = typeof(TestReportModel).GetProperties();
      WriteHeaders();
    }

    private static void WriteHeaders()
    {
      StringBuilder builder = new StringBuilder();
      foreach (var property in properties)
      {
        builder.Append(GetFormat(item, property.Name));
      }
      allData = new StringBuilder(GetFormat(headerRow, builder.ToString()));
      WriteData(GetFormat(table, allData));
    }

    }
}
