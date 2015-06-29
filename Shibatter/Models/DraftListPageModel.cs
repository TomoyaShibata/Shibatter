using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Windows.Storage;
using Microsoft.Practices.Prism.Mvvm;
using Newtonsoft.Json;

namespace Shibatter.Models
{
    class DraftListPageModel : BindableBase
    {
        private ObservableCollection<DraftModel> _draftModels = new ObservableCollection<DraftModel>();
        public ObservableCollection<DraftModel> DraftModels
        {
            get { return this._draftModels; }
            set { this.SetProperty(ref this._draftModels, value); }
        }

        /// <summary>
        /// 下書きを読み込む
        /// </summary>
        public void LoadDraftModels()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            var localDraftModels = JsonConvert.DeserializeObject<List<DraftModel>>(localSettings.Values["Draft"].ToString());
            this.DraftModels.Clear();

            localDraftModels.ToObservable().ForEachAsync(_ => this.DraftModels.Add(_));
        }
    }
}
