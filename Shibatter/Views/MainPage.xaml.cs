using Windows.UI.Xaml;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.StoreApps;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkID=390556 を参照してください

namespace Shibatter.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : VisualStateAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }



        //private void AppBarButtonTweet_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txbTweet.Visibility = Visibility.Visible;

        //}

        ///// <summary>
        ///// このページがフレームに表示されるときに呼び出されます。
        ///// </summary>
        ///// <param name="e">このページにどのように到達したかを説明するイベント データ。
        ///// このプロパティは、通常、ページを構成するために使用します。</param>
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //}
    }
}
