using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Core.Common.ServiceModel
{
    [DataContract]
    public class HeaderContext<T>
    {
        public HeaderContext(T value)
        {
            Value = value;
        }

        [DataMember]
        public readonly T Value;

        internal static string TypeName;
        internal static string TypeNamespace;

        static HeaderContext()
        {
            TypeName = typeof(T).ToString().Replace("`", "");
            TypeName = TypeName.Replace("[", "");
            TypeName = TypeName.Replace("]", "");
            TypeNamespace = typeof(T).Namespace ?? "";
        }

        public static HeaderContext<T> Current
        {
            get
            {
                OperationContext context = OperationContext.Current;
                if (context == null)
                    return null;

                string typeName = typeof(T).ToString();
                string namespaceName = typeof(T).Namespace ?? "";

                try
                {
                    return context.IncomingMessageHeaders.GetHeader<HeaderContext<T>>(typeName, namespaceName);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                OperationContext context = OperationContext.Current;

                string typeName = typeof(T).ToString();
                string namespaceName = typeof(T).Namespace ?? "";
                
                MessageHeader<HeaderContext<T>> genericHeader = new MessageHeader<HeaderContext<T>>(value);
                context.OutgoingMessageHeaders.Add(genericHeader.GetUntypedHeader(typeName, namespaceName));
            }
        }
    }
}
