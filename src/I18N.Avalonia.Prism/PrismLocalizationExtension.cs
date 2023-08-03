using I18N.Avalonia.Interface;
using Prism.Ioc;

namespace I18N.Avalonia.Prism;

public class PrismLocalizationExtension: LocalizationExtension
{
    public override ILocalizer Localizer => ContainerLocator.Container.Resolve<ILocalizer>();

    public PrismLocalizationExtension(string key) : base(key)
    {

    }
}
