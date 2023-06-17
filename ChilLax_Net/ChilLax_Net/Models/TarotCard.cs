namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TarotCard")]
    public partial class TarotCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tarotCard_id { get; set; }

        [Required]
        [StringLength(50)]
        public string tarotCard_name { get; set; }

        [Required]
        [StringLength(10)]
        public string tarotCard_type { get; set; }
    }
}
