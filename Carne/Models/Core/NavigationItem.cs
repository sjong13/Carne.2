using Carne.Pages;
using Carne.ViewModels;
using System;

namespace Carne.Models
{
    public class NavigationItem
    {
        public NavigationItem()
        {
            PageType = typeof(DashboardPage);
            ViewModelType = typeof(DashboardViewModel);
        }

        public string Icon { get; set; }

        public Type PageType { get; set; }

        public Type ViewModelType { get; set; }

        public string MenuTitle { get; set; }

        public string PageTitle { get; set; }

        public int Id { get; set; }

        public string Category { get; set; }
    }
}
