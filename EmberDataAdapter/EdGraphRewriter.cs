using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace EmberDataAdapter
{
    public static class EdGraphRewriter
    {
        public static JObject Deconstruct(JObject root)
        {
            var workingSet = new Dictionary<string, List<JObject>>();
            DeconstructImpl(workingSet, root);

            var newRoot = new JObject();
            foreach (var typeCollection in workingSet)
            {
                var typeArray = new JArray(typeCollection.Value.ToArray());
                newRoot.Add(typeCollection.Key, typeArray);
            }

            // Remove $type properties
            foreach (JObject c in newRoot.Children().SelectMany(c => c.Children()).SelectMany(c => c.Children()))
            {
                c.Remove("$type");
            }

            return newRoot;
        }

        private static void DeconstructImpl(Dictionary<string, List<JObject>> workingSet, JObject localRoot)
        {
            var name = GetEdTypeName(localRoot);

            // Create a type collection as necessary
            List<JObject> typeCollection;
            if(!workingSet.TryGetValue(name, out typeCollection))
            {
                typeCollection = new List<JObject>();
                workingSet.Add(name, typeCollection);
            }
            typeCollection.Add(localRoot);

            // Recursively locate all type definitions
            var directObjectRefs = localRoot.Properties()
                                            .Where(p => p.Value.Type == JTokenType.Object)
                                            .Select(p => p.Value)
                                            .Cast<JObject>();
            var arrayObjectRefs = localRoot.Properties()
                                           .Where(p => p.Value.Type == JTokenType.Array)
                                           .Select(p => p.Value)
                                           .Cast<JArray>()
                                           .SelectMany(a => a.Children())
                                           .Where(v => v.Type == JTokenType.Object)
                                           .Cast<JObject>();
  

            foreach (var o in arrayObjectRefs.Union(directObjectRefs))
            {
                DeconstructImpl(workingSet, o);
            }

            // Indirect object references
            foreach (var p in localRoot.Properties().Where(p => p.Value.Type == JTokenType.Object))
            {
                p.Value = GetEdIdFieldValue((JObject) p.Value);
            }
            // Object references through arrays
            foreach (var p in localRoot.Properties().ToArray().Where(p => p.Value.Type == JTokenType.Array))
            {
                var newArray = new JArray(p.Value.Children<JObject>().Select(GetEdIdFieldValue).ToArray());
                localRoot.Remove(p.Name);
                localRoot.Add(GetEdReferenceArrayName(p.Name), newArray);
            }
        }

        private static string GetEdTypeName(JObject obj)
        {
            return obj.Properties().Where(p => p.Name == "$type").Select(p => p.Value.Value<string>() + "s").First();
        }

        private static JToken GetEdIdFieldValue(JObject obj)
        {
            // TODO: Add annotation support
            const string propertyFieldName = "id";
            return obj.Properties().Where(p => p.Name == propertyFieldName).Select(p => p.Value).First();
        }

        private static string GetEdReferenceArrayName(string propertyName)
        {
            return propertyName + "_ids";
        }
    }
}
