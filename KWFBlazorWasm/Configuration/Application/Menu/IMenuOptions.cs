namespace KWFBlazorWasm.Configuration.Application.Menu
{
    public interface IMenuOptions
    {
        string Name { get; }
        MenuAccessPolicyEnum? AccessPolicy { get; }
        string CustomAccessPolicy { get; }
    }
}
