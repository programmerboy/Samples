using System;
using System.Diagnostics;
using System.Web.Http.ExceptionHandling;

namespace Samples.WebAPI.Helpers
{
    public class TraceExceptionLogger : ExceptionLogger
    {
        private readonly TraceSource _traceSource;

        public TraceExceptionLogger(TraceSource traceSource)
        {
            _traceSource = traceSource;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            string error = String.Format("Unhandled exception processing {0} for {1}: {2}", context.Request.Method, context.Request.RequestUri, context.Exception);

            _traceSource.TraceEvent(TraceEventType.Error, 1, error);
            ExceptionUtility.LogException(context.ExceptionContext.Exception, error);
        }
    }
}