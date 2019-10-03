using Carne.Web.Models;
using Newtonsoft.Json;
using ReactiveUI.Fody.Helpers;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Carne.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        #region // Fields + Properties
        [Reactive] public Meat CurrentMeat { get; set; }

        #endregion

        #region // Constructor(s)
        public DashboardViewModel()
        {
            Title = "Dashboard";
        }
        #endregion

        #region // Methods   
        public async void Init()
        {
            // calls to api/meats
            JsonServiceClient jsonClient = new JsonServiceClient("http://localhost:8989");

            string response = await jsonClient.GetAsync<string>("api/meats");

            List<Meat> returned = JsonConvert.DeserializeObject<List<Meat>>(response);

            CurrentMeat = returned[0];
        }
        #endregion
    }
}