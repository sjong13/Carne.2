using Carne.Constants;
using Carne.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carne.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeItemTemplate : ContentView
    {
        public ThemeItemTemplate()
        {
            InitializeComponent();
        }

        public void ApplyClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string themeName = button.CommandParameter.ToString();
            SettingHelper.SetTheme(themeName);
        }
    }
}