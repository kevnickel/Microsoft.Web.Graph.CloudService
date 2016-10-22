//------------------------------------------------------------------------------
// <copyright file="Environment.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by patrickp Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Environment class for handling web.config etc 
// </summary>
//------------------------------------------------------------------------------
namespace Microsoft.Web.Portal.Common
{
    using System;
    using Microsoft.Web.Portal.Common.Logging;
    using OfficeDevPortals.Shared.Logging;
    using static OfficeDevPortals.Shared.Enums.SharedEnums;

    /// <summary>
    /// Class representing Runt time environment configuration
    /// </summary>
    public class Environment
    {
        /// <summary>
        /// logger class set to null by default
        /// </summary>
        private static Logger _logger = null;

        /// <summary>
        /// supported culture
        /// </summary>
        private string _supportedCultures;

        /// <summary>
        /// default culture
        /// </summary>
        private string _defaultCulture;

        /// <summary>
        /// Application Name
        /// </summary>
        private string _applicationName;

        /// <summary>
        /// Gets the supported culture
        /// </summary>
        public string SupportedCultures
        {
            get
            {
                if (_supportedCultures == null)
                {
                    _supportedCultures = GetValue("Microsoft.Web.Portal.SupportedCulture", "[/-]en-us/?");
                }

                return _supportedCultures;
            }
        }

        /// <summary>
        /// Gets the default culture
        /// </summary>
        public string DefaultCulture
        {
            get
            {
                if (_defaultCulture == null)
                {
                    _defaultCulture = GetValue("Microsoft.Web.Portal.DefaultCulture", "en-us");
                }

                return _defaultCulture;
            }
        }

        /// <summary>
        /// Gets Name for currently running application
        /// </summary>
        public string ApplicationName
        {
            get
            {
                if (_applicationName == null)
                {
                    _applicationName = GetValue("Microsoft.Web.Portal.Common.Environment.ApplicationName", "Warning.Applicaiton.Name.Missing");
                }

                return _applicationName;
            }
        }

        /// <summary>
        /// Utility method that reads the web/app config file and gets the value for the specified key
        /// if that key not found, ti returns the default value stated for  that key
        /// </summary>
        /// <param name="key">web config key</param>
        /// <param name="anyDefaultValue">default is an empty string</param>
        /// <returns>key from web app config</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "No specific error required until we have logging compent defined")]
        private static string GetValue(string key, string anyDefaultValue = "")
        {
            string result = anyDefaultValue; // Default Value
            // to be very safe, because if sth goes wrong
            try
            {
                result = System.Configuration.ConfigurationManager.AppSettings[key];
                if (result == null)
                {
                    result = anyDefaultValue; //// Default Value
                }
            }
            catch (Exception ex)
            {
                //// note to keithmg REDIS LOGGER CLASS.
                if (_logger == null)
                {
                    _logger = new Logger();
                }

                _logger.Log(LogLevel.Error, ex.Message);
               result = anyDefaultValue; //// Default Value
            }

            return result;
        }
    }
}