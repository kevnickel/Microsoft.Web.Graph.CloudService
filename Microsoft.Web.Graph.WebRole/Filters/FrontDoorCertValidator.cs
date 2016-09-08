namespace Microsoft.Web.Graph.WebRole.Filters
{
    using System;
    using System.Configuration;
    using System.Globalization;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Web;

    public class FrontDoorCertValidator
    {
        /// <summary>
        /// The Front Door certificate
        /// </summary>
        private static X509Certificate2 frontDoorCert;

        /// <summary>
        /// Validator entrypoint
        /// </summary>
        /// <param name="cert">Certificate to validate</param>
        /// <returns>True if the certificate was validated; false otherwise</returns>
        public static bool Validate(HttpClientCertificate cert)
        {
            //****** DISABLED UNTIL OSI WORKS
            //if (frontDoorCert == null)
            //{
            //    string frontDoorCertSubject = ConfigurationManager.AppSettings["FrontDoorClientCert"];
            //    frontDoorCert = GetCertificateBySubjectName(frontDoorCertSubject);
            //}

            //if (cert != null && cert.IsPresent)
            //{
            //    try
            //    {
            //        return new X509Certificate2(cert.Certificate).Thumbprint == frontDoorCert.Thumbprint;
            //    }
            //    catch (Exception)
            //    {
            //        // Do your exception logging here
            //    }
            //}

            return true;
        }

        /// <summary>
        /// Gets a certificate from your personal store
        /// </summary>
        /// <param name="subject">The subject of the certificate to locate.</param>
        /// <returns>The certificate</returns>
        private static X509Certificate2 GetCertificateBySubjectName(string subject)
        {
            if (String.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException("subject");
            }

            X509Store store = null;
            try
            {
                store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection myCertCollection = store.Certificates.Find(X509FindType.FindBySubjectName, subject, false);

                if (myCertCollection.Count == 0)
                {
                    var builder = new StringBuilder();
                    foreach (var cert in store.Certificates)
                    {
                        builder.AppendLine(cert.SubjectName.Name);
                    }

                    throw new ArgumentException(
                        string.Format(CultureInfo.CurrentCulture, "Could not locate certificate '{0}' in store. Certs found:\r\n{1}", subject, builder),
                        "subject");
                }

                return myCertCollection[0];
            }
            finally
            {
                store.Close();
            }
        }
    }
}