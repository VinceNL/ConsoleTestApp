using Windows.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestClientAsyncUWP
{
    /// <summary>
    /// StockMarket Page to illustrate CPU Bound async Operations best practise
    /// </summary>
    public sealed partial class CancelTasks : Page
    {
        readonly CancellationTokenSource s_cts = new CancellationTokenSource();

        readonly HttpClient s_client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };

        readonly IEnumerable<string> s_urlList = new string[]
        {
            "https://learn.microsoft.com",
            "https://learn.microsoft.com/aspnet/core",
            "https://learn.microsoft.com/azure",
            "https://learn.microsoft.com/azure/devops",
            "https://learn.microsoft.com/dotnet",
            "https://learn.microsoft.com/dynamics365",
            "https://learn.microsoft.com/education",
            "https://learn.microsoft.com/enterprise-mobility-security",
            "https://learn.microsoft.com/gaming",
            "https://learn.microsoft.com/graph",
            "https://learn.microsoft.com/microsoft-365",
            "https://learn.microsoft.com/office",
            "https://learn.microsoft.com/powershell",
            "https://learn.microsoft.com/sql",
            "https://learn.microsoft.com/surface",
            "https://learn.microsoft.com/system-center",
            "https://learn.microsoft.com/visualstudio",
            "https://learn.microsoft.com/windows",
            "https://learn.microsoft.com/maui"
        };

        public CancelTasks()
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

        private void btnbtnNavMainPage_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void btnDownloadContent_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                s_cts.CancelAfter(3500);
                await SumPageSizesAsync();
            }
            catch (TaskCanceledException)
            {

                AddListItem("Download operation cancelled");
            }
        }

        private void btnCancelDownload_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            s_cts.Cancel();
        }

        private async Task SumPageSizesAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            int total = 0;
            foreach (string url in s_urlList)
            {
                int contentLength = await ProcessUrlAsync(url, s_client, s_cts.Token);
                total += contentLength;
            }

            stopwatch.Stop();

            AddListItem($"Total bytes returned:  {total:#,#}");
            AddListItem($"Elapsed time:          {stopwatch.Elapsed}");
        }

        private async Task<int> ProcessUrlAsync(string url, HttpClient client, CancellationToken token)
        {
            HttpResponseMessage response = await client.GetAsync(url, token);
            byte[] content = await response.Content.ReadAsByteArrayAsync();
            AddListItem($"{url,-60} {content.Length,10:#,#}");

            return content.Length;
        }
    }
}