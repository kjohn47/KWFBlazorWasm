namespace KWFBlazorWasm.Configuration.Application
{
    using System;
    using System.Collections.Generic;

    using KWFBlazorWasm.Configuration.Application.Endpoints;
    using KWFBlazorWasm.Configuration.Application.Menu;

    using Microsoft.AspNetCore.Components;

    public interface IKwfAppConfiguration
    {
        RenderFragment OverrideNotFoundComponent { get; }

        Type OverrideMainLayout { get; }

        IEnumerable<IMenuEntry> MenuDefinition { get; }

        IEndpointsConfiguration Endpoints { get; }
    }
}
