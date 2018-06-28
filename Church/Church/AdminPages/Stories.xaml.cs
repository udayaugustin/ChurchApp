using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Church
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Stories : ContentPage
	{
		public Stories (Story story)
		{
            BindingContext = new AddStoryViewModel(story, new PageService());

			InitializeComponent ();
		}
	}
}