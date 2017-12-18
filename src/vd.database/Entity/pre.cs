using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace vd.database.Entity
{
    [Table("pre")]
    public partial class pre:BaseEntity
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string adsh { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal report { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal line { get; set; }

        [Required]
        [StringLength(2)]
        public string stmt { get; set; }

        public bool inpth { get; set; }

        [Required]
        [StringLength(1)]
        public string rfile { get; set; }

        [Required]
        [StringLength(256)]
        public string tag { get; set; }

        [Required]
        [StringLength(20)]
        public string version { get; set; }

        [Required]
        [StringLength(512)]
        public string plabel { get; set; }
    }
}