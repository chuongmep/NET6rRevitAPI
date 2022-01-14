using System.Reflection;
using System.Runtime.Loader;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ClassLibrary1;

[Transaction(TransactionMode.Manual)]
public class Class1 : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        for (;;)
        {
            var context = new SimpleUnloadableAssemblyLoadContext();
            Assembly assembly = context.LoadFromAssemblyPath(@"D:\API\Revit\xxx.dll");
            int executeAssembly = ExecuteAssembly(assembly, Array.Empty<string>());
            TaskDialog.Show("Test", executeAssembly.ToString());
            context.Unload();
            return Result.Succeeded;
        }

        int ExecuteAssembly(Assembly assembly, string[] args)
        {
            MethodInfo? entry = assembly.EntryPoint;

            object? result = entry == null || entry.GetParameters().Length <= 0
                ? entry?.Invoke(null, null)
                : entry.Invoke(null, new object[] {args});

            return (result != null) ? (int) result : 0;
        }
    }
}