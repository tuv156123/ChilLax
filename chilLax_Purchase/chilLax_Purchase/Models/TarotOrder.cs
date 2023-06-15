using System;
using System.Collections.Generic;

namespace chilLax_Purchase.Models;

public partial class TarotOrder
{
    public int TarotOrderId { get; set; }

    public int MemberId { get; set; }

    public string CardResult { get; set; } = null!;

    public string DivinationChat { get; set; } = null!;

    public DateTime TarotTime { get; set; }
}
