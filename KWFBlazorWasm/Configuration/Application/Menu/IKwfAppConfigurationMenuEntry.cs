namespace KWFBlazorWasm.Configuration.Application.Menu
{
    public interface IKwfAppConfigurationMenuEntry
    {
        IKwfAppConfigurationSetup AddMenuDefinition(MenuEntry menuEntry);
    }
}
