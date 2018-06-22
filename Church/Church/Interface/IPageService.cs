using System.Threading.Tasks;
using Xamarin.Forms;

namespace Church
{
    public interface IPageService
    {
        Task UpdatePresentNavigationPage(Page page);

        Task PopAsync();
        
		Task PushAsync(Page page);
    }
}
