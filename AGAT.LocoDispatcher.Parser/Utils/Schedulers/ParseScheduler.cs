using AGAT.LocoDispatcher.Parser.Jobs;
using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Schedulers
{
    public class ParseScheduler
    {
        public static void Start(string path, string errorPath)
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<ParseJob>().UsingJobData("path", path).UsingJobData("errorPath", errorPath).Build();

            ITrigger trigger = TriggerBuilder.Create()  // создаем триггер
                .WithIdentity("trigger1", "group1")     // идентифицируем триггер с именем и группой
                
                .StartNow()                            // запуск сразу после начала выполнения
                .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(20)
                .RepeatForever()
                    )                   // бесконечное повторение
                .Build();                               // создаем триггер

            scheduler.ScheduleJob(job, trigger);        // начинаем выполнение работы
        }
    }
}