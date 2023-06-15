using System.ComponentModel;

namespace chilLax_Purchase.Models
{
	public class ProductOrderDetail
	{
		public ProductOrder ProductOrder { get; set; }
		public OrderDetail OrderDetail { get; set; }
		[DisplayName("小計")]
		public int Subtotal { get; set; }
	}
}
