using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using StocksApp.Models;

namespace StocksApp.DTO
{
    public class BuyOrderResponse
    {
        [DisplayName("Purchase Order Id")]
        public Guid BuyOrderId { get; set;}
        [DisplayName("Stock Symbol")]
        public string StockSymbol { get; set; }

        [DisplayName("Stock Name")]
        public string StockName { get; set; }
        public DateTime OrderDateTime { get; set; }
        public uint Quantity { get; set; }
        public double Price { get; set; }
        [DisplayName("Trade Amount")]
        public double TradeAmount { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || (obj.GetType() != typeof(BuyOrderResponse))) return false;

            BuyOrderResponse buyOrderResponse = (BuyOrderResponse)obj;
            return  BuyOrderId == buyOrderResponse.BuyOrderId && StockSymbol == buyOrderResponse.StockSymbol && StockName == buyOrderResponse.StockName &&
                    Price == buyOrderResponse.Price && OrderDateTime == buyOrderResponse.OrderDateTime && Quantity == buyOrderResponse.Quantity
                    && Price == buyOrderResponse.Price && TradeAmount == buyOrderResponse.TradeAmount;
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    public static class BuyOrderExtensions
    {
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
        {
            return new BuyOrderResponse() 
            { 
                BuyOrderId = buyOrder.BuyOrderId, OrderDateTime = buyOrder.OrderDateTime,
                Quantity = buyOrder.Quantity, Price = buyOrder.Price,StockName = buyOrder.StockName,
                StockSymbol = buyOrder.StockSymbol
            };
        }
    }
}
