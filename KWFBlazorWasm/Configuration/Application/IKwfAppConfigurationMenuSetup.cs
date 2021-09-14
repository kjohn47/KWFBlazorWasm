namespace KWFBlazorWasm.Configuration.Application
{
    using KWFBlazorWasm.Configuration.Application.Menu;

    using System;

    public interface IKwfAppConfigurationMenuSetup
    {
        IKwfAppConfigurationMenuSetup AddMenuLink(Action<MenuLinkOptions> options);
        IKwfAppConfigurationSetup CreateMenu();
    }
}
