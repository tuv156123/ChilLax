using System;
using System.Collections.Generic;

namespace chilLax_Purchase.Models;

public partial class PurchaseDetail
{
    public int PurchaseId { get; set; }

    public int ProductId { get; set; }

    public int PurchaseQuantity { get; set; }

    public int PurchasePrice { get; set; }
}
