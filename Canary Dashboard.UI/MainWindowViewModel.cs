using Canary_Dashboard.Core;

using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Regions;

namespace Canary_Dashboard.UI;
public class MainWindowViewModel(IRegionManager regionManager) : BindableBase
{
    #region Main Window Properties

    public static string Title => $"Canary Dashboard v{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";

    #endregion

    #region Private Methods

    private void Navigate(string navigationPath, NavigationParameters navigationParameters) => regionManager.RequestNavigate(KnownRegionNames.MainRegion, navigationPath, navigationParameters);

    #endregion
}