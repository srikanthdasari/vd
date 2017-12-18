using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace vd.database.Entity
{
    [Table("num")]
    public partial class num:BaseEntity
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string adsh { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(256)]
        public string tag { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string version { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(256)]
        public string coreg { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime ddate { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal qtrs { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(20)]
        public string uom { get; set; }

        public double? value { get; set; }

        [StringLength(512)]
        public string footnote { get; set; }
    }
}