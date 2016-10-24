using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using Castle.MicroKernel;

namespace Oxagile.Internal.IoC.WindsorResolver
{
    public class WindsorActionInvoker : ControllerActionInvoker
    {
        private readonly DbContext _dbContext;

        public WindsorActionInvoker(IKernel kernel)
        {
            _dbContext = kernel.Resolve<DbContext>();
        }

        protected override ActionResult InvokeActionMethod(ControllerContext controllerContext,
            ActionDescriptor actionDescriptor,
            IDictionary<string, object> parameters)
        {
            var actionResult = base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);
            _dbContext.SaveChanges();
            return actionResult;
        }
    }
}