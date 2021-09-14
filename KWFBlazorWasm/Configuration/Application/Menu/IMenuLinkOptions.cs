namespace KWFBlazorWasm.Configuration.Application.Menu
{
    using Microsoft.AspNetCore.Components.Routing;

    public interface IMenuLinkOptions : IMenuOptions
    {
        string Href { get; }
        NavLinkMatch? Match { get; }
    }
}
