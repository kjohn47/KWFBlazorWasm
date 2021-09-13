namespace KWFBlazorWasm.Configuration
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Components;

    public interface IKwfAppConfiguration
    {
        RenderFragment OverrideNotFoundComponent { get; }

        Type OverrideMainLayout { get; }

        IEnumerable<IMenuEntry> MenuDefinition { get; }

        IEndpointsConfiguration Endpoints { get; }
    }
}
