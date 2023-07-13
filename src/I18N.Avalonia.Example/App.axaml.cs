using Avalonia;
using Avalonia.Markup.Xaml;
using I18N.Avalonia.Prism;
using I18N.Avalonia.Prism.Interface;
using Prism.DryIoc;
using Prism.Ioc;
using MainWindow = I18N.Prism.Example.Views.MainWindow;

namespace I18N.Prism.Example;

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
