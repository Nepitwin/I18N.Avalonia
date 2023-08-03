using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using I18N.Avalonia.Interface;
using Splat;

namespace I18N.Avalonia.ReactiveUi;

public class LocalizationExtension: MarkupExtension
{
    public string Key { get; set; }

    public string Context { get; set; } = string.Empty;

    private readonly ILocalizer _locationSource;

    public LocalizationExtension(string key)
    {
        Key = key;
        _locationSource = Locator.Current.GetService<ILocalizer>();
    }
    
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var keyToUse = Key;

        if (!string.IsNullOrWhiteSpace(Context))
        {
            keyToUse = $"{Context}/{Key}";
        }

        var binding = new ReflectionBindingExtension($"[{keyToUse}]")
        {
            Mode = BindingMode.OneWay,
            Source = _locationSource
        };

        return binding.ProvideValue(serviceProvider);
    }
}
