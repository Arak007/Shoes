namespace Assignment_1_Shoes_200364251.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("type")]
    public partial class type
    {
        [Key]
        [Display(Name = "Collection ID")]
        public int moId { get; set; }

        [StringLength(150)]
        [Display(Name = "Model Name")]
        public string moName { get; set; }

        [StringLength(200)]
        [Display(Name = "Model Desription")]
        public string moDesc { get; set; }

        [StringLength(100)]
        [Display(Name = "Colors Available")]
        public string moColours { get; set; }

        public int brandId { get; set; }

        public virtual brand brand { get; set; }
    }
}
