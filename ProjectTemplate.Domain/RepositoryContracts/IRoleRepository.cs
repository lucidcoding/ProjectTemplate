using System;
using ProjectTemplate.Domain.Common;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Domain.RepositoryContracts
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
        Role GetByName(string roleName);
    }
}
