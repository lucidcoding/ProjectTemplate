using System;
using System.ServiceModel;
using ProjectTemplate.Application.Requests;
using ProjectTemplate.Domain.Common;
using ProjectTemplate.WCF.DataTransferObjects;

namespace ProjectTemplate.WCF
{
    [ServiceContract]
    public interface ITaskService
    {
        [OperationContract]
        TaskDto[] GetAll();
        
        [OperationContract]
        TaskDto GetById(Guid id);
        
        [OperationContract]
        ValidationMessageCollection ValidateRaise(RaiseTaskRequest request);
        
        [OperationContract]
        Guid Raise(RaiseTaskRequest request);
    }
}
