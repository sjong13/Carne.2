using System;
using System.Diagnostics;
using Carne.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carne.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : DashboardPageXaml
    {
        public DashboardPage()
        {
            InitializeComponent();
            KeyPressed += DashboardPage_KeyPressed;
        }

        private void DashboardPage_KeyPressed(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case "Down":
                    ViewModel.MoveNext();
                    break;
                case "Up":
                    ViewModel.MovePrevious();
                    break;
                case "Right":
                    ViewModel.ShowDetails();
                    break;
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if(!ViewModel.IsInitialized)
            {
                await ViewModel.Init();
            }
            else
            {
                Debug.WriteLine("uh oh. frag detected.");
            }
            
        }

        private void OnSwipeUp(object sender, Xamarin.Forms.SwipedEventArgs e)
        {
            ViewModel.MoveNext();
        }

        private async void OnSwipeLeft(object sender, Xamarin.Forms.SwipedEventArgs e)
        {
            ImageView.FadeTo(0);
            await DetailView.FadeTo(1);
            //ViewModel.ShowDetails();
        }

        private void OnSwipeDown(object sender, SwipedEventArgs e)
        {
            ViewModel.MovePrevious();
        }
    }

    public abstract class DashboardPageXaml : ModelBoundContentPage<DashboardViewModel> { }
}