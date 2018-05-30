using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Church
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoPage : ContentPage
    {
		public VideoPage()
        {
            InitializeComponent();

            BindingContext = new YoutubeViewModel();
        }

        private void ListViewOnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            var youtubeItem = itemTappedEventArgs.Item as YoutubeItem;

            var url = "https://www.youtube.com/watch?v=" + youtubeItem?.VideoId;
            Navigation.PushAsync(new PlayVideoPage(url));
        }
    }
}