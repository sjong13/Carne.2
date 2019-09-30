using Carne.Interfaces;
using Carne.UWP.Localization;
using System.Globalization;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace Carne.UWP.Localization
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            //var lang = GetCurrentCultureInfo().Name;
            //return new CultureInfo(lang);

            return CultureInfo.CurrentCulture;
        }
    }
}
