using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Samples.WebAPI.Helpers
{
    public class FileDownloadHelper
    {
        public static HttpResponseMessage DownloadTxtFile(string content, string fileName)
        {
            MemoryStream _memoryStream = new MemoryStream();
            TextWriter _tw = new StreamWriter(_memoryStream);
            _tw.Write(content);
            _tw.Flush();
            _tw.Close();

            var _result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(_memoryStream.ToArray()) };
            _result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = fileName };
            _result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/txt");

            return _result;
        }
    }
}