using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using vd.database;
using vd.import.lib.constants;
using vd.import.lib.core;
using vd.import.lib.core.dbsubtasks;
using vd.import.lib.core.tasks;
using vd.import.lib.Interface;

namespace vd.import
{
    public class AppRunner:IAppRunner
    {

        #region Constructor
        public AppRunner(IServiceCollection serviceCollection)
        {
            ConfigureServices(serviceCollection);
            Services = serviceCollection.BuildServiceProvider();
            Logger = Services.GetRequiredService<ILoggerFactory>().CreateLogger<AppRunner>();            
        }

        #endregion

        public IServiceProvider Services { get; set; }
        public ILogger Logger { get; set; }


        #region Properties      

        ITask CleanTask { get; set; }
        ITask DownloadTask { get; set; }
        ITask ImportDataTask { get; set; }
        ITask UnzipTask { get; set; }
        TaskStrategy TaskStrategy {get;set;} 
        Queue<IProcess> TaskQueue {get;set;}

        IProcess Process {get;set;}
        IProcess AsyncProcess {get;set;}
        #endregion

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
             serviceCollection.AddScoped<IProcess,Processable>()
                              .AddSingleton<VDContext>()
                              .AddScoped<ITask,CleanTask>()
                              .AddScoped<ITask,DownloadTask>()
                              .AddScoped<ITask,UnzipTask>()
                              .AddScoped<ITask,ImportDataTask>()
                              .AddSingleton<CleanTask>()
                              .AddSingleton<DownloadTask>()
                              .AddSingleton<ImportDataTask>()
                              .AddSingleton<UnzipTask>()
                              .AddScoped<NumImportSubTask>()
                              .AddScoped<PreImportSubTask>()
                              .AddScoped<SubImportSubTask>()
                              .AddScoped<TagImportSubtask>()
                              .AddSingleton(new LoggerFactory().AddConsole())
                              .AddSingleton<TaskStrategy>()
                              //.AddSingleton<ITaskFactory,TaskFactory>()
                              .AddSingleton(f=>{
                                    Func<ProcessState,ITask> accessor = key=>
                                    {
                                        switch(key)
                                        {
                                            case ProcessState.Clean: return f.GetService<CleanTask>();
                                            case ProcessState.Download :return f.GetService<DownloadTask>();
                                            case ProcessState.Import: return f.GetService<ImportDataTask>();
                                            case ProcessState.Unzip: return f.GetService<UnzipTask>();
                                            default: throw new KeyNotFoundException();
                                        }    
                                    };      
                                    return accessor;                           
                              })
                              .AddLogging();
                              

        }

        public void Run()
        {
            //TaskQueue=Services.GetService<Queue<IProcess>>();
            TaskQueue=new Queue<IProcess>();
            TaskStrategy=Services.GetService<TaskStrategy>();    
            var serviceAccessor=Services.GetService<Func<ProcessState,ITask>>();
            CleanTask=serviceAccessor(ProcessState.Clean);
            DownloadTask=serviceAccessor(ProcessState.Download);
            UnzipTask=serviceAccessor(ProcessState.Unzip);
            ImportDataTask=serviceAccessor(ProcessState.Import);
            
            TaskQueue.Enqueue(new Processable(()=>TaskStrategy.ChangeStrategy(CleanTask).PerformTask()));
            TaskQueue.Enqueue(new Processable(()=>TaskStrategy.ChangeStrategy(DownloadTask).PerformTask()));
            TaskQueue.Enqueue(new Processable(()=>TaskStrategy.ChangeStrategy(UnzipTask).PerformTask()));
            TaskQueue.Enqueue(new Processable(()=>TaskStrategy.ChangeStrategy(ImportDataTask).PerformTask()));

            while(TaskQueue.Count>0)
                TaskQueue.Dequeue().Process();
        }
    }
}