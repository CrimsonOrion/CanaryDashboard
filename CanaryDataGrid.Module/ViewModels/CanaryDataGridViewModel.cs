using Canary_Dashboard.Core;
using Canary_Dashboard.Core.Configuration;
using Canary_Dashboard.Core.Models;
using Canary_Dashboard.Core.Processors;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Regions;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CanaryDataGrid.Module.ViewModels;
public class CanaryDataGridViewModel(IRegionManager regionManager, IAPIProcessor processor) : BindableBase, INavigationAware
{
    #region Canary DataGrid View Properties

    private ObservableCollection<CanaryBaseModel> _canaryBaseList = [];
    public ObservableCollection<CanaryBaseModel> CanaryBaseList
    {
        get => _canaryBaseList;
        set => SetProperty(ref _canaryBaseList, value);
    }

    private CanaryBaseModel _selectedCanary = new();
    public CanaryBaseModel SelectedCanary
    {
        get => _selectedCanary;
        set
        {
            _ = SetProperty(ref _selectedCanary, value);
            DisplayDetails();
        }
    }

    public List<CanaryDocxModel> CanaryDocxList { get; set; } = [];
    public List<CanaryXlsxModel> CanaryXlsxList { get; set; } = [];
    public List<CanaryFolderModel> CanaryFolderList { get; set; } = [];

    #endregion

    #region Delegate Commands

    public DelegateCommand LoadCommand => new(Load);

    #endregion

    #region Methods

    #region Navigation

    public bool IsNavigationTarget(NavigationContext navigationContext) => true;
    public void OnNavigatedFrom(NavigationContext navigationContext) { }
    public void OnNavigatedTo(NavigationContext navigationContext) { }

    #endregion

    #region Private

    private async void Load()
    {
        CanaryBaseList = [];
        CanaryFolderList = [];
        CanaryDocxList = [];
        CanaryXlsxList = [];
        List<CanaryAlarm> list = await processor.GetCanaryAlarmsAsync(GlobalConfig.CanaryTokenConfiguration);
        var id = 0;
        foreach (CanaryAlarm alarm in list)
        {
            switch (alarm.HitInformation!.TokenType)
            {
                case "windows_dir":
                    CanaryFolderModel dataF = new(id, alarm);
                    CanaryFolderList.Add(dataF);
                    CanaryBaseList.Add(dataF);
                    break;
                case "ms_excel":
                    CanaryXlsxModel dataX = new(id, alarm);
                    CanaryXlsxList.Add(dataX);
                    CanaryBaseList.Add(dataX);
                    break;
                case "ms_word":
                    CanaryDocxModel dataD = new(id, alarm);
                    CanaryDocxList.Add(dataD);
                    CanaryBaseList.Add(dataD);
                    break;
            }
            id++;
        }
    }

    private void DisplayDetails()
    {
        if (SelectedCanary is null)
        {
            return;
        }

        switch (SelectedCanary.TokenType)
        {
            case "windows_dir":
                var folder = CanaryFolderList.FirstOrDefault(_ => _.ID == SelectedCanary.ID);
                if (folder is not null)
                {
                    Navigate(KnownViewNames.CanaryFolderDetailView, new() { { "canary", folder } });
                }
                break;
            case "ms_excel":
                var xlsx = CanaryXlsxList.FirstOrDefault(_ => _.ID == SelectedCanary.ID);
                if (xlsx is not null)
                {
                    Navigate(KnownViewNames.CanaryXlsxDetailView, new() { { "canary", xlsx } });
                }
                break;
            case "ms_word":
                var word = CanaryDocxList.FirstOrDefault(_ => _.ID == SelectedCanary.ID);
                if (word is not null)
                {
                    Navigate(KnownViewNames.CanaryDocxDetailView, new() { { "canary", word } });
                }
                break;
            default:
                break;
        }
    }

    private void Navigate(string navigationPath, NavigationParameters navigationParameters) => regionManager.RequestNavigate(KnownRegionNames.DetailsRegion, navigationPath, navigationParameters);

    #endregion

    #endregion
}