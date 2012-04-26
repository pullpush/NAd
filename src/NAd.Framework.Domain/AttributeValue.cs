
namespace NAd.Framework.Domain
{
    public class AttributeValue<T>
    {
        public virtual string Name { get; set; }
        public virtual T Value { get; set; }
    }
}
