namespace KWFBlazorWasm.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AttributeBuilder : IAttributeBuilder
    {
        private List<ComponentAttribute> attributes;

        public AttributeBuilder()
        {
            attributes = new List<ComponentAttribute>();
        }

        public IAttributeBuilder AddAttribute(string name, int value)
        {
            this.VerifyAttributeName(name);
            this.attributes.Add(new ComponentAttribute(name, value));
            return this;
        }

        public IAttributeBuilder AddAttribute(string name, string value)
        {
            this.VerifyAttributeName(name);
            this.attributes.Add(new ComponentAttribute(name, value));
            return this;
        }

        public IAttributeBuilder AddAttribute(string name, object value)
        {
            this.VerifyAttributeName(name);
            this.attributes.Add(new ComponentAttribute(name, value));
            return this;
        }

        public IEnumerable<ComponentAttribute> GetAttributes()
        {
            return this.attributes;
        }

        private void VerifyAttributeName(string name)
        {
            if (this.attributes.Any(x => x.Name.Equals(name)))
            {
                throw new InvalidOperationException($"Attribute {name} was already added");
            }
        }
    }
}
