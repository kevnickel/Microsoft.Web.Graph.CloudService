//------------------------------------------------------------------------------
// <copyright file="SharedEnums.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by keithmg Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Class contianing shared enums for the project
// </summary>
//------------------------------------------------------------------------------
namespace Microsoft.OfficeDevPortals.Shared.Enums
{
    /// <summary>
    /// Log Level Enum
    /// </summary>
    public static class SharedEnums
    {
        /// <summary>
        /// Log level enumeration
        /// </summary>
        public enum LogLevel
        {
            /// <summary>
            /// Debugging logging level
            /// </summary>
            Debug,

            /// <summary>
            /// Information logging level
            /// </summary>
            Information,

            /// <summary>
            /// Warning logging level
            /// </summary>
            Warning,

            /// <summary>
            /// Error logging level
            /// </summary>
            Error,

            /// <summary>
            /// Fatal logging level
            /// </summary>
            Fatal
        }

    }
}
