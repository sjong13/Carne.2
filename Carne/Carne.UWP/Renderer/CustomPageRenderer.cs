using Carne.Pages;
using Carne.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomPage), typeof(CustomPageRenderer))]
namespace Carne.UWP
{
    public class CustomPageRenderer : PageRenderer
    {
        public CustomPageRenderer() : base()
        {
            Loaded += (object sender, RoutedEventArgs e) =>
            {
                Windows.UI.Core.CoreWindow.GetForCurrentThread().KeyDown += HandleKeyDown;
            };

            Unloaded += (object sender, RoutedEventArgs e) =>
            {
                Windows.UI.Core.CoreWindow.GetForCurrentThread().KeyDown -= HandleKeyDown;
            };
        }

        public void HandleKeyDown(Windows.UI.Core.CoreWindow window, Windows.UI.Core.KeyEventArgs e)
        {
            (Element as CustomPage).SendKeyPressed(Element, new KeyEventArgs { Key = e.VirtualKey.ToString() });
        }


    }
}
