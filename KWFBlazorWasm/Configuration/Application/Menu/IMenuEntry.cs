namespace KWFBlazorWasm.Configuration.Application.Menu
{
    using System.Collections.Generic;

    public interface IMenuEntry : IMenuOptions
    {
        IEnumerable<IMenuLinkOptions> MenuList { get; }
    }
}
