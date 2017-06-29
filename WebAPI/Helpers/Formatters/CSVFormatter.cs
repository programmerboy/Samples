using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Samples.WebAPI.Helpers.Formatters
{
    public class CSVFormatter : MediaTypeFormatter
    {
        private string FileName { get; set; }

        public CSVFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));

            SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            SupportedEncodings.Add(Encoding.GetEncoding("iso-8859-1"));
        }

        public CSVFormatter(MediaTypeMapping mediaTypeMapping)
            : this()
        {
            MediaTypeMappings.Add(mediaTypeMapping);

            SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            SupportedEncodings.Add(Encoding.GetEncoding("iso-8859-1"));
        }

        public CSVFormatter(IEnumerable<MediaTypeMapping> mediaTypeMappings)
            : this()
        {
            foreach (var mediaTypeMapping in mediaTypeMappings)
            {
                MediaTypeMappings.Add(mediaTypeMapping);
            }

            SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            SupportedEncodings.Add(Encoding.GetEncoding("iso-8859-1"));
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.Add("Content-Disposition", string.Format("attachment; filename={0}", FileName));
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
             //Usuage: In Controller Action:
            //if (!Request.Properties.ContainsKey("filename"))
            //Request.Properties.Add("filename", String.Format("SomeFileName_{0}.csv", DateTime.Now.ToString("yyyyMMdd-hhmmss")));
            
            if (request.Properties.ContainsKey("filename"))
            {
                FileName = request.Properties["filename"] as string;
            }
            else if (!String.IsNullOrWhiteSpace(FileName = request.GetQueryString("filename")))
            {
                FileName = FileName.CustomCompare(".csv") ? FileName : FileName + ".csv";
            }
            else
            {
                FileName = String.Format("Data-{0}.csv", DateTime.Now.ToString("yyyyMMdd-HHmmss"));
            }
            
            return this;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            return isTypeOfIEnumerable(type);
        }

        private bool isTypeOfIEnumerable(Type type)
        {
            foreach (Type interfaceType in type.GetInterfaces())
            {
                if (interfaceType == typeof(IEnumerable))
                { return true; }
            }
            return false;
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream stream, HttpContent content, TransportContext transportContext)
        {
            writeStream(type, value, stream, content);
            var tcs = new TaskCompletionSource<int>();
            tcs.SetResult(0);
            return tcs.Task;
        }

        private void writeStream(Type type, object value, Stream stream, HttpContent content)
        {
            //NOTE: We have check the type inside CanWriteType method. If request comes this far, the type is IEnumerable. We are safe.

            Encoding effectiveEncoding = SelectCharacterEncoding(content.Headers);
            Type itemType = type.GetGenericArguments()[0];


            using (var writer = new StreamWriter(stream, effectiveEncoding))
            {
                //Write out columns
                writer.WriteLine(string.Join<string>(",", itemType.GetProperties().Select(x => x.Name)));

                foreach (var obj in (IEnumerable<object>)value)
                {
                    var vals = obj.GetType().GetProperties().Select(pi => new { Value = pi.GetValue(obj, null) });
                    string _valueLine = string.Empty;

                    foreach (var val in vals)
                    {
                        var columnValue = Escape(val.Value);
                        _valueLine = string.Concat(_valueLine, columnValue, ",");
                    }

                    _valueLine = _valueLine.Substring(0, _valueLine.Length - 1);
                    writer.WriteLine(_valueLine);
                }
            }
        }

        #region Escape Characters
        static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };

        private string Escape(object o)
        {
            if (o == null)
                return String.Empty;
            
            string field = o.ToString();

            // Delimit the entire field with quotes and replace embedded quotes with "".
            if (field.IndexOfAny(_specialChars) != -1)
                return String.Format("\"{0}\"", field.Replace("\"", "\"\""));
            else return field;

            //Quote forcefully
            //return String.Format("\"{0}\"", field.Replace("\"", "\"\""));
        }
        #endregion
    }
}
