using System;
using vd.import.lib.Interface;

namespace vd.import.lib.core
{
    public class CleanTask : ITask
    {
        public void PerformTask()
        {
            Console.WriteLine("** Performing Clean Task");
        }
    }
}