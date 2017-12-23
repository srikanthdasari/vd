using System;
using Microsoft.Extensions.DependencyInjection;  
using Microsoft.Extensions.Logging;
using vd.import.lib.core;
using vd.import.lib.log;
using vd.import.lib.Interface;
using System.Collections;
using System.Collections.Generic;
using vd.import.lib.constants;
using vd.core.extensions;

namespace vd.import
{
    public class Program
    {
        static void Main(string[] args)
        {
            SetupContiner();

            ISpecification<TaskContext> cleanTaskSpec=new Specification<TaskContext>(o=>o.State==ProcessState.Clean);
            ISpecification<TaskContext> downloadTaskSpec=new Specification<TaskContext>(o=>o.State==ProcessState.Download);
            ISpecification<TaskContext> importDataTaskSpec=new Specification<TaskContext>(o=>o.State==ProcessState.Import);
            ISpecification<TaskContext> unzipTaskSpec=new Specification<TaskContext>(o=>o.State==ProcessState.Unzip);
            
            IHandler<TaskContext> cleanTaskHanlder=new TaskHandler<TaskContext>(cleanTaskSpec, new TaskContext(new CleanTask()));
            IHandler<TaskContext> downloadTaskHandler=new TaskHandler<TaskContext>(downloadTaskSpec, new TaskContext(new DownloadTask()));
            IHandler<TaskContext> importDataTaskHandler=new TaskHandler<TaskContext>(importDataTaskSpec, new TaskContext(new UnzipTask()));
            IHandler<TaskContext> unzipTaskHandler=new TaskHandler<TaskContext>(unzipTaskSpec,new TaskContext(new UnzipTask()));

            downloadTaskHandler.SetSuccessor(unzipTaskHandler);
            unzipTaskHandler.SetSuccessor(cleanTaskHanlder);

           
            IHandler<TaskContext> sequence=downloadTaskHandler;
            while(sequence.IsNotNull())
            {
                ((TaskHandler<TaskContext>)sequence).HandleRequest();
                sequence=sequence.GetSuccessor();
            }
        }

        public static void SetupContiner()
        {
            var provider=new ServiceCollection()
                                    .AddLogging()
                                    .AddScoped<IHandler<TaskContext>,TaskHandler<TaskContext>>()                                    
                                    .BuildServiceProvider();

            var logger = provider.GetService<ILoggerFactory>()
            .CreateLogger<Program>();

            //call ConfigureLogger in a centralized place in the code
	        ApplicationLogger.ConfigureLogger(provider.GetService<ILoggerFactory>());
	        //set it as the primary LoggerFactory to use everywhere
	        ApplicationLogger.LoggerFactory = provider.GetService<ILoggerFactory>();
	        //other code removed

        }
    }
}
