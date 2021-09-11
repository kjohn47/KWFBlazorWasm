namespace KWFBlazorWasm.Configuration
{
    using System.Collections.Generic;
    using System.Reflection;

    public interface IAppAssemblyInjector
    {
        Assembly MainAssembly { get; }
        IEnumerable<Assembly> AdditionalAssemblies { get; }
    }
}
