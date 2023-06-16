namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FocusDetail")]
    public partial class FocusDetail
    {
        [Key]
        public int focus_detail_id { get; set; }

        public DateTime start_datetime { get; set; }

        public DateTime end_datetime { get; set; }

        public int duration { get; set; }
    }
}
