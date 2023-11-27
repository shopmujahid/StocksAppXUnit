using StocksApp.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StocksApp.DTO
{
    public class BuyOrderRequest
    {
        [Required(ErrorMessage ="Stock Symbol can't be blank")]
        [DisplayName("Stock Symbol")]
        public string StockSymbol { get; set; }
        
        [Required(ErrorMessage = "Stock Name can't be blank")]
        [DisplayName("Stock Name")]
        public string StockName { get; set; }
        [Range(typeof(DateTime), "2000/01/01", "2023/11/27", ErrorMessage ="Minimum Date should be 01/01/2000")]
        public DateTime OrderDateTime { get; set; }
        [Range(1, 100000, ErrorMessage = "Quantity shoule be between 1 and 1,00,000")]
        public uint Quantity { get; set; }
        [Range(1, 10000, ErrorMessage = "Price should be between 1 and 10,000")]
        public double Price { get; set; }

        public BuyOrder ToBuyOrder()
        {
            return new BuyOrder()
            {
                StockSymbol = StockSymbol,
                StockName = StockName,
                OrderDateTime = OrderDateTime,
                Price = Price,
                Quantity = Quantity
            };
        }
    }
}
