using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Church
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayVideoPage : ContentPage
    {
        public PlayVideoPage(string videoUrl)
        {
            InitializeComponent();

            var webView = new WebView
            {
                Source = videoUrl
            };

            Content = webView;
        }
    }
}