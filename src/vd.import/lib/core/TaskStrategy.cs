using vd.import.lib.constants;
using vd.import.lib.Interface;

namespace vd.import.lib.core
{
    public class TaskStrategy
    {
        public TaskStrategy(ITask task)
        {
            this.Task = task;            
        }
        public ITask Task { get; set; }

        public void PerformTask()
        {
            this.Task.TaskImplementation();
        }

        public TaskStrategy ChangeStrategy(ITask t)
        {
            this.Task=t;
            return this;
        }
    }
}