using System;
using System.IO;

namespace vd.core
{
    public static class StaticUtilities
    {
        public static string  GetDataPath()
        {
            var localTemp=string.Empty;
            if (System.Diagnostics.Debugger.IsAttached)
                    localTemp = new Uri(Path.Combine(new string[] { System.AppDomain.CurrentDomain.BaseDirectory, "..\\.." })).AbsolutePath;
            else
                    localTemp = System.AppDomain.CurrentDomain.BaseDirectory;

            return localTemp;
        }

    }
}