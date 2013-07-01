using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmberDataAdapter
{
    public class EdSerializationBinder : SerializationBinder
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
