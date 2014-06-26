using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarRental.Web.Core
{
    public class ViewControllerBase : Controller
    {
        List<IDisposable> _DisposableServices;

        protected virtual void RegisterServices(List<IDisposable> disposableServices)
        {
        }

        List<IDisposable> DisposableServices
        {
            get
            {
                if (_DisposableServices == null)
                    _DisposableServices = new List<IDisposable>();

                return _DisposableServices;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            RegisterServices(DisposableServices);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            foreach (var service in DisposableServices)
            {
                if (service != null)
                    service.Dispose();
            }
        }
    }
}
