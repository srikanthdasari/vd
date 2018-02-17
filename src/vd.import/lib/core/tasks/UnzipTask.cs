using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using vd.core;
using vd.import.lib.constants;
using vd.import.lib.Interface;

namespace vd.import.lib.core.tasks
{
    public class UnzipTask:ITask
    {

        private readonly ILogger<UnzipTask> _logger;

        public UnzipTask(ILogger<UnzipTask> logger)
        {
            _logger=logger;
        }

        public void TaskImplementation()
        {
            _logger.LogDebug("** Performing unzip task");
            var localTemp=string.Empty;
            
            localTemp=StaticUtilities.GetDataPath();

            ZipFile.ExtractToDirectory(localTemp+"\\"+CurrentSessionParams.LocalDirName+"\\"+CurrentSessionParams.FileName+".zip",localTemp+"\\"+CurrentSessionParams.LocalDirName,true);
        }
    }
}