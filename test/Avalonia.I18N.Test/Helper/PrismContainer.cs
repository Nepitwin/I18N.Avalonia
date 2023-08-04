using I18N.Avalonia.Interface;
using I18N.Avalonia.Test.Helper.Interface;
using Prism.DryIoc;
using Prism.Ioc;

namespace I18N.Avalonia.Test.Helper;

public class PrismContainer: IContainerHelper
{
    public void Init()
    {
        ContainerLocator.SetContainerExtension(CreateContainerExtension);
        ContainerLocator.Current.RegisterInstance<ILocalizer>(new Localizer(Properties.Resource.ResourceManager));
    }

    public void Destroy()
    {
        ContainerLocator.ResetContainer();
    }

    private static DryIocContainerExtension CreateContainerExtension()
    {
        return new DryIocContainerExtension();
    }
}