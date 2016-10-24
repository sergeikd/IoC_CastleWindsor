using Oxagile.Internal.IoC.Entities;
using System.Data.Entity;

namespace Oxagile.Internal.IoC.DALCF
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }
}