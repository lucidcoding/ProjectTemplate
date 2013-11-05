using System;
using ProjectTemplate.Domain.Common;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Domain.RepositoryContracts
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        User GetByUsername(string userName);
    }
}

