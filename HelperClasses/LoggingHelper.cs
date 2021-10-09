using PathfinderAI.PathfindingAlgorithms;
using Serilog;
using Serilog.Core;
using System.IO;

namespace PathfinderAI.HelperClasses
{
    public class LoggingHelper
    {
        public static Logger Logger = null;
        private const string logsFileName = ConstantsHelper.LogFileName;

        public static void InitializeLogger()
        {
            if (!File.Exists(logsFileName))
                File.Create(logsFileName);
            
            if(Logger == null)
            {
                Logger = new LoggerConfiguration()
                   .WriteTo.File(logsFileName)
                   .CreateLogger();
            }
        }
    }
}
