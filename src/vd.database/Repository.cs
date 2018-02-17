using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vd.database.Entity;
using vd.database.Exception;

namespace vd.database
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        //public DbContext _dbContext; 
        public VDContext dbContext; 
        public Repository(VDContext context)
        {
            dbContext=context;
        }
        // public async Task<T> Add(T item, DbSet<T> set)
        // {
        //     return await Add(item,set,true);
        // }

        // public async Task<T> Add(T item, DbSet<T> set,bool saveChanges)
        // {
        //     try
        //     {
        //         await set.AddAsync(item);
        //         //set.Add(item);
        //         // if(saveChanges)
        //         // {
        //         //     await dbContext.SaveChangesAsync();                    
        //         // }
        //     }
        //     catch(System.Exception  ex)
        //     {
        //         Console.WriteLine("The Exception Message :{0}",ex.Message);
        //     }
        //     return item;
        // }



        public void SaveChanges()
        {
            //dbContext.SaveChangesAsync();    
             try
             {
                dbContext.SaveChanges();
             }
             catch(System.Exception ex)
             {
                Console.WriteLine("***Repository Save Data Exception********");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
             }
        }
        
         public  void Add(T item, DbSet<T> set)
         {
             try
             {
                set.Add(item);    
                //Console.WriteLine((item as num).adsh);
                Console.WriteLine(DateTime.Now.ToLongTimeString() +" adding new Object "+item.GetHashCode());
             }
             catch(System.Exception ex)
             {
                Console.WriteLine("***Repository add Data Exception********");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
             }
             //Add(item,set,true);             
             
         }

         public  void Add(T item, DbSet<T> set,bool saveChanges)
         {
        //     try
        //     {
        //          set.Add(item);
        //         //set.Add(item);
        //         if(saveChanges)
        //         {
        //             dbContext.SaveChanges();                    
        //         }
        //     }
        //     catch(System.Exception  ex)
        //     {
        //         Console.WriteLine("The Exception Message :{0}",ex.Message);
        //     }            
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
                await dbContext.SaveChangesAsync();
        }


        public async Task<T> Update(T item)
        {
            return await Update(item,true);
        }

        public async Task<T> Update(T item, bool saveChanges)
        {
            dbContext.Entry(item).State=EntityState.Modified;
            if(saveChanges)
                await dbContext.SaveChangesAsync();
            return item;
        }

    }
}