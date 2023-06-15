using System;
using System.Collections.Generic;

namespace chilLax_Purchase.Models;

public partial class CustomerService
{
    public int CustomerServiceId { get; set; }

    public int MemberId { get; set; }

    public string Message { get; set; } = null!;

    public string Reply { get; set; } = null!;

    public DateTime MessageDatetime { get; set; }

    public DateTime ReplyDatetime { get; set; }
}
