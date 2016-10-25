//------------------------------------------------------------------------------
// <copyright file="BlobManaer.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by jnlxu Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Static methods for retrieving content from blob storage
// </summary>
//------------------------------------------------------------------------------

using System;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Web.Portal.Common.Storage
{
    /// <summary>
    /// Read content from an Azure blob
    /// </summary>
    public class BlobManager
    {
        private const string DefaultCulture = "en-us";

        /// <summary>
        /// Read the content using the path specified
        /// </summary>
        /// <param name="connectString">The connection string for blob storage</param>
        /// <param name="container">The container to read from</param>
        /// <param name="path">The path to the file to read</param>
        /// <returns>The contents of the specified blob</returns>
        public static string ReadContent(string connectString, string container, string path)
        {
            return ReadContentInternal(connectString, container, path);
        }

        /// <summary>
        /// Read the content using the localized path specified
        /// </summary>
        /// <param name="connectString">The connection string for blob storage</param>
        /// <param name="containter">The container to read from</param>
        /// <param name="culture">The culture to look under for the file</param>
        /// <param name="path">The path to the file to read under the localized folder</param>
        /// <returns>The contents of the specified blob</returns>
        public static string ReadContent(string connectString, string containter, string culture, string path)
        {
            culture = culture.ToLower();
            string result = ReadContentInternal(connectString, containter, culture + "/" + path);
            if(result==null&&(!DefaultCulture.Equals(culture)))
            {
                result = ReadContentInternal(connectString, containter, DefaultCulture + "/" + path);
            }
            return result;
        }

        /// <summary>
        /// Read the content using the path specified
        /// </summary>
        /// <param name="connectString">The connection string for blob storage</param>
        /// <param name="containerName">The container to read from</param>
        /// <param name="path">The path to the file to read</param>
        /// <returns>The contents of the specified blob</returns>
        private static string ReadContentInternal(string connectString, string containerName, string path)
        {
            string returnVal = string.Empty;

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            CloudBlockBlob blob = container.GetBlockBlobReference(path);
            using (Stream stream = blob.OpenRead())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    returnVal = reader.ReadToEnd();
                }
            }

            return returnVal;
        }
    }
}