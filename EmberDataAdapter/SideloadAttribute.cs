using System;

namespace EmberDataAdapter
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true)]
    public class SideloadAttribute : Attribute
    {
    }
}
