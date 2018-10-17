﻿using System;
using System.Collections.Generic;
using ReportPortal.Client.Models;
using ReportPortal.Shared;
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
        }
        protected Dictionary<LogEventLevel, LogLevel> LevelMap = new Dictionary<LogEventLevel, LogLevel>();

        public ReportPortalSink()
        {
            LevelMap[LogEventLevel.Debug] = LogLevel.Debug;
            LevelMap[LogEventLevel.Error] = LogLevel.Error;
            LevelMap[LogEventLevel.Fatal] = LogLevel.Fatal;
            LevelMap[LogEventLevel.Information] = LogLevel.Info;
            LevelMap[LogEventLevel.Verbose] = LogLevel.Trace;
            LevelMap[LogEventLevel.Warning] = LogLevel.Warning;
        }

        public void Emit(LogEvent logEvent)
        {
            var message = logEvent.RenderMessage(_formatProvider);

            var level = LogLevel.Info;
            if (LevelMap.ContainsKey(logEvent.Level))
            {
                level = LevelMap[logEvent.Level];
            }

            Bridge.LogMessage(level, message);
        }
    }
}