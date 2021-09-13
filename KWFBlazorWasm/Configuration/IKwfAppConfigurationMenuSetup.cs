namespace KWFBlazorWasm.Configuration
{
    using System;

    public interface IKwfAppConfigurationMenuSetup
    {
        IKwfAppConfigurationMenuSetup AddMenuLink(Action<MenuLinkOptions> options);
        IKwfAppConfigurationSetup CreateMenu();
    }
}
