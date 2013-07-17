using EmberDataAdapter.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmberDataAdapter
{
    public static class EmberDataJsonConvert
    {
        public static string SerializeObject(object value)
        {
            return SerializeObject(value, Formatting.None, null);
        }

        public static string SerializeObject(object value, Formatting formatting)
        {
            return SerializeObject(value, formatting, null);
        }

        public static string SerializeObject(object value, params JsonConverter[] converters)
        {
            return SerializeObject(value, Formatting.None, converters);
        }

        public static string SerializeObject(object value, Formatting formatting, params JsonConverter[] converters)
        {
            var settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                TypeNameHandling = TypeNameHandling.Objects,
                ContractResolver = new EdContractResolver(),
                Binder = new EdSerializationBinder(),
                Converters = converters
            };
            var serializer = JsonSerializer.Create(settings);
            using (var writer = new JTokenWriter())
            {
                serializer.Serialize(writer, value);
                var root = (JObject)writer.Token;
                root = GraphRewriter.Deconstruct(root);

                return root.ToString(formatting);
            }
        }
    }
}
