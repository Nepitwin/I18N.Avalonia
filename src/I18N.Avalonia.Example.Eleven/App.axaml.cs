using Avalonia;
using Avalonia.Markup.Xaml;
using I18N.Avalonia.Prism.Example.Eleven.Views;
using I18N.Avalonia.Prism.Interface;
using Prism.DryIoc;
using Prism.Ioc;

namespace I18N.Avalonia.Prism.Example.Eleven;

public partial class App : PrismApplication
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        base.Initialize();
    }

    protected override AvaloniaObject CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterInstance<ILocalizer>(new Localizer(Properties.Resource.ResourceManager));
        containerRegistry.Register<MainWindow>();
    }
}
