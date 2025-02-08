using Canary_Dashboard.Core.Configuration;
using Canary_Dashboard.Core.Processors;

using CanaryDataGrid.Module;

using ControlzEx.Theming;

using MahApps.Metro.Controls.Dialogs;

using Microsoft.Extensions.Configuration;

using Prism.Ioc;
using Prism.Modularity;

using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Canary_Dashboard.UI;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    protected override Window CreateShell() => Container.Resolve<MainWindow>();

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncAll;
        ThemeManager.Current.SyncTheme();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Set up the configuration using the appSettings.json file.
        var settingsFilename = "appSettings.json";

#if DEBUG
        settingsFilename = "appSettings.dev.json";
#endif

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile(settingsFilename, false, true)
            .Build();

        containerRegistry
            .RegisterInstance<IDialogCoordinator>(new DialogCoordinator())

            .Register<IAPIProcessor, CanaryAPIProcessor>()
            ;

        GlobalConfig.CanaryTokenConfiguration = new(configuration
            .GetSection("canaryTokens")
            .GetChildren()
            .Select(_ =>
            {
                var name = _.Key;
                IEnumerable<IConfigurationSection> values = _.GetChildren();
                var auth = values.FirstOrDefault(_ => _.Key == "auth")
                    ?? throw new("Auth was null for this call. Please add it to appsettings.");
                var token = values.FirstOrDefault(_ => _.Key == "token")
                    ?? throw new("Token was null for this call. Please add it to appsettings.");
                return new CanaryTokenConfigurationModel() { Name = name, Auth = auth.Value, Token = token.Value };
            }));
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) => moduleCatalog
        .AddModule<CanaryDataGridModule>()
        ;
}