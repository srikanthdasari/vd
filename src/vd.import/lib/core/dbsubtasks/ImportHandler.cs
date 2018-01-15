using vd.import.lib.constants;

namespace vd.import.lib.core.dbsubtasks
{
    public abstract class ImportHandler
    {
        protected ImportHandler successor;

        public void SetSuccessor(ImportHandler next)
        {
            this.successor=next;
        }

        public abstract void DoImport(FeedDataSet feed);
        
    }
}