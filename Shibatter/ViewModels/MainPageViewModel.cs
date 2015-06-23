using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Reactive.Bindings;

namespace Shibatter.ViewModels
{
    internal class MainPageViewModel : ViewModel
    {
        private readonly INavigationService _navigationService; 
        public ReactiveProperty<string> HeaderTitle { get; private set; }

        /// <summary> 
        /// NavigationServiceを受け取るコンストラクタ 
        /// </summary> 
        /// <param name="navigationService"></param> 
        public MainPageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        } 

        /// <summary>
        /// 画面遷移してくると呼ばれる
        /// </summary>
        /// <param name="naviParam"></param>
        /// <param name="naviMode"></param>
        /// <param name="viewModelState"></param>
        public override void OnNavigatedTo(object naviParam, NavigationMode naviMode,
            Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(naviParam, naviMode, viewModelState);
            this.HeaderTitle = new ReactiveProperty<string>("Welcome to Shibatter!!");
        }

        /// <summary>
        /// 別画面に遷移するときに呼ばれる
        /// </summary>
        /// <param name="viewModelSate"></param>
        /// <param name="suspending"></param>
        public override void OnNavigatedFrom(Dictionary<string, object> viewModelSate, bool suspending)
        {
            base.OnNavigatedFrom(viewModelSate, suspending);
            this.HeaderTitle.Dispose();
        }

        private DelegateCommand navigateTweetPageCommand;
        /// <summary> 
        /// 画面遷移を行うコマンド 
        /// </summary> 
        public DelegateCommand NavigateTweetPageCommand
        {
            get
            {
                return this.navigateTweetPageCommand ?? (this.navigateTweetPageCommand = new DelegateCommand(this.NavigateTweetPageExecute));
            }
        } 

        /// <summary> 
        /// 画面遷移処理を行います 
        /// </summary> 
        private void NavigateTweetPageExecute()
        {
            this._navigationService.Navigate("Tweet", null);
        } 
    }
}
