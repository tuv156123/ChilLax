using System;
using System.Collections.Generic;

namespace chilLax_Purchase.Models;

public partial class MemberCredential
{
    public int MemberId { get; set; }

    public string MemberAccount { get; set; } = null!;

    public string MemberPassword { get; set; } = null!;
}
