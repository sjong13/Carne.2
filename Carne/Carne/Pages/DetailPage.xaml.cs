using Carne.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carne.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : DetailPageXaml
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        private async void OnSwipeRight(object sender, SwipedEventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }

    public abstract class DetailPageXaml : ModelBoundContentPage<DetailPageViewModel> { }
}