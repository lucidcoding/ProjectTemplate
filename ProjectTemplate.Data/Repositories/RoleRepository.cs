using System;
using NHibernate;
using ProjectTemplate.Data.Common;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.RepositoryContracts;

namespace ProjectTemplate.Data.Repositories
{
    public class RoleRepository : Repository<Role, Guid>, IRoleRepository
    {
        public RoleRepository(ISessionFactory sessionFactory) :
            base(sessionFactory)
        {
        }

        public Role GetByName(string roleName)
        {
            var role = Session.CreateQuery(
                "select role " +
                "from Role as role " +
                "where role.RoleName = :roleName ")
                .SetString("roleName", roleName)
                .UniqueResult<Role>();

            return role;
        }
    }
}
