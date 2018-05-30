using System.Threading.Tasks;
using Xamarin.Forms;

namespace Church
{
    public interface IPageService
    {
        Task PushAsync(Page page);

        Task PopAsync();
    }
}
