using System.Reflection;
using System.Runtime.Loader;

namespace ClassLibrary1;

public class SimpleUnloadableAssemblyLoadContext : AssemblyLoadContext
{
    public SimpleUnloadableAssemblyLoadContext()
        : base(isCollectible: true)
    {
    }

    protected override Assembly? Load(AssemblyName assemblyName) => null;
}