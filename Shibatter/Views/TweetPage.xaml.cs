using System;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.StoreApps;

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
        }

        /// <summary>
        /// このページがフレームに表示されるときに呼び出されます。
        /// </summary>
        /// <param name="e">このページにどのように到達したかを説明するイベント データ。
        /// このプロパティは、通常、ページを構成するために使用します。</param>
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //}

        private async void AppBarButtonCancel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxTweet.Text))
            {
                Frame.GoBack();
                return;
            }

            var confirmDialog = new MessageDialog("ツイートを下書きに保存しますか？", "下書きの保存");
            confirmDialog.Commands.Add(new UICommand("保存する"));
            confirmDialog.Commands.Add(new UICommand("閉じる", (contextMenuCmd) => Frame.GoBack()));
            await confirmDialog.ShowAsync();
        }
    }
}
