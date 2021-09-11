namespace KWFBlazorWasm.Builder
{
    public interface IAttributeBuilder
    {
        IAttributeBuilder AddAttribute(string name, int value);

        IAttributeBuilder AddAttribute(string name, string value);

        IAttributeBuilder AddAttribute(string name, object value);
    }
}
