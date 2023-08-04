using I18N.Avalonia.Interface;
using Prism.Ioc;

namespace I18N.Avalonia.Prism;

public class PrismLocalizationExtension: LocalizationExtension
{
    public PrismLocalizationExtension(string key) : base(key)
    {

    }

    public override ILocalizer GetLocalizerOrDefault()
    {
        try
        {
            return ContainerLocator.Container.Resolve<ILocalizer>();
        }
        catch (Exception)
        {
            // If no dependency can be found use an default visualizer
            return new Visualizer();
        }
    }
}
