namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FocusSlide")]
    public partial class FocusSlide
    {
        [Key]
        public int focus_id { get; set; }

        [Required]
        [StringLength(100)]
        public string category { get; set; }

        [Required]
        public string image_path { get; set; }

        [Required]
        public string audio_path { get; set; }
    }
}
