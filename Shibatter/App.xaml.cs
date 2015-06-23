using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Practices.Prism.Mvvm;
using Shibatter.ViewModels;
using Shibatter.Views;

namespace Shibatter
{
    /// <summary>
    /// 既定の Application クラスに対してアプリケーション独自の動作を実装します。
    /// </summary>
    public sealed partial class App : MvvmAppBase
    {
        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            var rootFrame = (Frame) Window.Current.Content;
            if (rootFrame != null)
            {
                rootFrame.Language = ApplicationLanguages.Languages[0];
            }
            Window.Current.Activate();

            NavigationService.Navigate("Main", args.Arguments);
            return Task.FromResult(default(object));
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            ViewModelLocationProvider.Register(
                typeof(MainPage).FullName, () => new MainPageViewModel(this.NavigationService));
            ViewModelLocationProvider.Register(
                typeof(TweetPage).FullName, () => new TweetPageViewModel());
            return base.OnInitializeAsync(args);
        } 
    }
}