using System;
using System.Linq;
using ProjectTemplate.Application.Requests;
using ProjectTemplate.Domain.Common;
using ProjectTemplate.WCF.Common.ErrorHandling;
using ProjectTemplate.WCF.Common.SessionHandling;
using ProjectTemplate.WCF.DataTransferObjects;
using ProjectTemplate.WCF.Mappers;
using StructureMap;

namespace ProjectTemplate.WCF
{
    [ErrorHandingBehavior]
    [SessionClosingBehaviour]
    public class UserService : IUserService
    {
        private readonly Application.Contracts.IUserService _userService;

        public UserService()
        {
            _userService = ObjectFactory.GetInstance<Application.Contracts.IUserService>();
        }

        public UserService(Application.Contracts.IUserService userService)
        {
            _userService = userService;
        }

        public UserDto GetByUsername(string username)
        {
            throw new NotImplementedException();
            //return UserDtoMapper.Map(_userService.GetByUsername(username));
        }

        public UserDto GetById(Guid id)
        {
            throw new NotImplementedException();
            //return UserDtoMapper.Map(_userService.GetById(id));
        }

        public UserDto[] GetAll()
        {
            throw new NotImplementedException();
            //return UserDtoMapper.Map(_userService.GetAll()).ToArray();
        }
    }
}
