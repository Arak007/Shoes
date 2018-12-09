namespace Assignment_1_Shoes_200364251.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public brand()
        {
            types = new HashSet<type>();
        }

        [Display(Name = "Brand ID")]
        public int brandId { get; set; }

        [StringLength(50)]
        [Display(Name = "Brand Name")]
        public string brName { get; set; }

        [StringLength(100)]
        [Display(Name = "Brand Descrption")]
        public string brDesc { get; set; }

        [StringLength(100)]
        [Display(Name = "Brand Founder")]
        public string brFounder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<type> types { get; set; }

        public static explicit operator brand(ViewResult v)
        {
            throw new NotImplementedException();
        }
    }
}
