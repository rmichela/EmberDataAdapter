using Newtonsoft.Json.Serialization;

namespace EmberDataAdapter
{
    internal class EdContractResolver : DefaultContractResolver
    {
        public EdContractResolver() : base(true)
        {
            
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            return EdUtil.ToEdCase(propertyName);
        }
    }
}
