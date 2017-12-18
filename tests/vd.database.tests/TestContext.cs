using Microsoft.EntityFrameworkCore;

namespace vd.database.tests
{
    public class TestContext:DbContext
    {
        public DbSet<TestEntity> TestEntities {get;set;}

        public TestContext(DbContextOptions<TestContext> options):base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.EnableSensitiveDataLogging();    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestEntity>().HasKey(x=>new{ x.ID} );
        }

    }
}