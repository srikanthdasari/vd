using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace vd.database.Entity
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id {get;set;}


        public string CreatedBy {get;set;} ="feed";

        public string ModifiedBy{get;set;} = "feed";


        public DateTime CreatedDate {get;set;} = DateTime.Now;

        public DateTime ModifiedDate {get;set;} = DateTime.Now; 

    }
}