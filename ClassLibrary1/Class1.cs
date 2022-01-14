using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ClassLibrary1;

[Transaction( TransactionMode.Manual)]
public class Class1 : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        TaskDialog.Show("Hello","This is a content");
        var parse = (string s) => int.Parse(s);
        TaskDialog.Show("Test", parse.ToString());
        return Result.Succeeded;
    }
}