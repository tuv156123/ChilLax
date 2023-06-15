using System;
using System.Collections.Generic;

namespace chilLax_Purchase.Models;

public partial class FocusDetail
{
    public int FocusDetailId { get; set; }

    public DateTime StartDatetime { get; set; }

    public DateTime EndDatetime { get; set; }

    public int Duration { get; set; }
}
