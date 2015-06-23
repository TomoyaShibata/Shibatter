using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Mvvm;

namespace Shibatter.ViewModels
{
    internal class TweetPageViewModel : ViewModel
    {
        /// <summary>
        /// 画面遷移してくると呼ばれる
        /// </summary>
        /// <param name="naviParam"></param>
        /// <param name="naviMode"></param>
        /// <param name="viewModelSate"></param>
        public override void OnNavigatedTo(object naviParam, NavigationMode naviMode,
            Dictionary<string, object> viewModelSate)
        {
            base.OnNavigatedTo(naviParam, naviMode, viewModelSate);
        }

        public override void OnNavigatedFrom(Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatedFrom(viewModelState, suspending);
            var hoge = true;
        }
    }
}
