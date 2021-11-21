using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Common
{
    public static class NLogService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void PrintInfoLog(string str)
        {
            logger.Info(str);
        }
    }
}
