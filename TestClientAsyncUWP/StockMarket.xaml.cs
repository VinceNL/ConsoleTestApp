using StockMarketLibrary;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestClientAsyncUWP
{
    /// <summary>
    /// StockMarket Page to illustrate CPU Bound async Operations best practise
    /// </summary>
    public sealed partial class StockMarket : Page
    {
        string _data = null;

        public StockMarket()
        {
            this.InitializeComponent();
        }

        private void AddListItem(string text)
        {
            var item = new ListViewItem();
            var textBlock = new TextBlock();
            textBlock.Text = text;
            item.Content = textBlock;
            lvwOutput.Items.Add(item);
        }

        private void Local_Operation_Click(object sender, RoutedEventArgs e)
        {
            AddListItem($"Fast Local Operation Completed - ThreadId - {Thread.CurrentThread.ManagedThreadId}");
        }

        private async void btnCPUBoundOperation_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_data))
            {
                StockMarketData stockMarketData = new StockMarketData();
                _data = await stockMarketData.GetDataAsync();
            }

            var stockMarketDataAnalysis = new StockMarketDataAnalysis(_data);

            List<Task<string>> tasks = new List<Task<string>>
            {
                Task.Run(() => stockMarketDataAnalysis.CalculateFastMovingAverage()),
                Task.Run(() => stockMarketDataAnalysis.CalculateSlowMovingAverage()),
                Task.Run(() => stockMarketDataAnalysis.CalculateStockastics()),
                Task.Run(() => stockMarketDataAnalysis.CalculateBollingerBands())
            };

            // Task.WaitAll(tasks.ToArray()); // Blocks UI thread

            await Task.WhenAll(tasks.ToArray()).ConfigureAwait(false); // Do not return to Main UI thread with ConfigureAwait(false)

            AddListItem(tasks[0].Result);
            AddListItem(tasks[1].Result);
            AddListItem(tasks[2].Result);
            AddListItem(tasks[3].Result);

            DisplayIndicatorsOnChart(tasks[0].Result, tasks[1].Result, tasks[2].Result, tasks[3].Result);
        }

        private void DisplayIndicatorsOnChart(string result1, string result2, string result3, string result4)
        {
            // Code to display indicators on chart
        }

        private void btnNavStockMarket_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}