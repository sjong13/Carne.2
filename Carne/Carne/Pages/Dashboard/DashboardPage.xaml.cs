using Carne.ViewModels;
using Xamarin.Forms.Xaml;

namespace Carne.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : DashboardPageXaml
    {
        public DashboardPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Init();
        }
    }

    public abstract class DashboardPageXaml : ModelBoundContentPage<DashboardViewModel> { }
}