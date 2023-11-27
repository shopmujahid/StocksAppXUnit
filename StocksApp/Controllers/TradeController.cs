using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class TradeController : Controller
    {
        private readonly IFinnhubService _finnhubService;
        // private readonly IStockService _stockService;
        private readonly IOptions<TradingOptions> _options;
        public TradeController(IFinnhubService finnhubService, IOptions<TradingOptions> options)
        {
            _finnhubService= finnhubService;
            _options = options;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (_options.Value.DefaultStockSymbol==null) _options.Value.DefaultStockSymbol = "MSFT";

            Dictionary<string, object>? companyProfileDictionary = await _finnhubService.GetCompanyProfile(_options.Value.DefaultStockSymbol);
            Dictionary<string, object>? stockQuoteDictionary = await _finnhubService.GetPriceQuote(_options.Value.DefaultStockSymbol);

            StockTrade stockTrade = new StockTrade() { StockSymbol = _options.Value.DefaultStockSymbol };
            if (companyProfileDictionary != null && stockQuoteDictionary != null)
            {
                stockTrade = new StockTrade()
                {
                    StockSymbol = companyProfileDictionary["ticker"].ToString(),
                    StockName = companyProfileDictionary["name"].ToString(),
                    Price = Convert.ToDouble(stockQuoteDictionary["c"].ToString()),
                    Quantity = 1275
                };
            }

            return View(stockTrade);
        }
    }
}
