
using System.Collections.Generic;

namespace vd.import.lib.constants
{
    public static class CurrentSessionParams
    {
        public static string FileName {get;set;}

        public static string LocalDirName ="Data";

        //public static string[] FilesToExtract={ "num.txt", "pre.txt","tag.txt","sub.txt"};
        //public static string[] FilesToExtract={ "tag.txt","sub.txt"};
        public static IDictionary<FeedDataSet,string> FilesToExtract =new Dictionary<FeedDataSet, string>{

            {FeedDataSet.NUM,"num.txt"}, {FeedDataSet.PRE,"pre.txt"},{FeedDataSet.TAG,"tag.txt"},{FeedDataSet.SUB,"sub.txt"}
        };
    }
}