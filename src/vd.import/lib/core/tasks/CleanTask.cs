using System;
using System.Threading.Tasks;
using vd.import.lib.Interface;

namespace vd.import.lib.core.tasks
{
    public class CleanTask : ITask
    {
        public void TaskImplementation()
        {
            Console.WriteLine("** Performing Clean Task");
        }
    }
}