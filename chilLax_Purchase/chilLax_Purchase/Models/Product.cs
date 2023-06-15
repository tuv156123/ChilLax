using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace chilLax_Purchase.Models;

public partial class Product
{
    [DisplayName("商品編號")]
    public int ProductId { get; set; }

	[DisplayName("供應商編號")]
	public int SupplierId { get; set; }

	[DisplayName("商品名稱")]
	public string ProductName { get; set; } = null!;

	[DisplayName("商品說明")]
	public string ProductDesc { get; set; } = null!;

	[DisplayName("商品價格")]
	public int ProductPrice { get; set; }

	[DisplayName("商品圖片")]
	public string ProductImg { get; set; } = null!;

	[DisplayName("商品數量")]
	public int ProductQuantity { get; set; }

	[DisplayName("商品分類")]
	public string ProductCategory { get; set; } = null!;

	[DisplayName("商品狀態")]
	public bool ProductState { get; set; }
}
