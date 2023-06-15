using System;
using System.Collections.Generic;

namespace chilLax_Purchase.Models;

public partial class Announcement
{
    public int AnnouncementId { get; set; }

    public string Announcement1 { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int BonusForFocus { get; set; }

    public int BonusForShopping { get; set; }
}
