using I18N.Avalonia.Interface;
using Prism.Ioc;

namespace I18N.Avalonia.Prism;

public class PrismLocalizationExtension: LocalizationExtension
{
    public override ILocalizer Localizer
    {
        get
        {
            try
            {
                return ContainerLocator.Container.Resolve<ILocalizer>();
            }
            catch (Exception)
            {
                return new Visualizer();
            }
        }
    }

    public PrismLocalizationExtension(string key) : base(key)
    {
    }
}
