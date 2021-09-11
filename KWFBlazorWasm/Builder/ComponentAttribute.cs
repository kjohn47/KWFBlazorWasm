namespace KWFBlazorWasm.Builder
{
    public class ComponentAttribute
    {
        private ComponentAttribute(string attributeName)
        {
            this.Name = attributeName;
        }

        public ComponentAttribute(string attributeName, int value) : this(attributeName)
        {
            this.Number = value;
            this.Type = AttributeTypeEnum.Number;
        }

        public ComponentAttribute(string attributeName, string value) : this(attributeName)
        {
            this.String = value;
            this.Type = AttributeTypeEnum.String;
        }

        public ComponentAttribute(string attributeName, object value) : this(attributeName)
        {
            this.Object = value;
            this.Type = AttributeTypeEnum.Object;
        }

        public string Name { get; private set; }
        public AttributeTypeEnum Type { get; private set; }
        public int? Number { get; private set; }
        public string String { get; private set ; }
        public object Object { get; private set ; }
    }
}
