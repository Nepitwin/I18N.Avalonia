using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using I18N.Avalonia.Interface;

namespace I18N.Avalonia;

public abstract class LocalizationExtension: MarkupExtension, ILocalizerContainer
{
    public abstract ILocalizer GetLocalizerOrDefault();

    public string Key { get; set; }

    public string Context { get; set; } = string.Empty;

    protected LocalizationExtension(string key)
    {
        Key = key;
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
            Source = GetLocalizerOrDefault()
        };

        return binding.ProvideValue(serviceProvider);
    }
}
