using AGAT.LocoDispatcher.Parser.Utils;
using Quartz;
using System;

namespace AGAT.LocoDispatcher.Parser.Jobs
{
    public class ParseJob : IJob
    {
        private DriveOperator _drive;
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
                _drive.GetFilesFromDirectoryAndParseAsync(path).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}