using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Web.Core
{
    public interface IServiceAwareController
    {
        void RegisterDisposableServices(List<IDisposable> disposableServices);

        List<IDisposable> DisposableServices { get; }
    }
}
