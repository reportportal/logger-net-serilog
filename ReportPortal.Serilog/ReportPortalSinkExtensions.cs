using Serilog;
using Serilog.Configuration;
using System;

namespace ReportPortal.Serilog
{
    public static class ReportPortalSinkExtensions
    {
        public static LoggerConfiguration ReportPortal(this LoggerSinkConfiguration loggerConfiguration, IFormatProvider formatProvider = null)
        {
            return loggerConfiguration.Sink(new ReportPortalSink(formatProvider));
        }
    }
}
