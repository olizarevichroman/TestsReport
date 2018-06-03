using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using System.Linq;

namespace AttriburesForTests
{
  /// <summary>
  /// Provides an ability to write data from model to excel file with .xlsx extension
  /// </summary>
  /// <typeparam name="T">Type of model</typeparam>
    public class ReportHelper<T> : IDisposable where T: new()
    {
    private static bool isFirst = true;
    //private static bool isSaved = false;
    private static FileInfo fileInfo = new FileInfo($@"{Environment.CurrentDirectory}\..\..\..\report.xlsx");
    private static ExcelPackage excelPackage;
    private static ExcelWorksheet worksheet;
    private List<T> listOfModels = new List<T>();

    static ReportHelper()
    {
      excelPackage = new ExcelPackage(fileInfo);
      worksheet = excelPackage.Workbook.Worksheets.Add("Report");
    }

    public void Dispose()
    {
      excelPackage.Dispose();
    }

    public void Add(TestContext context)
    {
      listOfModels.Add(ModelConstructor<T>.GetModel(context));
    }

    public void Report()
    {
        worksheet.Cells.LoadFromCollection(listOfModels, isFirst);
        if (isFirst) isFirst = false;
      var address = worksheet.Cells.Address;
        excelPackage.Save();
      worksheet.Cells.Address = address;
      //List<TestReportModel> model = new List<TestReportModel>();
      //foreach (var context in testContexts)
      //{
      //  var newModel = new TestReportModel();
      //  var type = Type.GetType(context.Test.ClassName);
      //  string methodName = context.Test.MethodName;

      //  var methodInfo = type.GetMethod(methodName);
      //  var attributes =  methodInfo.GetCustomAttributes() ;

      //}
      //List<TestReportModel> list = new List<TestReportModel>();
      //foreach ( var method in members)
      //{
      //  var attributes = method.CustomAttributes;
      //  model = new TestReportModel
      //  {
      //    Fixture = attributes.ToArray()[1].ConstructorArguments[0].Value.ToString(),
      //    TestId = attributes.ToArray()[2].ConstructorArguments[0].Value.ToString(),
      //    UserStory = attributes.ToArray()[3].ConstructorArguments[0].Value.ToString()
      //  };
      //  list.Add(model);
      //}
      //worksheet.Cells.LoadFromCollection(list,true);
      //excelPackage.SaveAs(new FileInfo(fileName: path));
    }

    }
}
