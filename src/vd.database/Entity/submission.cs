using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vd.database.Entity
{
    
    [Table("submissions")]
    public class submission:BaseEntity
    {
        [Key]
        [StringLength(20)]
        public string adsh { get; set; }

        public decimal cik { get; set; }

        [Required]
        [StringLength(150)]
        public string name { get; set; }

        public decimal? sic { get; set; }

        [Required]
        [StringLength(2)]
        public string countryba { get; set; }

        [StringLength(2)]
        public string stprba { get; set; }

        [StringLength(30)]
        public string cityba { get; set; }

        [StringLength(10)]
        public string zipba { get; set; }

        [StringLength(40)]
        public string bas1 { get; set; }

        [StringLength(40)]
        public string bas2 { get; set; }

        [StringLength(12)]
        public string baph { get; set; }

        [StringLength(2)]
        public string countryma { get; set; }

        [StringLength(2)]
        public string stprma { get; set; }

        [StringLength(30)]
        public string cityma { get; set; }

        [StringLength(10)]
        public string zipma { get; set; }

        [StringLength(40)]
        public string mas1 { get; set; }

        [StringLength(40)]
        public string mas2 { get; set; }

        [StringLength(3)]
        public string countryinc { get; set; }

        [StringLength(2)]
        public string stprinc { get; set; }

        public decimal? ein { get; set; }

        [StringLength(150)]
        public string former { get; set; }

        [StringLength(8)]
        public string changed { get; set; }

        [StringLength(5)]
        public string afs { get; set; }

        public bool wksi { get; set; }

        [Required]
        [StringLength(4)]
        public string fye { get; set; }

        [Required]
        [StringLength(10)]
        public string form { get; set; }

        [Column(TypeName = "date")]
        public DateTime period { get; set; }

        [Column(TypeName = "year")]
        public short fy { get; set; }

        [Required]
        [StringLength(2)]
        public string fp { get; set; }

        [Column(TypeName = "date")]
        public DateTime filed { get; set; }

        public DateTime accepted { get; set; }

        public bool prevrpt { get; set; }

        public bool detail { get; set; }

        [Required]
        [StringLength(32)]
        public string instance { get; set; }

        [Required]
        [StringLength(4)]
        public string nciks { get; set; }

        [Required]
        [StringLength(120)]
        public string aciks { get; set; }
    }
}