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
    }

    public abstract class DashboardPageXaml : ModelBoundContentPage<DashboardViewModel> { }
}