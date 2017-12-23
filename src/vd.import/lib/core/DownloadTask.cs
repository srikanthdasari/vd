using System;
using vd.import.lib.Interface;

namespace vd.import.lib.core
{
    public class DownloadTask:ITask
    {   
        public void PerformTask()
        {
                Console.WriteLine("** Performing Download Task");
        }
    }
}