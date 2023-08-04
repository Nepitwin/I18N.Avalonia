using System.Globalization;

namespace I18N.Avalonia.Interface;

public interface ILocalizer
{
    public CultureInfo Language { get; set; }
    public string GetValueFromCulture(string key, CultureInfo culture);
    public string GetValueFromCulture(string key);

    public event Action LanguageChangedNotification;
}
