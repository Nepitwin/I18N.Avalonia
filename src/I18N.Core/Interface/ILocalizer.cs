using System.ComponentModel;
using System.Globalization;

namespace I18N.Avalonia.Interface;

public interface ILocalizer: INotifyPropertyChanged
{
    public string this[string key] => GetValueFromCulture(key, Language);
    public CultureInfo Language { get; set; }
    public string GetValueFromCulture(string key, CultureInfo culture);
    public string GetValueFromCulture(string key);

    public event Action LanguageChangedNotification;
}
