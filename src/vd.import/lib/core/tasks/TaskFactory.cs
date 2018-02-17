using vd.core.extensions;
using vd.import.lib.constants;
using vd.import.lib.Interface;

namespace vd.import.lib.core.tasks
{
    public class TaskFactory : ITaskFactory
    {
        /*public ITask CreateTask(ProcessState State) 
        {
            if (State.IsNull())
            {
                throw new System.ArgumentNullException(nameof(State));
            }

            switch (State)
            {
                case ProcessState.Clean : return new CleanTask();
                case ProcessState.Download : return new DownloadTask();
                case ProcessState.Import: return new ImportDataTask(new DbImportSubTask(FeedDataSet.NUM));
                case ProcessState.Unzip: return new UnzipTask();
            }

            return null;
        }*/
    }
}