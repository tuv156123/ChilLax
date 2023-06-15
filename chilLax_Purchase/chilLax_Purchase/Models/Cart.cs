using System;
using System.Collections.Generic;

namespace chilLax_Purchase.Models;

public partial class Cart
{
    public int MemberId { get; set; }

    public int ProductId { get; set; }

    public int CartProductQuantity { get; set; }
}
