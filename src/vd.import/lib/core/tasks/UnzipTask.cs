using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using vd.core;
using vd.import.lib.constants;
using vd.import.lib.Interface;

namespace vd.import.lib.core.tasks
{
    public class UnzipTask:ITask
    {
        public void TaskImplementation()
        {
            var localTemp=string.Empty;
            
            localTemp=StaticUtilities.GetDataPath();

            ZipFile.ExtractToDirectory(localTemp+"\\"+CurrentSessionParams.LocalDirName+"\\"+CurrentSessionParams.FileName+".zip",localTemp+"\\"+CurrentSessionParams.LocalDirName,true);
        }
    }
}