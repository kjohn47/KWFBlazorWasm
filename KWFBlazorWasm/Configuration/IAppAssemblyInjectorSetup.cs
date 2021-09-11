namespace KWFBlazorWasm.Configuration
{
    using System;

    public interface IAppAssemblyInjectorSetup
    {
        IAppAssemblyInjectorSetup AddAdditionalAssembly(Type typeInAssembly);
        IAppAssemblyInjector Build();
    }
}
