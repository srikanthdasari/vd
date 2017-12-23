using vd.import.lib.constants;
using vd.import.lib.Interface;

namespace vd.import.lib.core
{
    public class TaskContext
    {
        public ProcessState State {get;set;} 
        public TaskContext(ITask task)
        {
            this.Task = task;

        }
        public ITask Task { get; set; }

        public void PerformTask()
        {
            this.Task.PerformTask();
        }
    }
}