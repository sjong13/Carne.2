using Carne.Models;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;

namespace Carne.ViewModels
{
    public class ImageDisplayPageViewModel : BaseViewModel
    {
        private List<Meat> meats;
        private IServiceClient jsonClient;

        private string meatURI;

        public string MeatURI
        {
            get { return meatURI; }
            set { meatURI = value; OnPropertyChanged(); }
        }

        public List<Meat> Meats
        {
            get { return Meats; }
            set { Meats = value; }
        }

       

        #region // Constructor(s)
        public ImageDisplayPageViewModel()
        {
            jsonClient = new JsonServiceClient();
            MeatURI = "https://www.seriouseats.com/images/2015/04/Anova-Steak-Guide-Sous-Vide-Photos15-beauty.jpg";
            LoadMeats();
            
        }

        private async void LoadMeats()
        {
            //string uri = "http://192.168.56.1:44344/api/Meats";
            //var httpClient = new HttpClient();
            //var response = await httpClient.GetStringAsync(uri);


            //Meats = result.Meats.ToList();

            //MeatURI = Meats.First().URI;
        }
        #endregion
    }
}
