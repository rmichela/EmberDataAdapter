using System;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace EmberDataAdapter
{
    public class EdContractResolver : DefaultContractResolver
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
