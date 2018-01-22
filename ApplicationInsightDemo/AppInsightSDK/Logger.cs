namespace AppInsightSDK
{
    using System;
    using Microsoft.ApplicationInsights;
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.ApplicationInsights.Extensibility;
 
    /// <summary>
    /// Class for logging
    /// </summary>
    public static class Logger
    {
        static TelemetryClient telemetryClient = null;

        /// <summary>
        /// Initializes the <see cref="Logger"/> class.
        /// </summary>
        static Logger()
        {
            TelemetryConfiguration.Active.InstrumentationKey = "Instrumentation Key";
            telemetryClient = new TelemetryClient();
        }

        /// <summary>
        /// Tracks the information.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void TrackInfo(string message)
        {
            telemetryClient.TrackTrace(message, SeverityLevel.Information);
            telemetryClient.Flush();
        }

        /// <summary>
        /// Tracks the warning.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void TrackWarning(string message)
        {
            telemetryClient.TrackTrace(message, SeverityLevel.Warning);
            telemetryClient.Flush();
        }

        /// <summary>
        /// Tracks the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void TrackException(Exception exception)
        {
            telemetryClient.TrackException(exception);
            telemetryClient.Flush();
        }
    }
}
