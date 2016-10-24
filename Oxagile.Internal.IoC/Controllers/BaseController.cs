using Oxagile.Internal.IoC.BL;
using System.Web.Mvc;

namespace Oxagile.Internal.IoC.Controllers
{
    public class BaseController : Controller
    {
        public ITestService TestService { get; set; }
    }
}