﻿//------------------------------------------------------------------------------
// <copyright file="ITelemetry.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by patrickp Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Interface definition for the Telemetry Service
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.OfficeDevPortals.Shared.Telemetry
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for Portals Telemetry objects
    /// </summary>
    public interface ITelemetry
    {
        /// <summary> 
        /// Send an EventTelemetry for display in Diagnostic Search and aggregation in Metrics Explorer.
        /// </summary>
        /// <param name="eventName">A name for the event.</param>
        /// <param name="properties">Named string values you can use to search and classify events.</param>
        /// <param name="metrics">Measurements associated with this event.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Null is ok as default param for interface")]
        void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);

        /// <summary>
        /// Send a MetricTelemetry for aggregation in Metric Explorer.
        /// </summary>
        /// <param name="name">Metric name.</param>
        /// <param name="value">Metric value.</param>
        /// <param name="properties">Named string values you can use to classify and filter metrics.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        void TrackMetric(string name, double value, IDictionary<string, string> properties = null);

        /// <summary>
        /// Send a trace message for display in Diagnostic Search.
        /// </summary>
        /// <param name="message">Message to display.</param>
        void TrackTrace(string message);

        /// <summary>
        /// Send a trace message for display in Diagnostic Search.
        /// </summary>
        /// <param name="message">Message to display.</param>
        /// <param name="properties">Named string values you can use to search and classify events.</param>
        void TrackTrace(string message, IDictionary<string, string> properties);

        /// <summary>
        /// Send an Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry for display in Diagnostic Search.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="properties">Named string values you can use to classify and search for this exception.</param>
        /// <param name="metrics">Additional values associated with this exception.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Null is ok as default param for interface")]
        void TrackException(Exception exception, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);

        /// <summary>
        /// Send information about the page viewed in the application.
        /// </summary>
        /// <param name="pageName">Name of the page.</param>
        void TrackPageView(string pageName);
    }
}
