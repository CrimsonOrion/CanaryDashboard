using Canary_Dashboard.Core;
using Canary_Dashboard.Core.Configuration;
using Canary_Dashboard.Core.Models;
using Canary_Dashboard.Core.Processors;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CanaryDataGrid.Module.ViewModels;
public class CanaryDataGridViewModel : BindableBase, INavigationAware
{
    private readonly IRegionManager _regionManager;
    private readonly IAPIProcessor _processor;

    #region Canary DataGrid View Properties

    private ObservableCollection<ICanaryBaseModel> _canaryBaseList;
    public ObservableCollection<ICanaryBaseModel> CanaryBaseList
    {
        get => _canaryBaseList;
        set => SetProperty(ref _canaryBaseList, value);
    }

    private ICanaryBaseModel _selectedCanary;
    public ICanaryBaseModel SelectedCanary
    {
        get => _selectedCanary;
        set
        {
            SetProperty(ref _selectedCanary, value);
            DisplayDetails();
        }
    }

    public List<CanaryDocxModel> CanaryDocxList { get; set; }
    public List<CanaryXlsxModel> CanaryXlsxList { get; set; }
    public List<CanaryFolderModel> CanaryFolderList { get; set; }

    #endregion

    #region Delegate Commands

    public DelegateCommand LoadCommand => new(Load);

    #endregion

    #region Constructor

    public CanaryDataGridViewModel(IRegionManager regionManager, IAPIProcessor processor)
    {
        _regionManager = regionManager;
        _processor = processor;
    }

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
        CanaryBaseList = new();
        CanaryFolderList = new();
        CanaryDocxList = new();
        CanaryXlsxList = new();
        List<CanaryJsonAPIModel> list = await _processor.GetCanaryListAsync(GlobalConfig.CanaryTokenConfiguration);
        var id = 0;
        foreach (CanaryJsonAPIModel alarm in list)
        {
            switch (alarm.InputChannel)
            {
                case "DNS":
                    CanaryFolderModel dataF = _processor.GetCanaryFolder(id, alarm);
                    dataF.Type = "Folder";
                    CanaryFolderList.Add(dataF);
                    CanaryBaseList.Add(dataF);
                    break;
                case "HTTP":
                    GeoInfoModel geo = alarm.GeoInfo as GeoInfoModel;
                    if (geo.Asn?.AsnNumber is not null)
                    {
                        CanaryXlsxModel dataX = _processor.GetCanaryXlsx(id, alarm);
                        dataX.Type = "Xlsx";
                        CanaryXlsxList.Add(dataX);
                        CanaryBaseList.Add(dataX);
                    }
                    else
                    {
                        CanaryDocxModel dataD = _processor.GetCanaryDocx(id, alarm);
                        dataD.Type = "Docx";
                        CanaryDocxList.Add(dataD);
                        CanaryBaseList.Add(dataD);
                    }
                    break;
            }
            id++;
        }
    }

    private void DisplayDetails()
    {
        switch (SelectedCanary.Type)
        {
            case "Folder":
                Navigate(KnownViewNames.CanaryFolderDetailView, new() { { "canary", CanaryFolderList.FirstOrDefault(_ => _.ID == SelectedCanary.ID) } });
                break;
            case "Xlsx":
                Navigate(KnownViewNames.CanaryXlsxDetailView, new() { { "canary", CanaryXlsxList.FirstOrDefault(_ => _.ID == SelectedCanary.ID) } });
                break;
            case "Docx":
                Navigate(KnownViewNames.CanaryDocxDetailView, new() { { "canary", CanaryDocxList.FirstOrDefault(_ => _.ID == SelectedCanary.ID) } });
                break;
            default:
                break;
        }

    }

    private void Navigate(string navigationPath, NavigationParameters navigationParameters = null) => _regionManager.RequestNavigate(KnownRegionNames.DetailsRegion, navigationPath, navigationParameters);

    #endregion

    #endregion
}