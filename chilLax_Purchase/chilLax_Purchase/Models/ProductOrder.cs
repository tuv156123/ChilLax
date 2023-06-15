using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace chilLax_Purchase.Models;

public partial class ProductOrder
{
    [DisplayName("訂單編號")]
    public int OrderId { get; set; }
	
	[DisplayName("會員編號")]
	public int MemberId { get; set; }

	[DisplayName("付款方式")]
	public bool OrderPayment { get; set; }

	[DisplayName("訂單總價")]
	public int OrderTotalPrice { get; set; }

	[DisplayName("訂單物流")]
	public bool OrderDelivery { get; set; }

	[DisplayName("送貨地址")]
	public string OrderAddress { get; set; } = null!;

	[DisplayName("訂單日期")]
	public DateTime OrderDate { get; set; }

	[DisplayName("訂單備註")]
	public string? OrderNote { get; set; }

	[DisplayName("訂單狀態")]
	public string OrderState { get; set; } = null!;
}
