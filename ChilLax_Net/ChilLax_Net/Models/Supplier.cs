namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Product = new HashSet<Product>();
            Purchase = new HashSet<Purchase>();
        }

        [Key]
        public int supplier_id { get; set; }

        [Required]
        [StringLength(500)]
        public string supplier_name { get; set; }

        [Required]
        [StringLength(50)]
        public string supplier_tel { get; set; }

        [Required]
        public string supplier_address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
