using StocksApp.Models;
using System.ComponentModel;

namespace StocksApp.DTO
{
    public class SellOrderResponse
    {
        [DisplayName("Sell Order Id")]
        public Guid SellOrderId { get; set; }
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
            if (obj == null || obj.GetType()!= typeof(SellOrderResponse)) return false;
            
            SellOrderResponse sellOrderResponse = (SellOrderResponse)obj;
            return SellOrderId==sellOrderResponse.SellOrderId && StockSymbol == sellOrderResponse.StockSymbol && 
                Price==sellOrderResponse.Price && OrderDateTime==sellOrderResponse.OrderDateTime && Quantity==sellOrderResponse.Quantity &&
                TradeAmount==sellOrderResponse.TradeAmount && StockName == sellOrderResponse.StockName;
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    public static class SellOrderExtensions
    {
        public static SellOrderResponse ToSellOrderResponse(this SellOrder sellOrder)
        {
            return new SellOrderResponse()
            {
                SellOrderId = sellOrder.SellOrderId,
                StockName = sellOrder.StockName,
                StockSymbol = sellOrder.StockSymbol,
                OrderDateTime = sellOrder.OrderDateTime,
                Quantity = sellOrder.Quantity,
                Price = sellOrder.Price
            };
        }
    }
}
