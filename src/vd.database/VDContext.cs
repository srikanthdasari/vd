using vd.database.Entity;
using Microsoft.EntityFrameworkCore;

namespace vd.database
{
    public class VDContext:DbContext
    {

         public virtual DbSet<num> nums { get; set; }
         public virtual DbSet<pre> pres { get; set; }
         public virtual DbSet<submission> submissions { get; set; }
         public virtual DbSet<tag> tags { get; set; }


        //find the better way to handle this properly..
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                                 =>optionsBuilder.UseMySql(@"server=localhost;port=3306;user=root;password=P@$$w0rd123;database=valuedashboard;persistsecurityinfo=True");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<num>().HasKey(x=>new{ x.adsh,  x.tag,x.version,x.coreg, x.ddate, x.qtrs, x.uom} );

            modelBuilder.Entity<num>()
                .Property(e => e.adsh)
                .IsUnicode(false);

            modelBuilder.Entity<num>()
                .Property(e => e.tag)
                .IsUnicode(false);

            modelBuilder.Entity<num>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<num>()
                .Property(e => e.coreg)
                .IsUnicode(false);

            modelBuilder.Entity<num>()
                .Property(e => e.uom)
                .IsUnicode(false);

            modelBuilder.Entity<num>()
                .Property(e => e.footnote)
                .IsUnicode(false);

            modelBuilder.Entity<num>().HasKey(x=>new{ x.adsh,  x.tag,x.version,x.coreg, x.ddate, x.qtrs, x.uom} );

            modelBuilder.Entity<pre>()
                .Property(e => e.adsh)
                .IsUnicode(false);

            modelBuilder.Entity<pre>()
                .Property(e => e.stmt)
                .IsUnicode(false);

            modelBuilder.Entity<pre>()
                .Property(e => e.rfile)
                .IsUnicode(false);

            modelBuilder.Entity<pre>()
                .Property(e => e.tag)
                .IsUnicode(false);

            modelBuilder.Entity<pre>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<pre>()
                .Property(e => e.plabel)
                .IsUnicode(false);

            modelBuilder.Entity<pre>().HasKey(x=>new{x.adsh, x.report, x.line });

            modelBuilder.Entity<submission>()
                .Property(e => e.adsh)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.countryba)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.stprba)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.cityba)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.zipba)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.bas1)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.bas2)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.baph)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.countryma)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.stprma)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.cityma)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.zipma)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.mas1)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.mas2)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.countryinc)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.stprinc)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.former)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.changed)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.afs)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.fye)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.form)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.fp)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.instance)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.nciks)
                .IsUnicode(false);

            modelBuilder.Entity<submission>()
                .Property(e => e.aciks)
                .IsUnicode(false);

            modelBuilder.Entity<tag>()
                .Property(e => e.tag1)
                .IsUnicode(false);

            modelBuilder.Entity<tag>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<tag>()
                .Property(e => e.datatype)
                .IsUnicode(false);

            modelBuilder.Entity<tag>()
                .Property(e => e.iord)
                .IsUnicode(false);

            modelBuilder.Entity<tag>()
                .Property(e => e.crdr)
                .IsUnicode(false);

            modelBuilder.Entity<tag>()
                .Property(e => e.tlabel)
                .IsUnicode(false);

            modelBuilder.Entity<tag>()
                .Property(e => e.doc)
                .IsUnicode(false);

            modelBuilder.Entity<tag>().HasKey(x=>new{x.tag1,x.version});
        }
        
    }
}