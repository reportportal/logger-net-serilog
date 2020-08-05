using System;
using System.Collections.Generic;
using ReportPortal.Shared;
using ReportPortal.Shared.Execution.Logging;
using Serilog.Core;
using Serilog.Events;

namespace ReportPortal.Serilog
{
    /// <summary>
    /// Sink for reporting logs directly to Report Portal.
    /// Logs will be viewable under current test item from shared context.
    /// </summary>
    public class ReportPortalSink : ILogEventSink
    {
        private readonly IFormatProvider _formatProvider;

        public ReportPortalSink(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;

            LevelMap[LogEventLevel.Debug] = LogMessageLevel.Debug;
            LevelMap[LogEventLevel.Error] = LogMessageLevel.Error;
            LevelMap[LogEventLevel.Fatal] = LogMessageLevel.Fatal;
            LevelMap[LogEventLevel.Information] = LogMessageLevel.Info;
            LevelMap[LogEventLevel.Verbose] = LogMessageLevel.Trace;
            LevelMap[LogEventLevel.Warning] = LogMessageLevel.Warning;
        }

        protected Dictionary<LogEventLevel, LogMessageLevel> LevelMap = new Dictionary<LogEventLevel, LogMessageLevel>();

        public void Emit(LogEvent logEvent)
        {
            var level = LogMessageLevel.Info;
            if (LevelMap.ContainsKey(logEvent.Level))
            {
                level = LevelMap[logEvent.Level];
            }

            var logMessage = new LogMessage(logEvent.RenderMessage(_formatProvider));
            logMessage.Time = logEvent.Timestamp.UtcDateTime;
            logMessage.Level = level;

            Context.Current.Log.Message(logMessage);
        }
    }
}
