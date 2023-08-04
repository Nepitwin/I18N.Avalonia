using I18N.Avalonia.Interface;
using Splat;

namespace I18N.Avalonia.ReactiveUi;

public class ReactiveUiLocalizationExtension: LocalizationExtension
{
    public ReactiveUiLocalizationExtension(string key) : base(key)
    {
    }

    public override ILocalizer GetLocalizerOrDefault()
    {
        try
        {
            var localizer = Locator.Current.GetService<ILocalizer>();
            return localizer ?? new Visualizer();
        }
        catch (Exception)
        {
            // If no dependency can be found use an default visualizer
            return new Visualizer();
        }
    }
}
