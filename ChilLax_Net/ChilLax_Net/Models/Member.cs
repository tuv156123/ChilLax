namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Member")]
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            Cart = new HashSet<Cart>();
            CustomerService = new HashSet<CustomerService>();
            ProductOrder = new HashSet<ProductOrder>();
            PointHistory = new HashSet<PointHistory>();
            TarotOrder = new HashSet<TarotOrder>();
        }

        [Key]
        public int member_id { get; set; }

        [Required]
        [StringLength(50)]
        public string member_name { get; set; }

        [Required]
        [StringLength(50)]
        public string member_tel { get; set; }

        [StringLength(100)]
        public string member_address { get; set; }

        [Required]
        [StringLength(50)]
        public string member_email { get; set; }

        [Column(TypeName = "date")]
        public DateTime member_birthday { get; set; }

        public bool? member_sex { get; set; }

        public int? member_point { get; set; }

        public DateTime member_joinTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Cart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerService> CustomerService { get; set; }

        public virtual MemberCredential MemberCredential { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PointHistory> PointHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarotOrder> TarotOrder { get; set; }
    }
}
