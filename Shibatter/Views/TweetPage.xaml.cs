using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Microsoft.Practices.Prism.StoreApps;
using Newtonsoft.Json;
using Shibatter.Models;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkID=390556 を参照してください

namespace Shibatter.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class TweetPage : VisualStateAwarePage
    {
        public TweetPage()
        {
            this.InitializeComponent();
            var localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey("Draft"))
            {
                this.ButtonDraftList.IsEnabled = true;
            }
        }

        /// <summary>
        /// このページがフレームに表示されるときに呼び出されます。
        /// </summary>
        /// <param name="e">このページにどのように到達したかを説明するイベント データ。
        /// このプロパティは、通常、ページを構成するために使用します。</param>
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //}

        private async void AppBarButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxTweet.Text))
            {
                Frame.GoBack();
                return;
            }

            var confirmDialog = new MessageDialog("ツイートを下書きに保存しますか？", "下書きの保存");
            confirmDialog.Commands.Add(new UICommand("保存する", (contextMenuCmd) => this.SaveDraftToLocalSettings(TextBoxTweet.Text)));
            confirmDialog.Commands.Add(new UICommand("閉じる", (contextMenuCmd) => Frame.GoBack()));
            confirmDialog.DefaultCommandIndex = 0;
            await confirmDialog.ShowAsync();
        }

        private void ButtonDraftList_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DraftListPage), null);
        }
        ///
        /// 
        /// <summary>
        /// 下書きを保存する
        /// </summary>
        /// <param name="tweetText">ツイート文字列</param>
        private void SaveDraftToLocalSettings(string tweetText)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            var draftModels = localSettings.Values.ContainsKey("Draft") ?
                JsonConvert.DeserializeObject<List<DraftModel>>(localSettings.Values["Draft"].ToString())
                : new List<DraftModel>();
            draftModels.Add(new DraftModel(tweetText));
            var jsonDraftModels = JsonConvert.SerializeObject(draftModels);
            localSettings.Values["Draft"] = jsonDraftModels;

            Frame.GoBack();
        }

        private void AppBarButtonCamera_Click(object sender, RoutedEventArgs e)
        {
        }

        CoreApplicationView view = CoreApplication.GetCurrentView();
        String ImagePath;

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {


            ImagePath = string.Empty;
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.ViewMode = PickerViewMode.Thumbnail;

            // Filter to include a sample subset of file types
            filePicker.FileTypeFilter.Clear();
            filePicker.FileTypeFilter.Add(".bmp");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".jpg");

            filePicker.PickSingleFileAndContinue();
            view.Activated += viewActivated; 
        }

        private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
        {
            FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;

            if (args != null)
            {
                if (args.Files.Count == 0) return;

                view.Activated -= viewActivated;
                StorageFile storageFile = args.Files[0];
                var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                await bitmapImage.SetSourceAsync(stream);

                var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
                this.ImageTweet1.Source = bitmapImage;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImagePath = string.Empty;
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.ViewMode = PickerViewMode.Thumbnail;

            // Filter to include a sample subset of file types
            filePicker.FileTypeFilter.Clear();
            filePicker.FileTypeFilter.Add(".bmp");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".jpg");

            filePicker.PickSingleFileAndContinue();
            view.Activated += viewActivated; 
        }
    }
}
