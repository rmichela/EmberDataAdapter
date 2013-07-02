using System;
using System.Runtime.Serialization;

namespace EmberDataAdapter
{
    internal class EdSerializationBinder : SerializationBinder
    {
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            // TODO: Look for Ember Data type name attribute first
            assemblyName = null;
            typeName = EdUtil.ToEdCase(serializedType.Name);
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            throw new NotImplementedException();
        }
    }
}
