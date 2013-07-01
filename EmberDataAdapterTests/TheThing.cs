using System.Collections.Generic;

namespace EmberDataAdapterTests
{
    public class TheThing
    {
        public int Id { get; set; }
        public string ABigName { get; set; }
        public SubThingOne ThingNumberOne { get; set; }
        public List<SubThingTwo> ThingNumberTwos { get; set; } 
    }

    public class SubThingOne
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class SubThingTwo
    {
        public int Id { get; set; }
        public string PreferredBeverage;
        public SubThingOne ComplexRelationshipStatus;
    }

    public class SimpleThing
    {
        public int Id { get; set; }
        public string ThingName { get; set; }
        public bool IsUnknowable { get; set; }
        public string ThisIs_AVeryLongNameForAProperty { get; set; }
    }
}
