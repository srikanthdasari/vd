using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vd.core;

namespace vd.database.Entity
{
    [Table("num")]
    public partial class num:BaseEntity
    {

        [Column(Order = 0)]
        [StringLength(20)]
        [FeedOrder(0)]
        public string adsh { get; set; }

        [Column(Order = 1)]
        [StringLength(256)]
        [FeedOrder(1)]
        public string tag { get; set; }

        [Column(Order = 2)]
        [StringLength(20)]
        [FeedOrder(2)]
        public string version { get; set; }

        [Column(Order = 3)]
        [StringLength(256)]
        [FeedOrder(3)]
        public string coreg { get; set; }

        [Column(Order = 4, TypeName = "date")]
        [FeedOrder(4,typeof(DateTime))]
        public DateTime ddate { get; set; }

        [Column(Order = 5)]
        [FeedOrder(5)]
        public decimal qtrs { get; set; }

        [Column(Order = 6)]
        [StringLength(20)]
        [FeedOrder(6)]
        public string uom { get; set; }

        [FeedOrder(7)]
        public double? value { get; set; }

        [FeedOrder(8)]
        [StringLength(512)]
        public string footnote { get; set; }

 
    }
}