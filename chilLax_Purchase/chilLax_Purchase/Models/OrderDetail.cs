using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace chilLax_Purchase.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }
    [DisplayName("購買數量")]
    public int CartProductQuantity { get; set; }
}
