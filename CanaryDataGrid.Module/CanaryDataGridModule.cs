using Canary_Dashboard.Core;

using CanaryDataGrid.Module.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;

namespace CanaryDataGrid.Module;
public class CanaryDataGridModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider) => containerProvider
            .Resolve<IRegionManager>()
            .RegisterViewWithRegion(KnownRegionNames.MainRegion, typeof(CanaryDataGridView));
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<CanaryDataGridView>();
        containerRegistry.RegisterForNavigation<CanaryFolderDetailView>();
        containerRegistry.RegisterForNavigation<CanaryDocxDetailView>();
        containerRegistry.RegisterForNavigation<CanaryXlsxDetailView>();
    }
}