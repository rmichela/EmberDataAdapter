using System;
using System.Collections.Generic;
using EmberDataAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace EmberDataAdapterTests.EmberDataJsonConvertTests
{
    [TestClass]
    public class SerializeObjectTests
    {
        private static readonly SimpleThing Simple = new SimpleThing
        {
            Id = 1,
            ThingName = "The heart of the universe",
            IsUnknowable = true,
            ThisIs_AVeryLongNameForAProperty = "Indeed it is!"
        };

        private static readonly SubThingOne SameThing = new SubThingOne
            {
                Id = 101,
                Description = "The same thing"
            };

        private static readonly TheThing Complex = new TheThing
            {
                Id = 1,
                ABigName = "Big Name",
                ThingNumberOne = new SubThingOne
                    {
                        Id = 10,
                        Description = "Description 10"
                    },
                ThingNumberTwos = new List<SubThingTwo>
                    {
                        new SubThingTwo
                            {
                                Id = 20,
                                PreferredBeverage = "Coke",
                                ComplexRelationshipStatus = SameThing
                            },
                        new SubThingTwo
                            {
                                Id = 21,
                                PreferredBeverage = "Pepsi",
                                ComplexRelationshipStatus = SameThing
                            }
                    }
            };

        [TestMethod]
        public void Foo()
        {
            var json = EmberDataJsonConvert.SerializeObject(Complex, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
