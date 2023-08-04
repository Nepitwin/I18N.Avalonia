using System.ComponentModel;
using System.Globalization;
using System.Resources;
using I18N.Avalonia.Interface;

namespace I18N.Avalonia;

public class Localizer : ILocalizer, INotifyPropertyChanged
{
    private const string IndexerName = "Item";
    private const string IndexerArrayName = "Item[]";

    public event Action? LanguageChangedNotification;
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly ResourceManager _resManager;
    private CultureInfo _language = new("en");

    public Localizer(ResourceManager resManager)
    {
        _resManager = resManager;
    }

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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(IndexerName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(IndexerArrayName));
            LanguageChangedNotification?.Invoke();
        }
    }
    
    public string GetValueFromCulture(string key)
    {
        return GetValueFromCulture(key, _language);
    }

    public string GetValueFromCulture(string key, CultureInfo culture)
    {
        return _resManager.GetString(key, culture) ?? $"<{key}>";
    }
}
