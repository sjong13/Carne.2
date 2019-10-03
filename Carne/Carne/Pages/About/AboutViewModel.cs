using ReactiveUI.Fody.Helpers;
using Carne.Helpers;
using Xamarin.Essentials;

namespace Carne.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        #region // Fields
        #endregion

        #region // Properties
        public string AppVersion
        {
            get
            {
                return string.Format("{0} ({1})", AppInfo.VersionString, AppInfo.BuildString);
            }
        }

        public string DeviceId
        {
            get
            {
                return DeviceInfo.Name;
            }
        }

        public string Model
        {
            get
            {
                return DeviceInfo.Model;
            }
        }

        public string Version
        {
            get
            {
                return DeviceInfo.VersionString;
            }
        }

        public string Platform
        {
            get
            {
                return DeviceInfo.Platform.ToString();
            }
        }

        public string User
        {
            get
            {
                return SettingHelper.Email;
            }
        }

        [Reactive] public bool IsAdmin { get; set; }

        [Reactive] public string CurrentTheme { get; set; }
        #endregion

        #region // Ctor
        public AboutViewModel()
        {
            Title = "About";
        }
        #endregion

        #region // Methods
        public void RefreshStatus()
        {
            IsBusy = true;
            IsAdmin = SettingHelper.IsAdminMode;
            CurrentTheme = SettingHelper.CurrentTheme;
            IsBusy = false;
        }
        #endregion
    }
}