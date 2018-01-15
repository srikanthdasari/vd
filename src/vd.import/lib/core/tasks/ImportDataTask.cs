using System;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using vd.core;
using vd.database;
using vd.import.lib.constants;
using vd.import.lib.core.dbsubtasks;
using vd.import.lib.Interface;

namespace vd.import.lib.core.tasks
{
    public class ImportDataTask : ITask
    {

        #region  Properties & Fields
        public NumImportSubTask NumHandler;
        public PreImportSubTask PreHandler;
        public SubImportSubTask SubHandler;
        public TagImportSubtask TagHandler;
        public VDContext context;
        #endregion


        public ImportDataTask(VDContext _context,NumImportSubTask num,PreImportSubTask pre, SubImportSubTask sub, TagImportSubtask tag)
        {
            context=_context;            
            NumHandler=num;
            PreHandler=pre;
            SubHandler=sub;
            TagHandler=tag;
        }
        public void TaskImplementation()
        {
            var observableQuery=(from n in  CurrentSessionParams.FilesToExtract select n.Key).ToObservable();

            observableQuery.Subscribe(OnProcessing,onError:OnError,onCompleted:OnFinished);     
        }

        public void OnProcessing(FeedDataSet Feed)
        {
            var localTemp=StaticUtilities.GetDataPath();

            if (File.Exists(localTemp))
            {
                    //var observableCharactersSeq=Observable.Using<char,StreamReader>(()=>new StreamReader(new FileStream(localTemp,FileMode.Open)),
                    //                    s=>(from c in s.ReadToEnd().ToCharArray() select c).ToObservable(NewThreadScheduler.Default));

                    if(FeedDataSet.TAG==Feed)
                    File.ReadLines(localTemp)
                        .ToObservable()
                        .ObserveOn(Scheduler.Default)
                        .Subscribe(l=>OnLineProcessing(l,CurrentSessionParams.FilesToExtract[Feed]));
            }
            else
            {
                Console.WriteLine("path Not Found");
            }            
        }

        public void OnFinished()
        {

        }

        public void OnError(Exception ex)
        {

        }

        public void OnLineProcessing(string line, string filename)
        {
            
        }
    }
}