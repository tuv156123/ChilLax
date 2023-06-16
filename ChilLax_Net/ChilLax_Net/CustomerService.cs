namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerService")]
    public partial class CustomerService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customer_service_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int member_ID { get; set; }

        [Required]
        public string message { get; set; }

        [Required]
        public string reply { get; set; }

        public DateTime message_datetime { get; set; }

        public DateTime reply_datetime { get; set; }

        public virtual Member Member { get; set; }
    }
}
