using System;

namespace EmberDataAdapter
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EdAlternateNameAttribute : Attribute
    {
        private readonly string _singularName;
        private readonly string _pluralName;

        public string SingularName { get { return _singularName; } }
        public string PluralName { get { return _pluralName; } }

        public EdAlternateNameAttribute(string singularName, string pluralName)
        {
            _singularName = singularName;
            _pluralName = pluralName;
        }
    }
}
