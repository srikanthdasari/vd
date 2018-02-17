
using System.Collections.Generic;
using vd.database;

namespace vd.import.lib.constants
{
    public static class CurrentSessionParams
    {
        public static string FileName {get;set;}

        public static string LocalDirName ="Data";

        public static IDictionary<FeedDataSet,string> FilesToExtract =new Dictionary<FeedDataSet, string>{

            {FeedDataSet.NUM,"num.txt"}, {FeedDataSet.PRE,"pre.txt"},{FeedDataSet.TAG,"tag.txt"},{FeedDataSet.SUB,"sub.txt"}
        };

        public static VDContext Context {get;set;}
    }
}