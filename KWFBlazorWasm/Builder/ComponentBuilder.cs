namespace KWFBlazorWasm.Builder
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    using System;

    public static class ComponentBuilder
    {
        public static RenderFragment Build(Type typeOfComponent, Action<IAttributeBuilder> attributeBuilder = null)
        {
            var attrBuilder = new AttributeBuilder();
            var increment = 1;
            attributeBuilder.Invoke(attrBuilder);

            return CreateFragment(builder => {
                builder.OpenComponent(0, typeOfComponent);
                foreach (var attr in attrBuilder.GetAttributes())
                {
                    switch (attr.Type)
                    {
                        case AttributeTypeEnum.Number:
                            {
                                builder.AddAttribute(increment, attr.Name, attr.Number);
                                break;
                            }
                        case AttributeTypeEnum.String:
                            {
                                builder.AddAttribute(increment, attr.Name, attr.String);
                                break;
                            }
                        case AttributeTypeEnum.Object:
                            {
                                builder.AddAttribute(increment, attr.Name, attr.Object);
                                break;
                            }
                    }
                    increment++;
                }

                builder.CloseComponent();
            });
        }

        public static RenderFragment Build<TComponent>(Action<IAttributeBuilder> attributeBuilder = null)
            where TComponent : notnull, IComponent
        {
            return Build(typeof(TComponent), attributeBuilder);
        }

        private static RenderFragment CreateFragment(Action<RenderTreeBuilder> builder) => b => builder.Invoke(b);
    }
}
