using Carne.Helpers;
using Carne.Pages;
using Carne.Web.Models;
using Newtonsoft.Json;
using ReactiveUI.Fody.Helpers;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carne.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        #region // Fields + Properties
        private int currentIndex;

        public int  CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value;
                CurrentMeat = BufferedMeatList[currentIndex];
                CurrentImageSource = BufferedImageSources[currentIndex];
                CurrentRestaurant = RestaurantList.Where(x => x.Id.Equals(CurrentMeat.RestaurantId)).FirstOrDefault();
            }
        }

        

        [Reactive] public Meat CurrentMeat { get; set; }
        [Reactive] public Restaurant CurrentRestaurant { get; set; }
        public List<Meat> BufferedMeatList { get; set; }
        

        internal void HideDetails()
        {
            throw new NotImplementedException();
        }

        [Reactive] public ImageSource CurrentImageSource { get; set; }
        public List<ImageSource> BufferedImageSources { get; set; }
        public List<Meat> MeatList { get; set; }
        public List<Restaurant> RestaurantList { get; set; }
        private int bufferSize = 5;

        #endregion

        #region // Constructor(s)
        public DashboardViewModel()
        {
            Title = "Dashboard";
        }
        #endregion

        #region // Methods   
        public async Task Init()
        {
            // calls to api/meats
            JsonServiceClient jsonClient = new JsonServiceClient("http://10.15.10.71:8989/");

            string response = await jsonClient.GetAsync<string>("api/meats");

            MeatList = JsonConvert.DeserializeObject<List<Meat>>(response);
            BufferedMeatList = MeatList.GetRange(0, bufferSize - 1);
            BufferedImageSources = new List<ImageSource>();
            foreach (var item in BufferedMeatList)
            {
                BufferedImageSources.Add(ImageHelper.GetImageSourceFromUrl(item.URI));
            }

            string response2 = await jsonClient.GetAsync<string>("api/restaurants");
            RestaurantList = JsonConvert.DeserializeObject<List<Restaurant>>(response2);

            CurrentIndex = 0;

            

            IsInitialized = true;
        }

        public void MoveNext()
        {
            if(CurrentIndex < MeatList.Count() -2)
            {
                CurrentIndex++;
            }
            
            if(!(bufferSize + CurrentIndex - 1 >= MeatList.Count()))
            {
                BufferedMeatList.Add(MeatList[bufferSize + CurrentIndex - 1]);
                BufferedImageSources.Add(ImageHelper.GetImageSourceFromUrl(MeatList[bufferSize + CurrentIndex - 1].URI));
            }
            
        }

        public void MovePrevious()
        {
            if(CurrentIndex > 0)
            {
                CurrentIndex--;
            }
        }

        #endregion
    }
       


    }