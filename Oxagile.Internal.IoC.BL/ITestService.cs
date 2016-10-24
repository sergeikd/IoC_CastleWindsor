using System.Collections.Generic;
using Oxagile.Internal.IoC.Entities;
using Oxagile.Internal.IoC.Notification;

namespace Oxagile.Internal.IoC.BL
{
    public interface ITestService : INotificator
    {
        IList<Company> GetAllCompanies();
        Company GetCompanyById(int id);

        IList<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void AddCompany(Company company);
    }
}