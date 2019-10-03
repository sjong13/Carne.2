using Carne.Interfaces;
using Carne.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carne.ViewModels
{
    public class RxViewModel : ReactiveObject
    {
        private CompositeDisposable _deactivateWith;
        public CompositeDisposable DeactivateWith
        {
            get
            {
                if (this._deactivateWith == null)
                    this._deactivateWith = new CompositeDisposable();

                return this._deactivateWith;
            }
            set { _deactivateWith = value; }
        }
        protected CompositeDisposable DestroyWith { get; } = new CompositeDisposable();
    }

    public class BaseViewModel : RxViewModel, IViewModel
    {
        #region // Fields
        public IDependencyService DependencyService { get; }
        #endregion

        #region // Constructor        
        public BaseViewModel(INavigation navigation = null) : this(new DependencyServiceWrapper())
        {
            Navigation = navigation;
        }

        public BaseViewModel(IDependencyService dependencyService)
        {
            DependencyService = dependencyService;
        }
        #endregion

        #region // Navigation 
        public INavigation Navigation { get; set; }

        public async Task PushModalAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushAsync(page);
        }

        public async Task PopAsync()
        {
            if (Navigation != null)
                await Navigation.PopAsync();
        }
        #endregion

        #region // Property Info
        [Reactive] public bool IsInitialized { get; set; }
        [Reactive] public bool CanLoadMore { get; set; }
        [Reactive] public bool IsBusy { get; protected set; }
        [Reactive] public string Title { get; set; }
        [Reactive] public string Subtitle { get; set; }
        [Reactive] public string Icon { get; set; }
        #endregion        
    }
}
