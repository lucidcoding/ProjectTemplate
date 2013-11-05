using System;
using NHibernate;
using ProjectTemplate.Data.Common;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.RepositoryContracts;

namespace ProjectTemplate.Data.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(ISessionFactory sessionFactory) :
            base(sessionFactory)
        {
        }

        public User GetByUsername(string username)
        {
            var user = Session.CreateQuery(
                "select user " +
                "from User as user " +
                "where user.Username = :username ")
                .SetString("username", username)
                .UniqueResult<User>();

            return user;
        }
    }
}
