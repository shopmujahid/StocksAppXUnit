using StocksApp.DTO;
using StocksApp.Helpers;
using StocksApp.Models;

namespace StocksApp.Services
{
    public class StockServices : IStockService
    {
        public readonly List<BuyOrder> _buyOrders;
        public readonly List<SellOrder> _sellOrders;

        public StockServices()
        {
            _buyOrders = new List<BuyOrder>();
            _sellOrders = new List<SellOrder>();
        }
        public BuyOrderResponse CreateBuyOrder(BuyOrderRequest? request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            // Model Validation
            ValidationHelper.ModelValidation(request);

            BuyOrder buyOrder = request.ToBuyOrder();
            buyOrder.BuyOrderId = Guid.NewGuid();
            _buyOrders.Add(buyOrder);

            return buyOrder.ToBuyOrderResponse();
        }

        public SellOrderResponse CreateSellOrder(SellOrderRequest? request)
        {
            if(request == null) throw new ArgumentNullException( nameof(request));

            // Model Validation
            ValidationHelper.ModelValidation(request);

            SellOrder sellOrder = request.ToSellOrder();
            sellOrder.SellOrderId = Guid.NewGuid();
            _sellOrders.Add(sellOrder);
            return sellOrder.ToSellOrderResponse();
        }

        public List<BuyOrderResponse> GetBuyOrders()
        {
            return _buyOrders.Select(x => x.ToBuyOrderResponse()).ToList();
        }

        public List<SellOrderResponse> GetSellOrders()
        {
            return _sellOrders.Select(x => x.ToSellOrderResponse()).ToList();
        }
    }
}
