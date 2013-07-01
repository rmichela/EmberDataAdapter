using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace EmberDataAdapterTests
{
    [TestClass]
    public class ScratchTests
    {
        [TestMethod]
        public void SerializeDictionary()
        {
            var map = new Dictionary<string, object>();
            map.Add("a_string", "FooBarCheese Bananas");
            map.Add("an_int", 42);
            map.Add("a_boolean", true);

            var top = new Dictionary<string, object>();
            top.Add("some_type", map);

            var json = JsonConvert.SerializeObject(top, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
