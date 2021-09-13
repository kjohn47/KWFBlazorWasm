namespace KWFBlazorWasm.Configuration
{
    public interface IMenuOptions
    {
        string Name { get; }
        MenuAccessPolicyEnum? AccessPolicy { get; }
        string CustomAccessPolicy { get; }
    }
}
