using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vd.core;

namespace vd.database.Entity
{
    
    [Table("submissions")]
    public class submission:BaseEntity
    {
        [StringLength(20)]
        [FeedOrder(0)]
        public string adsh { get; set; }

        [FeedOrder(1)]
        public decimal cik { get; set; }

        [Required]
        [StringLength(150)]
        [FeedOrder(2)]
        public string name { get; set; }

        [FeedOrder(3)]
        public decimal? sic { get; set; }

        
        [StringLength(2)]
        [FeedOrder(4)]
        public string countryba { get; set; }

        [FeedOrder(5)]
        [StringLength(2)]
        public string stprba { get; set; }

        [StringLength(30)]
        [FeedOrder(6)]
        public string cityba { get; set; }

        [StringLength(10)]
        [FeedOrder(7)]
        public string zipba { get; set; }

        [StringLength(40)]
        [FeedOrder(8)]
        public string bas1 { get; set; }

        [StringLength(40)]
        [FeedOrder(9)]
        public string bas2 { get; set; }

        [StringLength(12)]
        [FeedOrder(10)]
        public string baph { get; set; }

        [StringLength(2)]
        [FeedOrder(11)]
        public string countryma { get; set; }

        [StringLength(2)]
        [FeedOrder(12)]
        public string stprma { get; set; }

        [StringLength(30)]
        [FeedOrder(13)]
        public string cityma { get; set; }

        [StringLength(10)]
        [FeedOrder(14)]
        public string zipma { get; set; }

        [StringLength(40)]
        [FeedOrder(15)]
        public string mas1 { get; set; }

        [StringLength(40)]
        [FeedOrder(16)]
        public string mas2 { get; set; }

        [StringLength(3)]
        [FeedOrder(17)]
        public string countryinc { get; set; }

        [StringLength(2)]
        [FeedOrder(18)]
        public string stprinc { get; set; }

        [FeedOrder(19)]
        public decimal? ein { get; set; }

        [StringLength(150)]
        [FeedOrder(20)]
        public string former { get; set; }

        [StringLength(8)]
        [FeedOrder(21)]
        public string changed { get; set; }

        [StringLength(5)]
        [FeedOrder(22)]
        public string afs { get; set; }

        [FeedOrder(23,typeof(bool))]
        public bool wksi { get; set; }

        
        [StringLength(4)]
        [FeedOrder(24)]
        public string fye { get; set; }

        [Required]
        [StringLength(10)]
        [FeedOrder(25)]
        public string form { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [FeedOrder(26,typeof(DateTime))]
        public DateTime period { get; set; }

        [Required]
        [Column(TypeName = "year")]
        [FeedOrder(27)]
        public short fy { get; set; }

        [Required]
        [StringLength(2)]
        [FeedOrder(28)]
        public string fp { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [FeedOrder(29,typeof(DateTime))]
        public DateTime filed { get; set; }

        [Required]
        [FeedOrder(30)]
        public DateTime accepted { get; set; }

        [Required]
        [FeedOrder(31,typeof(bool))]
        public bool prevrpt { get; set; }

        [Required]
        [FeedOrder(32,typeof(bool))]
        public bool detail { get; set; }


        [Required]
        [StringLength(32)]
        [FeedOrder(33)]
        public string instance { get; set; }

        [Required]
        [StringLength(4)]
        [FeedOrder(34)]
        public string nciks { get; set; }

        
        [StringLength(120)]
        [FeedOrder(35)]
        public string aciks { get; set; }

        
    }
}