using Canary_Dashboard.Core.Models;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;

using System.Diagnostics;

namespace CanaryDataGrid.Module.ViewModels;
public class CanaryXlsxDetailViewModel : BindableBase, INavigationAware
{
    #region Canary Xlsx Detail View Properties

    private CanaryXlsxModel _canary = new();
    public CanaryXlsxModel Canary
    {
        get => _canary;
        set => SetProperty(ref _canary, value);
    }

    #endregion

    #region Delegate Commands

    public DelegateCommand GoToWebsiteCommand => new(GoToWebsite);

    #endregion

    #region Constructor

    public CanaryXlsxDetailViewModel() { }

    #endregion

    #region Methods

    #region Navigation

    public bool IsNavigationTarget(NavigationContext navigationContext) => true;
    public void OnNavigatedFrom(NavigationContext navigationContext) => Canary = new();
    public void OnNavigatedTo(NavigationContext navigationContext) => Canary = navigationContext.Parameters.GetValue<CanaryXlsxModel>("canary");

    #endregion

    #region Private

    private void GoToWebsite() => Process.Start(new ProcessStartInfo() { FileName = Canary.Website, UseShellExecute = true });

    #endregion

    #endregion
}