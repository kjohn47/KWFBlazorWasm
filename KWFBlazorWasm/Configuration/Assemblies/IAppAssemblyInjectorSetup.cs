namespace KWFBlazorWasm.Configuration.Assemblies
{
    using System;

    public interface IAppAssemblyInjectorSetup
    {
        IAppAssemblyInjectorSetup AddAdditionalAssembly(Type typeInAssembly);
        IAppAssemblyInjector Build();
    }
}
