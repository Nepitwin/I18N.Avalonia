using I18N.Avalonia;
using I18N.Avalonia.Interface;
using Splat;

namespace I18N.ReactiveUi.Avalonia;

public class ReactiveUiAvaloniaLocalizationExtension: LocalizationExtension
{
    public override ILocalizer Localizer
    {
        get
        {
            try
            {
                return Locator.Current.GetService<ILocalizer>() ?? new Visualizer();
            }
            catch (Exception)
            {
                // If no dependency can be found use a default visualizer
                return new Visualizer();
            }
        }
    }

    public ReactiveUiAvaloniaLocalizationExtension(string key) : base(key)
    {
    }
}