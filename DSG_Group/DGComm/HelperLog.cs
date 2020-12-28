using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.DGComm
{
    public class HelperLog
    {
        public static void Error(object message)
        {
            //log4net.LogManager.GetLogger("HelperLog").Error(message);
            HelperLogWrete.Error(message);
        }

        public static void Error<T>(object message)
        {
            //log4net.LogManager.GetLogger(typeof(T)).Error(message);
            HelperLogWrete.Error(message);
        }

        public static void Error(object message, Exception exception)
        {
            //log4net.LogManager.GetLogger("HelperLog").Error(message,exception);
            HelperLogWrete.Error(message, exception);
        }

        public static void Error<T>(object message, Exception exception)
        {
            //log4net.LogManager.GetLogger(typeof(T)).Error(message, exception);
            HelperLogWrete.Error<T>(message, exception);
        }
    }
}
