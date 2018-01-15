using System;
using vd.import.lib.Interface;

namespace vd.import.lib.core.tasks
{
    public class InitTask : ITask
    {
        public void TaskImplementation()
        {
            Console.WriteLine("** Performaing Initiization");
        }
    }
}