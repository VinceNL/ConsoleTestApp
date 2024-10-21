namespace ConsoleTestApp
{
    public static class AsyncCPUBoundExampleRunner
    {
        public static void Run()
        {
            Console.WriteLine($"Method name: Main, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

            var stockMarketTechnicalAnalysisData = new AsyncCPUBoundExample.AsyncCPUBoundExample("AAPL", DateTime.Now.AddDays(-5), DateTime.Now);

            DateTime dateTimeBefore = DateTime.Now;

            // Get methods synchronously
            //decimal[] data1 = stockMarketTechnicalAnalysisData.GetOpeningPrices();
            //decimal[] data2 = stockMarketTechnicalAnalysisData.GetClosingPrices();
            //decimal[] data3 = stockMarketTechnicalAnalysisData.GetHighPrices();
            //decimal[] data4 = stockMarketTechnicalAnalysisData.GetLowPrices();
            //decimal[] data5 = stockMarketTechnicalAnalysisData.CalculateStockastics();
            //decimal[] data6 = stockMarketTechnicalAnalysisData.CalculateFastMovingAvarage();
            //decimal[] data7 = stockMarketTechnicalAnalysisData.CalculateSlowMovingAvarage();
            //decimal[] data8 = stockMarketTechnicalAnalysisData.CalculateUpperBoundBollingerBand();
            //decimal[] data9 = stockMarketTechnicalAnalysisData.CalculateLowerBoundBollingerBand();

            // Call methods asynchronously
            List<Task<decimal[]>> tasks = new List<Task<decimal[]>>();

            Task<decimal[]> task1 = Task.Run(() => stockMarketTechnicalAnalysisData.GetOpeningPrices());
            Task<decimal[]> task2 = Task.Run(() => stockMarketTechnicalAnalysisData.GetClosingPrices());
            Task<decimal[]> task3 = Task.Run(() => stockMarketTechnicalAnalysisData.GetHighPrices());
            Task<decimal[]> task4 = Task.Run(() => stockMarketTechnicalAnalysisData.GetLowPrices());
            Task<decimal[]> task5 = Task.Run(() => stockMarketTechnicalAnalysisData.CalculateStockastics());
            Task<decimal[]> task6 = Task.Run(() => stockMarketTechnicalAnalysisData.CalculateFastMovingAvarage());
            Task<decimal[]> task7 = Task.Run(() => stockMarketTechnicalAnalysisData.CalculateSlowMovingAvarage());
            Task<decimal[]> task8 = Task.Run(() => stockMarketTechnicalAnalysisData.CalculateUpperBoundBollingerBand());
            Task<decimal[]> task9 = Task.Run(() => stockMarketTechnicalAnalysisData.CalculateLowerBoundBollingerBand());

            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);
            tasks.Add(task4);
            tasks.Add(task5);
            tasks.Add(task6);
            tasks.Add(task7);
            tasks.Add(task8);
            tasks.Add(task9);

            Task.WaitAll(tasks.ToArray());

            decimal[] data1 = tasks[0].Result;
            decimal[] data2 = tasks[1].Result;
            decimal[] data3 = tasks[2].Result;
            decimal[] data4 = tasks[3].Result;
            decimal[] data5 = tasks[4].Result;
            decimal[] data6 = tasks[5].Result;
            decimal[] data7 = tasks[6].Result;
            decimal[] data8 = tasks[7].Result;
            decimal[] data9 = tasks[8].Result;

            DateTime dateTimeAfter = DateTime.Now;

            TimeSpan timeSpan = dateTimeAfter.Subtract(dateTimeBefore);

            Console.WriteLine($"Time taken to get stock market data: {timeSpan.Seconds} {(timeSpan.Seconds > 1 ? "seconds" : "second")}");

            Console.WriteLine("Data is displayed on chart");

            Console.ReadKey();
        }
    }
}