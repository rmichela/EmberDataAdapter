using Newtonsoft.Json.Serialization;

namespace EmberDataAdapter.Internal
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
