using EmberDataAdapter;
using EmberDataAdapter.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace EmberDataAdapterTests.EmberDataContractResolverTests
{
    [TestClass]
    public class ResolvePropertyNameTests
    {
        private readonly SimpleThing _simple = new SimpleThing
        {
            Id = 1,
            ThingName = "The heart of the universe",
            IsUnknowable = true,
            ThisIs_AVeryLongNameForAProperty = "Indeed it is!"
        };

        [TestMethod]
        public void SingleWordPropertiesShouldWork()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new EdContractResolver()
            };

            string json = JsonConvert.SerializeObject(_simple, Formatting.Indented, settings);

            Assert.IsTrue(json.Contains("\"id\":"));
        }

        [TestMethod]
        public void MultiWordPropertiesShouldWork()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new EdContractResolver()
            };

            string json = JsonConvert.SerializeObject(_simple, Formatting.Indented, settings);

            Assert.IsTrue(json.Contains("\"thing_name\":"));
        }

        [TestMethod]
        public void PropertiesWithUnderscresShouldWork()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new EdContractResolver()
            };

            string json = JsonConvert.SerializeObject(_simple, Formatting.Indented, settings);

            Assert.IsTrue(json.Contains("\"this_is_a_very_long_name_for_a_property\":"));
        }

        [TestMethod]
        public void PrecedeingUnderscoresShouldWork()
        {
            var obj = new {_PrecedeingUnderscore = "indeed"};

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new EdContractResolver()
            };

            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);

            Assert.IsTrue(json.Contains("\"_precedeing_underscore\":"));
        }

        [TestMethod]
        public void AntecedingUnderscoresShouldWork()
        {
            var obj = new { AntecedingUnderscore_ = "indeed" };

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new EdContractResolver()
            };

            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);

            Assert.IsTrue(json.Contains("\"anteceding_underscore_\":"));
        }
    }
}
