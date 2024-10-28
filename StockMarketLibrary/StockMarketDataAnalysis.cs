using System.Threading;

namespace StockMarketLibrary
{
    public class StockMarketDataAnalysis
    {
        public StockMarketDataAnalysis(string data)
        {

        }

        public string CalculateFastMovingAverage()
        {
            Thread.Sleep(5000);

            return $"{nameof(CalculateFastMovingAverage)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
        }

        public string CalculateSlowMovingAverage()
        {
            Thread.Sleep(7000);

            return $"{nameof(CalculateSlowMovingAverage)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
        }

        public string CalculateStockastics()
        {
            Thread.Sleep(10000);

            return $"{nameof(CalculateStockastics)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
        }

        public string CalculateBollingerBands()
        {
            Thread.Sleep(3000);

            return $"{nameof(CalculateBollingerBands)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
        }
    }
}
