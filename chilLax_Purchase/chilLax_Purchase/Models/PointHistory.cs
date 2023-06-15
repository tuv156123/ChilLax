using System;
using System.Collections.Generic;

namespace chilLax_Purchase.Models;

public partial class PointHistory
{
    public int PointDetailId { get; set; }

    public int MemberId { get; set; }

    public string ModifiedSource { get; set; } = null!;

    public int ModifiedAmount { get; set; }
}
