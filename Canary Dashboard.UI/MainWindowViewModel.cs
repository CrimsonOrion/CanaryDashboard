using Canary_Dashboard.Core;

using Prism.Mvvm;
using Prism.Regions;

namespace Canary_Dashboard.UI;
public class MainWindowViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;

    #region Main Window Properties

    public static string Title => $"Canary Dashboard v{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";

    #endregion

    #region Delegate Commands

    #endregion

    #region Constructor

    public MainWindowViewModel(IRegionManager regionManager) => _regionManager = regionManager;

    #endregion

    #region Private Methods

    private void Navigate(string navigationPath, NavigationParameters navigationParameters = null) => _regionManager.RequestNavigate(KnownRegionNames.MainRegion, navigationPath, navigationParameters);

    #endregion
}