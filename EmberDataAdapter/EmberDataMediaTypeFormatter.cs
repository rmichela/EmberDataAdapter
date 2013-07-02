using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmberDataAdapter
{
    public class EmberDataMediaTypeFormatter : MediaTypeFormatter
    {
        public EmberDataMediaTypeFormatter() : this(false) {}

        public EmberDataMediaTypeFormatter(bool useCustomEdMediaTypes)
        {
            // Set default supported media types
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json" + (useCustomEdMediaTypes ? "+emberdata" : "")));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/json" + (useCustomEdMediaTypes ? "+emberdata" : "")));

            // Set default supported character encodings
            SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true));
            SupportedEncodings.Add(new UnicodeEncoding(bigEndian: false, byteOrderMark: true, throwOnInvalidBytes: true));
            MediaTypeMappings.Add(new XmlHttpRequestHeaderMapping());
        }

        public bool Indent { get; set; }

        public JsonConverter[] Converters { get; set; }

        public override bool CanReadType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return true;
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (readStream == null)
            {
                throw new ArgumentNullException("readStream");
            }

            return Task.Factory.StartNew(() => ReadFromStream(type, readStream, content, formatterLogger));
        }

        private object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            throw new NotImplementedException();
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (writeStream == null)
            {
                throw new ArgumentNullException("writeStream");
            }

            return Task.Factory.StartNew(() => WriteToStream(type, value, writeStream, content));
        }

        private void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            Encoding effectiveEncoding = SelectCharacterEncoding(content == null ? null : content.Headers);

            var settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                TypeNameHandling = TypeNameHandling.Objects,
                ContractResolver = new EdContractResolver(),
                Binder = new EdSerializationBinder(),
                Converters = Converters
            };
            var serializer = JsonSerializer.Create(settings);
            using (var writer = new JTokenWriter())
            {
                serializer.Serialize(writer, value);
                var root = writer.Token;
                root = EdGraphRewriter.Deconstruct(root);

                using (var streamWriter = new StreamWriter(writeStream, effectiveEncoding))
                {
                    streamWriter.Write(root.ToString(Indent ? Formatting.Indented : Formatting.None));
                    streamWriter.Flush();
                }
            }
        }
    }
}
