using System;

namespace EmberDataAdapter
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EdAlternatePluralizationAttribute : Attribute
    {
        private readonly string _pluralName;

        public string PluralName { get { return _pluralName; } }

        public EdAlternatePluralizationAttribute(string pluralName)
        {
            _pluralName = pluralName;
        }
    }
}
