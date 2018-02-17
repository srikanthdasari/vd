using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using vd.import.lib.Interface;

namespace vd.import.lib.core.tasks
{
    public class CleanTask : ITask
    {
        private readonly ILogger<CleanTask> _logger;

        public CleanTask(ILogger<CleanTask> logger)
        {
            _logger=logger;
        }

        public void TaskImplementation()
        {
            _logger.LogDebug("** Performing Clean Task");
        }
    }
}