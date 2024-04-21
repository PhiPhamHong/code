using System.ServiceModel;
using System.ServiceModel.Channels;
namespace Core.Utility.WcfManager
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class ServiceBase
    {
        protected string GetIp()
        {
            var props = OperationContext.Current.IncomingMessageProperties;
            var endpointProperty = props[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return endpointProperty != null ? endpointProperty.Address : string.Empty;
        }
    }
}
