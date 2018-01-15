using vd.database;
using vd.import.lib.constants;

namespace vd.import.lib.core.dbsubtasks
{
    public class PreImportSubTask : ImportHandler
    {
        public override void DoImport(FeedDataSet feed)
        {
           
        }

        public bool CanExecute(FeedDataSet feed)
        {
            return (FeedDataSet.PRE==feed);
        }
    }
}