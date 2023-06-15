using System;
using System.Collections.Generic;

namespace chilLax_Purchase.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string SupplierTel { get; set; } = null!;

    public string SupplierAddress { get; set; } = null!;
}
