namespace Microsoft.Web.Graph.WebRole
{
    using System.Web;
    using System.Web.Mvc;

    public class ValidateFrontDoorCertificateAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Verify if the client is authorized
        /// </summary>
        /// <returns>True if the client is authorized; false otherwise</returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            base.AuthorizeCore(httpContext);
            return FrontDoorCertValidator.Validate(httpContext.Request.ClientCertificate);
        }
    }
}