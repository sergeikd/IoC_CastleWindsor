using Oxagile.Internal.IoC.Entities;
using System.Data.Entity;

namespace Oxagile.Internal.IoC.DALCF
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }
}