using System;
using System.Diagnostics;
using System.Threading.Tasks;
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
            DetailView.BackgroundColor = Color.FromRgba(0, 0, 0, .25);
        }

        private void DashboardPage_KeyPressed(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case "Down":
                    OnSwipeUp();
                    break;
                case "Up":
                    OnSwipeDown();
                    break;
                case "Right":
                    OnSwipeLeft();
                    break;
                case "Left":
                    OnSwipeRight();
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

        private void OnSwipeUp(object sender = null, SwipedEventArgs e = null)
        {
            if(ImageView.IsVisible)
            ViewModel.MoveNext();
            DetailView.IsVisible = false;
        }

        private async void OnSwipeLeft(object sender = null, SwipedEventArgs e = null)
        {
            DetailView.IsVisible = true;
        }

        private void OnSwipeDown(object sender = null, SwipedEventArgs e = null)
        {
            if(ImageView.IsVisible)
            {
                ViewModel.MovePrevious();
                DetailView.IsVisible = false;
            }
            
        }

        private void OnSwipeRight(object sender = null, SwipedEventArgs e = null)
        {
            DetailView.IsVisible = false;
        }
    }

    public abstract class DashboardPageXaml : ModelBoundContentPage<DashboardViewModel> { }
}