using System;
using ProjectTemplate.Application.Requests;
using ProjectTemplate.Domain.Common;

namespace ProjectTemplate.Application.Contracts
{
    public interface IUserService
    {
        void EnsureExists(string userName);
    }
}
