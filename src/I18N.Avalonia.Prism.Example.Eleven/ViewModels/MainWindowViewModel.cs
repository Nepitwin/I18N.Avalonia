using System;
using System.Globalization;
using I18N.Avalonia.Interface;
using Prism.Commands;
using Prism.Mvvm;

namespace I18N.Avalonia.Prism.Example.Eleven.ViewModels;

public class MainWindowViewModel: BindableBase
{
    public DelegateCommand<string> SwitchLanguage { get; private set; }

    private readonly ILocalizer _localizer;

    public MainWindowViewModel(ILocalizer localizer)
    {
        _localizer = localizer;
        _localizer.LanguageChangedNotification += LanguageChangedNotification;

        SwitchLanguage = new DelegateCommand<string>(Submit);
    }

    private void LanguageChangedNotification()
    {
        Console.WriteLine(@"Change language to" + _localizer.Language.TwoLetterISOLanguageName);
    }

    void Submit(string language)
    {
        _localizer.Language = new CultureInfo(language);
    }
}