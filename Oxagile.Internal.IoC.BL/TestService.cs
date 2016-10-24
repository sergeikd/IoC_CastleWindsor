using System;
using System.Collections.Generic;
using System.Linq;
using Oxagile.Internal.IoC.DALCF;
using Oxagile.Internal.IoC.Entities;
using Oxagile.Internal.IoC.Notification;

namespace Oxagile.Internal.IoC.BL
{
    public class TestService : ITestService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICollection<INotificator> _notificators;
        private readonly IUserRepository _userRepository;

        public TestService(IUserRepository userRepository, ICompanyRepository companyRepository,
            ICollection<INotificator> notificators)
        {
            if (userRepository == null)
                throw new ArgumentNullException(nameof(userRepository));
            _userRepository = userRepository;

            if (companyRepository == null)
                throw new ArgumentNullException(nameof(companyRepository));
            _companyRepository = companyRepository;

            _notificators = notificators;
        }

        public IList<Company> GetAllCompanies()
        {
            return _companyRepository.GetAll().ToList();
        }

        public IList<User> GetAllUsers()
        {
            var users = _userRepository.GetAll(c => c.Company).ToList();
            return users;
        }

        public Company GetCompanyById(int id)
        {
            return _companyRepository.GetSingle(c => c.Id == id);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetSingle(u => u.Id.Equals(id));
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public void AddCompany(Company company)
        {
            _companyRepository.Add(company);
        }

        public void SendNotification(ICollection<int> identifiers, string message)
        {
            foreach (var notificator in _notificators)
            {
                notificator.SendNotification(identifiers, message);
            }
        }
    }
}