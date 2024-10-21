namespace AsyncCPUBoundExample
{
    public class AsyncCPUBoundExample
    {
        public AsyncCPUBoundExample(string stockSymbol, DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            // Code here gets stock market data from remote server.
        }

        public decimal[] GetOpeningPrices()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(GetOpeningPrices)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(1000);

            data = [100.00m, 101.00m, 102.00m, 103.00m, 104.00m];

            return data;
        }

        public decimal[] GetClosingPrices()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(GetClosingPrices)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(1000);

            data = [110.00m, 111.00m, 112.00m, 113.00m, 114.00m];

            return data;
        }

        public decimal[] GetHighPrices()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(GetHighPrices)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(1000);

            data = [120.00m, 121.00m, 122.00m, 123.00m, 124.00m];

            return data;
        }

        public decimal[] GetLowPrices()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(GetLowPrices)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(1000);

            data = [90.00m, 91.00m, 92.00m, 93.00m, 94.00m];

            return data;
        }

        public decimal[] CalculateStockastics()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(CalculateStockastics)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(10000);

            data = [80.00m, 81.00m, 82.00m, 83.00m, 84.00m];

            return data;
        }

        public decimal[] CalculateFastMovingAvarage()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(CalculateFastMovingAvarage)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(7000);

            data = [90.00m, 91.00m, 92.00m, 93.00m, 94.00m];

            return data;
        }

        public decimal[] CalculateSlowMovingAvarage()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(CalculateSlowMovingAvarage)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(6000);

            data = [100.00m, 101.00m, 102.00m, 103.00m, 104.00m];

            return data;
        }

        public decimal[] CalculateUpperBoundBollingerBand()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(CalculateUpperBoundBollingerBand)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(5000);

            data = [110.00m, 111.00m, 112.00m, 113.00m, 114.00m];

            return data;
        }

        public decimal[] CalculateLowerBoundBollingerBand()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(CalculateLowerBoundBollingerBand)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(5000);

            data = [90.00m, 91.00m, 92.00m, 93.00m, 94.00m];

            return data;
        }
    }
}