using ReactiveUI;
using System.Globalization;
using System;
using I18N.Avalonia.Interface;
using System.Reactive;

namespace I18N.Avalonia.ReactiveUi.Zero.ViewModels;

public class MainWindowViewModel: ReactiveObject
{
    private readonly ILocalizer _localizer;
    public ReactiveCommand<string, Unit> SwitchLanguage { get; }

    public MainWindowViewModel(ILocalizer localizer)
    {
        _localizer = localizer;
        SwitchLanguage = ReactiveCommand.Create<string>(LanguageSwitch);
        _localizer.LanguageChangedNotification += LanguageChangedNotification;
    }

    private void LanguageChangedNotification()
    {
        Console.WriteLine(@"Change language to" + _localizer.Language.TwoLetterISOLanguageName);
    }

    private void LanguageSwitch(string language)
    {
        _localizer.Language = new CultureInfo(language);
    }
}