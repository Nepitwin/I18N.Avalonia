using System.Globalization;
using I18N.Avalonia.Interface;

namespace I18N.Avalonia;

public class Visualizer: ILocalizer
{
    public event Action? LanguageChangedNotification;
    private CultureInfo _language = new("en");
    
    public string this[string key] => GetValueFromCulture(key, _language);

    public CultureInfo Language
    {
        get => _language;
        set
        {
            if (Equals(_language, value))
            {
                return;
            }

            _language = value;
        }
    }

    public string GetValueFromCulture(string key)
    {
        return GetValueFromCulture(key, _language);
    }

    public string GetValueFromCulture(string key, CultureInfo culture)
    {
        return $"<{key}>";
    }
}