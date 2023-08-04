using I18N.Avalonia.Interface;
using I18N.Avalonia.Test.Helper.Interface;
using Splat;

namespace I18N.Avalonia.Test.Helper;

public class SplatContainer: IContainerHelper
{
    public void Init()
    {
        Locator.CurrentMutable.RegisterLazySingleton(() => new Localizer(Properties.Resource.ResourceManager), typeof(ILocalizer));
    }

    public void Destroy()
    {
        Locator.CurrentMutable.UnregisterAll<ILocalizer>();
    }
}