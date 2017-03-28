using System.Collections.Generic;

namespace Samples.WebAPI.Helpers
{
    public class MIMETypes
    {
        public static Dictionary<string,string> GetOfficeMimeTypes()
        {
            Dictionary<string, string> mimeTypes = new Dictionary<string, string>();

            mimeTypes.Add(".doc", "application/msword");
            mimeTypes.Add(".dot", "application/msword");

            mimeTypes.Add(".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            mimeTypes.Add(".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template");
            mimeTypes.Add(".docm", "application/vnd.ms-word.document.macroEnabled.12");
            mimeTypes.Add(".dotm", "application/vnd.ms-word.template.macroEnabled.12");

            mimeTypes.Add(".xls", "application/vnd.ms-excel");
            mimeTypes.Add(".xlt", "application/vnd.ms-excel");
            mimeTypes.Add(".xla", "application/vnd.ms-excel");

            mimeTypes.Add(".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            mimeTypes.Add(".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template");
            mimeTypes.Add(".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12");
            mimeTypes.Add(".xltm", "application/vnd.ms-excel.template.macroEnabled.12");
            mimeTypes.Add(".xlam", "application/vnd.ms-excel.Addin.macroEnabled.12");
            mimeTypes.Add(".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12");

            mimeTypes.Add(".ppt", "application/vnd.ms-powerpoint");
            mimeTypes.Add(".pot", "application/vnd.ms-powerpoint");
            mimeTypes.Add(".pps", "application/vnd.ms-powerpoint");
            mimeTypes.Add(".ppa", "application/vnd.ms-powerpoint");

            mimeTypes.Add(".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation");
            mimeTypes.Add(".potx", "application/vnd.openxmlformats-officedocument.presentationml.template");
            mimeTypes.Add(".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow");
            mimeTypes.Add(".ppam", "application/vnd.ms-powerpoint.Addin.macroEnabled.12");
            mimeTypes.Add(".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12");
            mimeTypes.Add(".potm", "application/vnd.ms-powerpoint.template.macroEnabled.12");
            mimeTypes.Add(".ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12");

            mimeTypes.Add(".txt", "text/plain");

            return mimeTypes;
        }

        public static Dictionary<string, string> GetImageMimeTypes()
        {
            Dictionary<string, string> mimeTypes = new Dictionary<string, string>();
            mimeTypes.Add(".png", "_image/png");
            mimeTypes.Add(".jpeg", "_image/jpeg");
            mimeTypes.Add(".jpg", "_image/jpeg");
            mimeTypes.Add(".gif", "_image/gif");
            mimeTypes.Add(".bmp", "_image/bmp");
            mimeTypes.Add(".tiff", "_image/tiff");
            mimeTypes.Add(".pdf", "application/pdf");

            return mimeTypes;
        }
    }
}