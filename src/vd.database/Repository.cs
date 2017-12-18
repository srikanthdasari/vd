using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vd.database.Entity;
using vd.database.Exception;

namespace vd.database
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private DbContext _dbContext; 

        public Repository(DbContext context)
        {
            _dbContext=context;
        }
        public async Task<T> Add(T item, DbSet<T> set)
        {
            return await Add(item,set,true);
        }

        public async Task<T> Add(T item, DbSet<T> set,bool saveChanges)
        {
            set.Add(item);
            if(saveChanges)
                await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<T> FindByID(int id, DbSet<T> set)
        {
            T result=await set.FindAsync(id);
            if(result==null)
                throw new ObjectNotFoundException();

            return result;
        }

        public async Task Remove(int id, DbSet<T> set)
        {
            await Remove(id,set,true);
        }

        public async Task Remove(int id, DbSet<T> set, bool saveChanges)
        {
            var item=await FindByID(id,set);
            set.Remove(item);
            if(saveChanges)
                await _dbContext.SaveChangesAsync();
        }


        public async Task<T> Update(T item)
        {
            return await Update(item,true);
        }

        public async Task<T> Update(T item, bool saveChanges)
        {
            _dbContext.Entry(item).State=EntityState.Modified;
            if(saveChanges)
                await _dbContext.SaveChangesAsync();
            return item;
        }

    }
}