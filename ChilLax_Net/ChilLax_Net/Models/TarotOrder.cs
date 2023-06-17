namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TarotOrder")]
    public partial class TarotOrder
    {
        [Key]
        public int tarot_order_id { get; set; }

        public int member_id { get; set; }

        [Required]
        [StringLength(50)]
        public string card_result { get; set; }

        [Required]
        public string divination_chat { get; set; }

        public DateTime tarot_time { get; set; }

        public virtual Member Member { get; set; }
    }
}
