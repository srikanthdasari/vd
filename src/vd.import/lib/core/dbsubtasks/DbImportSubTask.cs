using vd.core.extensions;
using vd.database;
using vd.import.lib.constants;

namespace vd.import.lib.core.dbsubtasks
{
    /*public class DbImportSubTask
    {
        public DbImportSubTask(VDContext _context)
        {
            this.Feed = feed;
            this.context = _context;

        }
        protected FeedDataSet Feed { get; set; }

        public VDContext context { get; set; }

        protected DbImportSubTask next;

        public DbImportSubTask SetNext(DbImportSubTask nextDbSubtasker)
        {
            next = nextDbSubtasker;
            return nextDbSubtasker;
        }

        public void Import(object obj, FeedDataSet _feed)
        {
            if (Feed == _feed)
            {
                ImportToDb(obj);
            }
            if (next.IsNotNull())
            {
                next.Import(obj, _feed);
            }
        }

        protected virtual void ImportToDb(object obj)
        {

        }
    }*/
}