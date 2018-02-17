using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vd.core;

namespace vd.database.Entity
{
    [Table("tags")]
    public partial class tag:BaseEntity
    {
        [Column("tag", Order = 0)]
        [StringLength(256)]
        [FeedOrder(0)]
        public string tag1 { get; set; }

        [Column(Order = 1)]
        [StringLength(20)]
        [FeedOrder(1)]
        public string version { get; set; }

        [FeedOrder(2,typeof(bool))]
        public bool? custom { get; set; }

        [Column("abstract")]
        [FeedOrder(3,typeof(bool))]
        public bool? _abstract { get; set; }

        [StringLength(20)]
        [FeedOrder(4)]
        public string datatype { get; set; }

        [StringLength(1)]
        [FeedOrder(5)]
        public string iord { get; set; }

        [StringLength(1)]
        [FeedOrder(6)]
        public string crdr { get; set; }

        [StringLength(512)]
        [FeedOrder(7)]
        public string tlabel { get; set; }

        [StringLength(2048)]
        [FeedOrder(8)]
        public string doc { get; set; }

    }
}