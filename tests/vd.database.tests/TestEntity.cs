using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vd.database.Entity;

namespace vd.database.tests
{
    public class TestEntity:BaseEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID {get;set;}

        public string Property1{get;set;}

        public string Property2{get;set;}

        public string Property3{get;set;}
    }
}