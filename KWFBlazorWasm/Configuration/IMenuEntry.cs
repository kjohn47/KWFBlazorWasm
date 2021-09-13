namespace KWFBlazorWasm.Configuration
{
    using System.Collections.Generic;

    public interface IMenuEntry : IMenuOptions
    {
        IEnumerable<IMenuLinkOptions> MenuList { get; }
    }
}
