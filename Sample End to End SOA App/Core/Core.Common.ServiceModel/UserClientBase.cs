using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

namespace Core.Common.ServiceModel
{
    public abstract class UserClientBase<T> : InterceptorClientBase<T> where T : class
    {
        public UserClientBase()
        {
        }

        protected override void PreInvoke(ref Message request)
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;

            HeaderContext<string> context = new HeaderContext<string>(userName);
            MessageHeader<HeaderContext<string>> genericHeader = new MessageHeader<HeaderContext<string>>(context);
            request.Headers.Add(genericHeader.GetUntypedHeader(HeaderContext<string>.TypeName, HeaderContext<string>.TypeNamespace));
        }
    }
}
