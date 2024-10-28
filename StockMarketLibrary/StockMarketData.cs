using System.Threading.Tasks;

namespace StockMarketLibrary
{
    public class StockMarketData
    {
        public StockMarketData()
        {

        }

        public async Task<string> GetDataAsync()
        {
            await Task.Delay(5000);

            return "StockMarket Data";
        }
    }
}
