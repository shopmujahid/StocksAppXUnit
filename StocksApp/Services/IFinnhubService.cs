namespace StocksApp.Services
{
    public interface IFinnhubService
    {
        Task<Dictionary<string, object>> GetCompanyProfile(string stockSymbol);
        Task<Dictionary<string, object>> GetPriceQuote(string stockSymbol);
    }
}
