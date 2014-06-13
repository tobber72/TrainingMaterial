using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Northwind.WCFContracts.FaultContracts;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]


namespace Northwind.WCFDataService
{
    /// <summary>
    /// 
    /// </summary>
    public class SantizedException
    {

        /// <summary>
        /// 
        /// </summary>
        //Mappers map = new Mappers();


        /// <summary>
        /// 
        /// </summary>
        private static readonly ILog _Log = LogManager.GetLogger("NorthwindServiceLogger");


        /// <summary>
        /// Get FaultException for returning to the service consumer.
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns>FaultException DataContract; otherwise an exception will be thrown.</returns>
        public void RaiseFaultException(Exception ex)
        {
            FaultException<CustomException> custEx = Mapper.MapFault(ex);
            LogException(custEx);
            throw custEx;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custEx"></param>
        public void LogException(FaultException<CustomException> custEx)
        {
            try
            {
                log4net.GlobalContext.Properties["GUID"] = custEx.Code;
                log4net.GlobalContext.Properties["MachineName"] = System.Environment.MachineName;
                log4net.GlobalContext.Properties["svc"] = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                // log4net.GlobalContext.Properties["user"] = GetUserToLog();
                log4net.GlobalContext.Properties["errDtl"] = string.Format("Code: {0}  " + Environment.NewLine + Environment.NewLine +
                    "Message:  {1}" + Environment.NewLine + Environment.NewLine +
                    "StackTraceInfo:  {2}" + Environment.NewLine + Environment.NewLine,
                    custEx.Detail.Code,
                    custEx.Detail.Message,
                    custEx.Detail.StackTraceInfo);

                _Log.Error(custEx);
            }
            finally
            {
                // do nothing.
            }
        }


    }
}
