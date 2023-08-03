using I18N.Avalonia.Interface;
using Splat;

namespace I18N.Avalonia.ReactiveUi;

public class ReactiveUiLocalizationExtension: LocalizationExtension
{
    public override ILocalizer Localizer => Locator.Current.GetService<ILocalizer>();

    public ReactiveUiLocalizationExtension(string key) : base(key)
    {
    }
}
