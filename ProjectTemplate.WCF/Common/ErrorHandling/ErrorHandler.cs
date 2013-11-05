using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using StructureMap;

namespace ProjectTemplate.WCF.Common.ErrorHandling
{
    public class ErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            try
            {
                //SessionProvider.CloseSession();
            }
            catch { }

            return false;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error.GetType() != typeof(ValidationFaultException))
            {
                //var log = ObjectFactory.GetInstance<ILog>();
                //string errorCode = log.Add(error);
                //FaultException faultException = new FaultException<ApplicationFault>(new ApplicationFault(errorCode),
                //    "An application error occured with error code: " + errorCode);
                //MessageFault messageFault = faultException.CreateMessageFault();
                //fault = Message.CreateMessage(version, messageFault, faultException.Action);
            }
        }
    }
}
