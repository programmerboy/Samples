using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using NPOI.SS.UserModel;

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
        
        public static HttpResponseMessage DownloadExcelFile(IWorkbook _wb, string fileName)
        {
            var _memoryStream = new NpoiMemoryStream();
            _memoryStream.AllowClose = false;
            _wb.Write(_memoryStream);
            _memoryStream.Flush();
            _memoryStream.Seek(0, SeekOrigin.Begin);
            _memoryStream.AllowClose = true;
            _memoryStream.Position = 0;

            var _contentType = Miscellaneous.GetContentMIMEType(".xlsx");
            //_contentType = "application/octet-stream";
            var _result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(_memoryStream.ToArray()) };
            _result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = fileName };
            _result.Content.Headers.ContentType = new MediaTypeHeaderValue(_contentType);

            return _result;
        }

        public static HttpResponseMessage DownloadExcelFile(String _excelContent, string fileName)
        {
            var _contentType = Miscellaneous.GetContentMIMEType(".xls");
            var stream = new MemoryStream();
            var sw = new StreamWriter(stream);
            sw.Write(_excelContent);
            sw.Flush();

            var _result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(stream.GetBuffer()) };
            _result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = String.Format("{0}.xml", fileName) };
            _result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/ms-excel");

            return _result;
        }

        public class NpoiMemoryStream : MemoryStream
        {
            public NpoiMemoryStream()
            {
                AllowClose = true;
            }

            public bool AllowClose { get; set; }

            public override void Close()
            {
                if (AllowClose)
                    base.Close();
            }
        }
    }
}
