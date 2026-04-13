using Avalonia;
using I18N.Avalonia;
using I18N.Avalonia.Interface;
using ReactiveUI;
using ReactiveUI.Avalonia;
using Splat;
using System;
using System.Reflection;

namespace I18N.ReactiveUi.Avalonia.Twelve.Monkeys;

internal class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseSkia()
            .LogToTrace()
            .UseReactiveUI(rxAppBuilder =>
            {
                // Enable ReactiveUI
                rxAppBuilder
                  .WithViewsFromAssembly(Assembly.GetExecutingAssembly())
                  .WithRegistration(locator =>
                  {
                      // Register your services here
                      locator.RegisterLazySingleton<ILocalizer>(() => new Localizer(Properties.Resource.ResourceManager));
                  });
            }).RegisterReactiveUIViewsFromEntryAssembly();
}
