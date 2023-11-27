using StocksApp.DTO;

namespace StocksApp.Services
{
    public interface IStockService
    {
        /// <summary>
        /// Creates a Purchase order and stores to the list of Purchase order
        /// </summary>
        /// <param name="request">Purchase Order request to create Purchase order</param>
        /// <returns>Purchase order object</returns>
        public BuyOrderResponse CreateBuyOrder(BuyOrderRequest? request);
        /// <summary>
        /// Creates a Sale order and stores to the list of Sale order
        /// </summary>
        /// <param name="request">Sales Order request to create Sales order</param>
        /// <returns>Sales Order object</returns>
        public SellOrderResponse CreateSellOrder(SellOrderRequest? request);
        /// <summary>
        /// Return all Purchase order list
        /// </summary>
        /// <returns>Returns list of Purchase order</returns>
        public List<BuyOrderResponse> GetBuyOrders();
        /// <summary>
        /// Returns all sale order list
        /// </summary>
        /// <returns>Returns list of Sales order</returns>
        public List<SellOrderResponse> GetSellOrders();
    }
}
