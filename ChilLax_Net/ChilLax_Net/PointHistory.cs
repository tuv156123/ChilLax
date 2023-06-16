namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PointHistory")]
    public partial class PointHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int point_detail_id { get; set; }

        public int member_id { get; set; }

        [Required]
        [StringLength(50)]
        public string modified_source { get; set; }

        public int modified_amount { get; set; }

        public virtual Member Member { get; set; }
    }
}
