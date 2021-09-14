namespace KWFBlazorWasm.Configuration.Application.Menu
{
    using Microsoft.AspNetCore.Components.Routing;

    public class MenuLinkOptions : MenuOptions, IMenuLinkOptions
    {
        public string Href { get; set; }
        public NavLinkMatch? Match { get; set; }
    }
}
