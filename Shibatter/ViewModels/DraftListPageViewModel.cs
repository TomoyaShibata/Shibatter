using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Mvvm;
using Reactive.Bindings;
using Shibatter.Models;

namespace Shibatter.ViewModels
{
    internal class DraftListPageViewModel : ViewModel
    {
        public DraftListPageViewModel()
        { }

        public ReadOnlyReactiveCollection<DraftModel> DraftListPageModels { get; private set; }

        private RootModel RootModel { get; set; }

        public DraftListPageViewModel(RootModel rootModel)
        {
            this.RootModel = rootModel;
        }

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

            this.DraftListPageModels = this.RootModel.DraftListPageModel.DraftModels.ToReadOnlyReactiveCollection();
            this.RootModel.DraftListPageModel.LoadDraftModels();
        }
    }
}
