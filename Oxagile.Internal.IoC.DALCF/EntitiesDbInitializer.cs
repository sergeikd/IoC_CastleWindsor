using System.Collections.Generic;
using System.Data.Entity;
using Oxagile.Internal.IoC.Entities;

namespace Oxagile.Internal.IoC.DALCF
{
    public class EntitiesDbInitializer : DropCreateDatabaseAlways<AppContext>
    {
        protected override void Seed(AppContext db)
        {
            var company1 = new Company {Name = "CompanyName1"};
            var company2 = new Company {Name = "CompanyName2"};
            var company3 = new Company {Name = "CompanyName3"};
            db.Companies.AddRange(new List<Company> {company1, company2, company3});
            db.SaveChanges();

            var user1 = new User {Name = "UserName1", CompanyId = null};
            var user2 = new User {Name = "UserName2", CompanyId = 1};
            var user3 = new User {Name = "UserName3", CompanyId = 2};
            var user4 = new User {Name = "UserName4", CompanyId = 2};
            var user5 = new User {Name = "UserName5", CompanyId = 3};
            var user6 = new User {Name = "UserName6", CompanyId = 3};
            db.Users.AddRange(new List<User> {user1, user2, user3, user4, user5, user6});
            db.SaveChanges();
        }
    }
}