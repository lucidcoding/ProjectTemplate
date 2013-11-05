using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace ProjectTemplate.WCF.Common.Logging
{
    public class RequestLoggingDispatchMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            string logCode = null;

            try
            {
                //Work out how to do something more useful here.
                //logCode = Log.Add(request.Headers.Action);
            }
            catch { }

            return logCode;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            //SessionProvider.CloseSession();
        }
    }
}
