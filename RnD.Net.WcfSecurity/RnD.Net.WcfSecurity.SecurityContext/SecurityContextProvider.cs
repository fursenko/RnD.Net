
namespace RnD.Net.WcfSecurity.SecurityContext
{
    using Contracts;
    using System.ServiceModel;
    using System.Text;

    public class SecurityContextProvider : IDroneManager
    {
        public string GetInfo()
        {
            var infoBuilder = new StringBuilder();
            infoBuilder.AppendFormat("Uri: {0}", OperationContext.Current.EndpointDispatcher.EndpointAddress.Uri.ToString());
            infoBuilder.AppendFormat("Session Id: {0}", OperationContext.Current.SessionId);

            var securityContext = OperationContext.Current.ServiceSecurityContext;

            if (securityContext == null)
                infoBuilder.AppendLine("ServiceSecurityContext is null");
            else if (securityContext.IsAnonymous)
                infoBuilder.AppendLine("ServiceSecurityContext is anonymous");
            else
            {
                infoBuilder.AppendFormat("PrimaryIdentity name: {0}", securityContext.PrimaryIdentity.Name);
                infoBuilder.AppendFormat("PrimaryIdentity.AuthenticationType: {0}", securityContext.PrimaryIdentity.AuthenticationType);
                infoBuilder.AppendFormat("AccountDomainSid: {0}", securityContext.WindowsIdentity.User.AccountDomainSid);
            }

            return infoBuilder.ToString();
        }

        public void KillSelf()
        {
            OperationContext.Current.Host.Close();
        }

        public string Ping()
        {
            return "securty context";
        }
    }
}
