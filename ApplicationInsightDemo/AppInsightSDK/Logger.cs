using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System;

namespace AppInsightSDK
{
    public static class Logger
    {
        static TelemetryClient telemetryClient = null;
        static Logger()
        {
            TelemetryConfiguration.Active.InstrumentationKey = "Instrumentation Key";
            telemetryClient = new TelemetryClient();
        }

        public static void TrackInfo(string message)
        {
            telemetryClient.TrackTrace(message, SeverityLevel.Information);
            telemetryClient.Flush();
        }
        
        public static void TrackWarning(string message)
        {
            telemetryClient.TrackTrace(message, SeverityLevel.Warning);
            telemetryClient.Flush();
        }

        public static void TrackException(Exception exception)
        {
            telemetryClient.TrackException(exception);
            telemetryClient.Flush();
        }
    }
}
