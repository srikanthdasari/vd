using System;
using vd.import.lib.Interface;

namespace vd.import.lib.core
{
    public class ImportDataTask : ITask
    {
        public void PerformTask()
        {
            Console.WriteLine("** Performing Import Data Task");
        }
    }
}