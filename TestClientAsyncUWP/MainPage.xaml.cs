using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestClientAsyncUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int _localOperationCount = 0;
        private int _webApiOperationCount = 0;

        public MainPage()
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
            _localOperationCount++;
            AddListItem($"Local operation {_localOperationCount} completed");
        }

        private async void btnWebAPICall_Click(object sender, RoutedEventArgs e)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage response = null;

            try
            {
                response = await httpClient.GetAsync("http://localhost:5014/TestLongOperation");

            }
            catch (System.Exception)
            {

                throw;
            }

            string result = await response.Content.ReadAsStringAsync();

            _webApiOperationCount++;

            AddListItem($"Web API operation {_webApiOperationCount} completed: {result}");
        }
    }
}