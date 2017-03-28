using System;
using System.Runtime.CompilerServices;
using System.Web;

namespace Samples.WebAPI.Helpers
{
    public sealed class ExceptionUtility
    {
        private ExceptionUtility() { }

        // Log an Exception
        public static void LogException(Exception exc, string misc = null,
            [CallerMemberName]string memberName = "",
            [CallerFilePath]string sourceFilePath = "",
            [CallerLineNumber]int sourceLineNumber = 0)
        {
            var _httpRequest = HttpContext.Current.Request;
            var _curUser = HttpContext.Current.User.Identity.Name.GetLastPart();
            var _className = exc.TargetSite.DeclaringType.FullName;
            var _methodName = memberName;
            var _IPAddress = Miscellaneous.GetIPAddress(req: _httpRequest);
            var _browser = _httpRequest.UserAgent;

            misc = misc ?? (sourceFilePath + " -- " + sourceLineNumber);
            misc = misc != null ? misc.Length >= 100 ? misc.Substring(0, 99) : misc : null;

            var details = exc.ToString();

            //Log the error as you would like

        }//End of function
    }
}