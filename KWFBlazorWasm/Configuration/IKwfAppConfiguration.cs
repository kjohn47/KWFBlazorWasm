namespace KWFBlazorWasm.Configuration
{
    using System;

    using Microsoft.AspNetCore.Components;

    public interface IKwfAppConfiguration
    {
        RenderFragment OverrideNotFoundComponent { get; }

        Type OverrideMainLayout { get; }
    }
}
