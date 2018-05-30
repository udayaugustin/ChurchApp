using Xamarin.Forms;

namespace Church
{
    public class AppResourceService : IAppResource
    {
        private const string LoginStatusKey = "IsLoggedIn";
        public bool IsLoggedIn()
        {
            if(Application.Current.Properties.ContainsKey(LoginStatusKey))
            {
                System.Diagnostics.Debug.WriteLine("Value : "+Application.Current.Properties[LoginStatusKey].ToString());
                if (Application.Current.Properties[LoginStatusKey].ToString() == "True")                
                    return true;
            }

            return false;
        }

        public void UpdateLoginStatus(bool loginStatus)
        {
            Application.Current.Properties[LoginStatusKey] = loginStatus;
            Application.Current.SavePropertiesAsync();
        }
    }
}
