using Canary_Dashboard.Core.Models;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using System.Diagnostics;

namespace CanaryDataGrid.Module.ViewModels;
public class CanaryDocxDetailViewModel : BindableBase, INavigationAware
{
    #region Canary Docx Detail View Properties

    private CanaryDocxModel _canary;
    public CanaryDocxModel Canary
    {
        get => _canary;
        set => SetProperty(ref _canary, value);
    }

    #endregion

    #region Delegate Commands

    public DelegateCommand GoToWebsiteCommand => new(GoToWebsite);

    #endregion

    #region Constructor

    public CanaryDocxDetailViewModel() { }

    #endregion

    #region Methods

    #region Navigation

    public bool IsNavigationTarget(NavigationContext navigationContext) => true;
    public void OnNavigatedFrom(NavigationContext navigationContext) => Canary = new();
    public void OnNavigatedTo(NavigationContext navigationContext) => Canary = navigationContext.Parameters.GetValue<CanaryDocxModel>("canary");

    #endregion

    #region Private

    private void GoToWebsite() => Process.Start(new ProcessStartInfo() { FileName = Canary.Website, UseShellExecute = true });

    #endregion

    #endregion
}