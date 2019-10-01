using Carne.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carne.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageDisplayPage : ImageDisplayPageXaml
    {
        public ImageDisplayPage()
        {
            InitializeComponent();
        }
    }

    public abstract class ImageDisplayPageXaml : ModelBoundContentPage<ImageDisplayPageViewModel> { }
}