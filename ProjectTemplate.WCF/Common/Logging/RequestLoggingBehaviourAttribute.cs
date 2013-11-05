using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace ProjectTemplate.WCF.Common.Logging
{
    /// <remarks>
    /// Not yet complete. This would be good, ibecause it would avoid the Log.Add() at the beggining of each operation.
    /// Maybe comine it with error handing behaviour, and perhaps log the return value?
    /// </remarks>
    public class RequestLoggingBehaviourAttribute : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase chanDispBase in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = chanDispBase as ChannelDispatcher;
                if (channelDispatcher == null)
                    continue;

                foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    RequestLoggingDispatchMessageInspector inspector = new RequestLoggingDispatchMessageInspector();
                    endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        { }
    }
}
