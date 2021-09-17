namespace KWFBlazorWasm.Context.Application
{
    using KWFBlazorWasm.Configuration.Application;
    using KWFBlazorWasm.Configuration.Assemblies;
    using KWFBlazorWasm.Configuration.Json;

    public interface IApplicationContext
    {
        IAppAssemblyInjector AppAssemblies { get; }
        IKwfAppConfiguration Configuration { get; }
        KwfJsonSerializerOptions StandartAppJsonSettings { get; }
        void ForceAppRender();
    }
}
