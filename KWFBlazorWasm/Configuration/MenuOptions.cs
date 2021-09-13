namespace KWFBlazorWasm.Configuration
{
    public class MenuOptions : IMenuOptions
    {
        public string Name { get; set; }
        public MenuAccessPolicyEnum? AccessPolicy { get; set; }
        public string CustomAccessPolicy { get; set; }
    }
}
