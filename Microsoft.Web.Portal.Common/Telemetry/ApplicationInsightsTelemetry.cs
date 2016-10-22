//------------------------------------------------------------------------------
// <copyright file="ApplicationInsightsTelemetry.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by ashirs, keithmg Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Implementing the Applications insights telemtry.
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.Web.Portal.Common.Telemetry
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using ApplicationInsights;
    using OfficeDevPortals.Shared.Telemetry;

    /// <summary>
    /// ApplicationInsightsTelemetry main class
    /// </summary>
    public class ApplicationInsightsTelemetry : ITelemetry
    {
        /// <summary>
        /// Azure Application insight telemetry client
        /// </summary>
        private TelemetryClient _telemetryClient = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationInsightsTelemetry" /> class.
        /// </summary>
        public ApplicationInsightsTelemetry()
        {
            _telemetryClient = new TelemetryClient();
        }

        /// <summary>
        /// Send an EventTelemetry for display in Diagnostic Search and aggregation in Metrics Explorer.
        /// </summary>
        /// <param name="eventName">A name for the event.</param>
        /// <param name="properties">Named string values you can use to search and classify events.</param>
        /// <param name="metrics">Measurements associated with this event.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Default not required here")]
        public void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            Contract.Requires(!string.IsNullOrEmpty(eventName));
            _telemetryClient.TrackEvent(eventName, properties, metrics);
        }

        /// <summary>
        /// Send a MetricTelemetry for aggregation in Metric Explorer.
        /// </summary>
        /// <param name="name">Metric name.</param>
        /// <param name="value">Metric value.</param>
        /// <param name="properties">Named string values you can use to classify and filter metrics.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Defaults not applicable in this case")]
        public void TrackMetric(string name, double value, IDictionary<string, string> properties = null)
        {
            Contract.Requires(!string.IsNullOrEmpty(name));
            _telemetryClient.TrackMetric(name, value, properties);
        }

        /// <summary>
        /// Send a trace message for display in Diagnostic Search.
        /// </summary>
        /// <param name="message">Message to display.</param>
        /// <param name="properties">Named string values you can use to search and classify events.</param>
        public void TrackTrace(string message, IDictionary<string, string> properties)
        {
            Contract.Requires(!string.IsNullOrEmpty(message));
            Contract.Requires(properties != null);
            _telemetryClient.TrackTrace(message, properties);
        }

        /// <summary>
        /// Send a trace message for display in Diagnostic Search.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public void TrackTrace(string message)
        {
            Contract.Requires(!string.IsNullOrEmpty(message));
            _telemetryClient.TrackTrace(message);
        }

        /// <summary>
        /// Send an Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry for display in Diagnostic Search.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="properties">Named string values you can use to classify and search for this exception.</param>
        /// <param name="metrics">Additional values associated with this exception.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Default not required here")]
        public void TrackException(Exception exception, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            _telemetryClient.TrackException(exception, properties, metrics);
        }

        /// <summary>
        /// Send information about the page viewed in the application.
        /// </summary>
        /// <param name="pageName">Name of the page.</param>
        public void TrackPageView(string pageName)
        {
            Contract.Requires(!string.IsNullOrEmpty(pageName));
            _telemetryClient.TrackPageView(pageName);
        }
    }
}
