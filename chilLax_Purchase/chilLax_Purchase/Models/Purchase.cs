using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chilLax_Purchase.Models;

public partial class Purchase
{
    [Display(Name = "單號")]
    public int PurchaseId { get; set; }
    [Display(Name = "供應商ID")]
    public int SupplierId { get; set; }
    [Display(Name = "訂單備註")]
    public string? PurchaseNote { get; set; }
    [Display(Name = "訂購單日期")]
    public DateTime PurchaseDate { get; set; }
}
