[![Build status](https://ci.appveyor.com/api/projects/status/59upft81iy2fc4ni/branch/master?svg=true)](https://ci.appveyor.com/project/nvborisenko/logger-net-serilog)
[![NuGet Badge](https://buildstats.info/nuget/reportportal.serilog)](https://www.nuget.org/packages/reportportal.serilog)

# Installation
Install **ReportPortal.Serilog** NuGet package into your project with tests.

> PS> Install-Package ReportPortal.Serilog

# How to use
Add ReportPortal sink to logger.

```csharp
using ReportPortal.Serilog;
using Serilog;

...
Log.Logger = new LoggerConfiguration().WriteTo.ReportPortal().CreateLogger();
...
```

And use logger to write log messages.
```csharp
Log.Information("My log message");
```
