namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberCredential")]
    public partial class MemberCredential
    {
        [Key]
        public int member_id { get; set; }

        [Required]
        [StringLength(50)]
        public string member_account { get; set; }

        [Required]
        [StringLength(50)]
        public string member_password { get; set; }

        public virtual Member Member { get; set; }
    }
}
