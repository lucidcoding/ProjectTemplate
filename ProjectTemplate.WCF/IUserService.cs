using System;
using System.ServiceModel;
using ProjectTemplate.Application.Requests;
using ProjectTemplate.Domain.Common;
using ProjectTemplate.WCF.DataTransferObjects;

namespace ProjectTemplate.WCF
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        UserDto GetByUsername(string username);

        [OperationContract]
        UserDto GetById(Guid id);

        [OperationContract]
        UserDto[] GetAll();
    }
}
