using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using I18N.Avalonia;
using I18N.Avalonia.Interface;
using Splat;
using I18N.ReactiveUi.Avalonia.Twelve.Monkeys.Views;
using I18N.ReactiveUi.Avalonia.Twelve.Monkeys.ViewModels;

namespace I18N.ReactiveUi.Avalonia.Twelve.Monkeys;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void RegisterServices()
    {
        base.RegisterServices();
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
