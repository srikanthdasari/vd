using System;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using vd.core;
using vd.core.extensions;
using vd.database;
using vd.database.Entity;
using vd.import.lib.constants;
using vd.import.lib.Interface;

namespace vd.import.lib.core.tasks
{
    public class ImportDataTask : ITask
    {

        #region  Properties & Fields

        IRepository<pre> PreRepository;
        IRepository<num> NumRepository;
        IRepository<submission> SubRepository;
        IRepository<tag> TagRepository;
        public VDContext context;

        private readonly ILogger<ImportDataTask> _logger;

        #endregion

        public ImportDataTask(VDContext _context,
                              IRepository<pre> prerepository,
                              IRepository<num> numrepository, 
                              IRepository<submission> subrepository, 
                              IRepository<tag> tagrepository, ILogger<ImportDataTask> logger)
        {
            context=_context;            

            PreRepository=prerepository;
            NumRepository=numrepository;
            SubRepository=subrepository;
            TagRepository=tagrepository;
            _logger=logger;

        }
        public void TaskImplementation()
        {
            var observableQuery=(from n in  CurrentSessionParams.FilesToExtract select n.Key).ToObservable();

            observableQuery.Subscribe(OnProcessing,onError:OnError,onCompleted:OnFinished);     
        }

        public void OnProcessing(FeedDataSet Feed)
        {
            var localTemp=StaticUtilities.GetDataPath() +"\\"+CurrentSessionParams.LocalDirName+"\\"+CurrentSessionParams.FilesToExtract[Feed];

            if (File.Exists(localTemp))
            {
                    //var observableCharactersSeq=Observable.Using<char,StreamReader>(()=>new StreamReader(new FileStream(localTemp,FileMode.Open)),
                    //                    s=>(from c in s.ReadToEnd().ToCharArray() select c).ToObservable(NewThreadScheduler.Default));

                    if(FeedDataSet.SUB==Feed)  //this needs to be removed later
                    File.ReadLines(localTemp)
                        .Skip(1)
                        .ToObservable()
                        .ObserveOn(Scheduler.Default)
                        .Subscribe(l=>OnLineProcessing(l,Feed),onError:OnError,onCompleted:OnImportFinished);
            }
            else
            {
                Console.WriteLine("path Not Found");

            }            
        }

        public void OnFinished()
        {
            _logger.LogInformation("Import finished");
        }

        public void OnImportFinished()
        {
            TagRepository.SaveChanges();
            _logger.LogInformation("Changes were saved to database");
        }

        public void OnError(Exception ex)
        {
            Console.WriteLine("***Exception********");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }

        public void OnLineProcessing(string line, FeedDataSet Feed)
        {
            try
            {
                //TagHandler.DoImport(Feed,obj);
                switch(Feed)
                {
                    case FeedDataSet.TAG:  TagRepository.Add(line.MapString<tag>(),context.tags); break;
                    case FeedDataSet.SUB: 
                    {
                        var sub=line.MapString<submission>();
                        if(sub.IsNotNull() && !context.submissions.Any(x=>x.adsh==sub.adsh))
                            SubRepository.Add(sub,context.submissions);
                        break;
                    }
                    case FeedDataSet.PRE:
                    {
                        PreRepository.Add(line.MapString<pre>(),context.pres); break;
                    }
                    case FeedDataSet.NUM:
                    {
                        NumRepository.Add(line.MapString<num>(),context.nums); break;
                    }
                        
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("***Exception********");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }            
        }

    }
}