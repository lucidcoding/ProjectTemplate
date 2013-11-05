using System.ServiceModel;
using ProjectTemplate.Domain.Common;

namespace ProjectTemplate.WCF.Common.ErrorHandling
{
    public class ValidationFaultException : FaultException<ValidationFault>
    {
        public ValidationFaultException(ValidationMessageCollection messages) : base(new ValidationFault(messages), "A validation error occured.")
        { }
    }
}
