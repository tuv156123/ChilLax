using System;
using System.Collections.Generic;

namespace chilLax_Purchase.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string MemberName { get; set; } = null!;

    public string MemberTel { get; set; } = null!;

    public string? MemberAddress { get; set; }

    public string MemberEmail { get; set; } = null!;

    public DateTime MemberBirthday { get; set; }

    public bool? MemberSex { get; set; }

    public int? MemberPoint { get; set; }

    public DateTime MemberJoinTime { get; set; }
}
