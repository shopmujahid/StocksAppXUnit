using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StocksApp.Models
{
    public class BuyOrder
    {
        [Required(ErrorMessage ="Buy Order Id can't be blank")]
        [DisplayName("Purchased Order Id")]
        public Guid BuyOrderId { get; set; }
        [Required(ErrorMessage = "Stock Symbol can't be blank")]
        [DisplayName("Stock Symbol")]
        public string StockSymbol { get; set; }
        [Required(ErrorMessage = "Stock Name can't be blank")]
        [DisplayName("Stock Name")]
        public string StockName { get; set; }
        [DisplayName("Purchase Order Date")]
        public DateTime OrderDateTime { get; set; }
        [Range(1, 100000, ErrorMessage = "Quantity shoule be between 1 and 1,00,000")]
        public uint Quantity { get; set; }
        [Range(1, 10000, ErrorMessage = "Price should be between 1 and 10,000")]
        public double Price { get; set; }

    }
}
