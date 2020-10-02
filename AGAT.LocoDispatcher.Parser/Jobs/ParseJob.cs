using AGAT.LocoDispatcher.Parser.Utils;
using Quartz;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Parser.Jobs
{
    public class ParseJob : IJob
    {
        private DriveOperator _drive;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public ParseJob()
        {
            _drive = new DriveOperator();
        }
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                JobDataMap dataMap = context.JobDetail.JobDataMap;
                string path = dataMap.GetString("path");
                if (string.IsNullOrEmpty(path?.Trim()))
                {
                    throw new ArgumentNullException("PATH IS NOT VALID");
                }
                _drive.GetFilesFromDirectoryAndParse(path);
            }
            catch (Exception ex)
            {
                logger.Error($"ERROR {ex.InnerException?.Message}");
                logger.Error($"{DateTime.Now} | ERROR SOURCE | {ex.Source}");
                logger.Error($"{DateTime.Now} | ERROR METHOD | {ex.TargetSite}");
                logger.Error($"{DateTime.Now} | ERROR | {ex.Message}");
            }
        }
    }
}