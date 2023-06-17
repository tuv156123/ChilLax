namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        public int emp_id { get; set; }

        public bool emp_permission { get; set; }

        [Required]
        [StringLength(50)]
        public string emp_name { get; set; }

        [Required]
        [StringLength(50)]
        public string emp_account { get; set; }

        [Required]
        [StringLength(50)]
        public string emp_password { get; set; }
    }
}
