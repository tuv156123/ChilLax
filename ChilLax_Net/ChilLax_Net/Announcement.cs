namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Announcement")]
    public partial class Announcement
    {
        [Key]
        public int announcement_id { get; set; }

        [Column("announcement")]
        [Required]
        [StringLength(1000)]
        public string announcement1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime end_date { get; set; }

        public int bonus_for_focus { get; set; }

        public int bonus_for_shopping { get; set; }
    }
}
