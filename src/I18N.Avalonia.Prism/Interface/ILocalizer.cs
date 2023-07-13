using System.Globalization;

namespace I18N.Avalonia.Prism.Interface;

public interface ILocalizer
{
    public CultureInfo DefaultLanguage { get; }
    public CultureInfo Language { get; set; }
    public string GetValueFromCulture(string key, CultureInfo culture);
    public string GetValueFromCulture(string key);
    public event Action LanguageChangedNotification;
}
