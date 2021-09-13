namespace KWFBlazorWasm.Configuration
{
    public interface IKwfAppConfigurationMenuEntry
    {
        IKwfAppConfigurationSetup AddMenuDefinition(MenuEntry menuEntry);
    }
}
