using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vd.database.Entity
{
    [Table("tags")]
    public partial class tag:BaseEntity
    {
        [Key]
        [Column("tag", Order = 0)]
        [StringLength(256)]
        public string tag1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string version { get; set; }

        public bool? custom { get; set; }

        [Column("abstract")]
        public bool? _abstract { get; set; }

        [StringLength(20)]
        public string datatype { get; set; }

        [StringLength(1)]
        public string iord { get; set; }

        [StringLength(1)]
        public string crdr { get; set; }

        [StringLength(512)]
        public string tlabel { get; set; }

        [StringLength(2048)]
        public string doc { get; set; }
    }
}