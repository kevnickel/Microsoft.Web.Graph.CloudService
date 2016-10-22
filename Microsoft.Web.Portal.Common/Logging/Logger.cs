//------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by patrickp Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Logger.cs file. TODO STUB IN REAL LOGGING CODE
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.Web.Portal.Common.Logging
{
    using System.Diagnostics.Contracts;
    using OfficeDevPortals.Shared.Logging;
    using static OfficeDevPortals.Shared.Enums.SharedEnums;

    /// <summary>
    /// Logger implementation using log4net
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Logger" /> class.
        /// Constructor, Stubbed with no implementation. 
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "name", Justification = "This method will be implemented in the future")]
        public Logger()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger" /> class.
        /// Constructor, Stubbed with no implementation. 
        /// </summary>
        /// <param name="name">name of the logger component</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "name", Justification = "This method will be implemented in the future")]
        public Logger(string name)
        {
        }

        /// <summary>
        /// Log method for loosely coupling loggers
        /// </summary>
        /// <param name="logLevel">log level</param>
        /// <param name="message">message to log</param>
        public void Log(LogLevel logLevel, string message)
        {
            Contract.Requires(!string.IsNullOrEmpty(message));

            ////TODO LOGGING CODE
        }
    }
}
