using Avalonia.Data;
using Avalonia.Markup.Xaml;
using I18N.Avalonia.Interface;

namespace I18N.Avalonia;

public abstract class LocalizationExtension: MarkupExtension, ILocalizerContainer
{
    public abstract ILocalizer Localizer { get; }
    
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

        return new ReflectionBinding($"[{keyToUse}]")
        {
            Mode = BindingMode.OneWay,
            Source = Localizer
        };
    }
}
