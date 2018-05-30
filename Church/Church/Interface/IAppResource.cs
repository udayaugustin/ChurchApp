namespace Church
{
    public interface IAppResource
    {
        bool IsLoggedIn();

        void UpdateLoginStatus(bool loginStatus);
    }
}
