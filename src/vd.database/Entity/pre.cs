using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vd.core;

namespace vd.database.Entity
{
    [Table("pre")]
    public partial class pre:BaseEntity
    {
        [Column(Order = 0)]
        [StringLength(20)]
        [FeedOrder(0)]
        public string adsh { get; set; }

        [Column(Order = 1)]
        [FeedOrder(1)]
        public decimal report { get; set; }

        [Column(Order = 2)]
        [FeedOrder(2)]
        public decimal line { get; set; }

        [Required]
        [StringLength(2)]
        [FeedOrder(3)]
        public string stmt { get; set; }

        [Required]
        [FeedOrder(4,typeof(bool))]
        public bool inpth { get; set; }

        [Required]
        [StringLength(1)]
        [FeedOrder(5)]
        public string rfile { get; set; }

        [Required]
        [StringLength(256)]
        [FeedOrder(6)]
        public string tag { get; set; }

        [Required]
        [StringLength(20)]
        [FeedOrder(7)]
        public string version { get; set; }

        //[Required]
        [StringLength(512)]
        [FeedOrder(8)]
        public string plabel { get; set; }


        [StringLength(45)]
        [FeedOrder(9)]
        public string negating {get;set;}        
  
    }
}