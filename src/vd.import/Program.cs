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
using System.Threading.Tasks;
using vd.import.lib.core.tasks;
using vd.import.lib.core.dbsubtasks;

namespace vd.import
{
    public class Program
    {
        static void Main(string[] args)
        {
            //SetupContiner();
            if(args.Length>0)
                CurrentSessionParams.FileName=args[0];
            
            CurrentSessionParams.FileName="2017q4";

            IAppRunner runner=new AppRunner(new ServiceCollection());
            runner.Run();
        }
        
    }
}
