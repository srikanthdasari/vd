using System;
using vd.import.lib.Interface;

namespace vd.import.lib.core
{
    public class UnzipTask:ITask
    {
        public void PerformTask()
        {
            Console.WriteLine("** Performing Unzip Task");
        }
    }
}