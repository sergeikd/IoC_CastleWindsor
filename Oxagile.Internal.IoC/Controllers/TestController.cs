using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Logging;
using Oxagile.Internal.IoC.BL;
using Oxagile.Internal.IoC.Entities;
using Oxagile.Internal.IoC.ViewModels;

namespace Oxagile.Internal.IoC.Controllers
{
    public class TestController : BaseController
    {
        private ITestService _service;
       
        public TestController(ITestService testService)
        {
            if (testService == null)
            {
                throw new ArgumentNullException(nameof(testService));
            }
            _service = testService;
        }

        public ILogger Logger { get; set; } = NullLogger.Instance;

        public ActionResult Index()
        {
            var users = TestService.GetAllUsers();
            var companies = TestService.GetAllCompanies();
            var user = TestService.GetUserById(users[0].Id);
            var company = TestService.GetCompanyById(companies.ToList()[0].Id);
            var listNotification = new List<int>();

            var listUserView = users.Select(item => new UserViewModel
            {
                UserName = item.Name,
                UserId = item.Id,
                CompanyName = (item.Company == null) ? "NaN" : item.Company.Name
            }).ToList();

            TestService.SendNotification(users.Select(x => x.Id).ToList(), "Hello everybody!");
            Logger.DebugFormat("Logger was here");
            return View(listUserView);
        }
        public ActionResult Companies()
        {
            return View(TestService.GetAllCompanies());
        }

        [HttpPost]
        [HandleError()]
        public ActionResult Companies(IEnumerable<Company> companies )
        {
            foreach (var company in companies)
            {
                TestService.AddCompany(company);
            }
            return RedirectToAction("Companies");
        }
    }
}