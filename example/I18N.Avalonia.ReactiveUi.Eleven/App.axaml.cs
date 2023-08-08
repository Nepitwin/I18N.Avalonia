using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using I18N.Avalonia.Interface;
using I18N.Avalonia.ReactiveUi.Eleven.ViewModels;
using I18N.Avalonia.ReactiveUi.Eleven.Views;
using Splat;

namespace I18N.Avalonia.ReactiveUi.Eleven;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void RegisterServices()
    {
        base.RegisterServices();
        Locator.CurrentMutable.RegisterLazySingleton(() => new Localizer(Properties.Resource.ResourceManager), typeof(ILocalizer));
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(Locator.Current.GetService<ILocalizer>()!),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
