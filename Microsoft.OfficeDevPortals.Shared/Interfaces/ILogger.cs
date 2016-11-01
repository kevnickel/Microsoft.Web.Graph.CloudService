//------------------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by patrickp Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Interface definition for the Logging Service
// </summary>
//------------------------------------------------------------------------------
namespace Microsoft.OfficeDevPortals.Shared.Logging
{
    using static Enums.SharedEnums;

    /// <summary>
    /// ILogger Interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the message
        /// </summary>
        /// <param name="logLevel">log level</param>
        /// <param name="value">message to log</param>
        void Log(LogLevel logLevel, string value);
    }
}
