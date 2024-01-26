using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Serilog
{
    public class SeriLogger
    {
        public IConfiguration Configuration { get; }
        private readonly AppSettings _appSettings;
        public SeriLogger(IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            Configuration = configuration;
            _appSettings = appSettings.Value;
        }


        public void LogRequest(string message, bool isError, string directory)
        {
            var options = $"{_appSettings.FileLogPath}\\{directory}\\events.log";
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.File(
               options,
                outputTemplate: "{Timestamp:o} [{Level:u3}] ({SourceContext}) {Message}{NewLine}{Exception}",
                fileSizeLimitBytes: 1_000_000,
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1))
            .CreateLogger();

            if (isError)
            {
                Log.Logger.Error(message);
            }
            else
            {
                Log.Logger.Information(message);
            }
        }


    }

}
