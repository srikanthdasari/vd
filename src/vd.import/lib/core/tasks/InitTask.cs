using System;
using Microsoft.Extensions.Logging;
using vd.database;
using vd.database.Entity;
using vd.import.lib.Interface;

namespace vd.import.lib.core.tasks
{
    public class InitTask : ITask
    {
        private readonly ILogger<InitTask> _logger;

        public InitTask(ILogger<InitTask> logger)
        {
            _logger=logger;
        }
        public void TaskImplementation()
        {
            _logger.LogDebug("** Performaing Initiization");
        }
    }
}