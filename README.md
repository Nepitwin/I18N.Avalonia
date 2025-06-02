# Avalonia Internationalizing

[license]: https://img.shields.io/github/license/Nepitwin/I18N.Avalonia?style=flat-square

[LinuxBuild]: https://github.com/Nepitwin/I18N.Avalonia/actions/workflows/linux.yml/badge.svg?branch=main
[MacOSBuild]: https://github.com/Nepitwin/I18N.Avalonia/actions/workflows/macos.yml/badge.svg?branch=main
[WindowsBuild]: https://github.com/Nepitwin/I18N.Avalonia/actions/workflows/windows.yml/badge.svg?branch=main

[NetCore]: https://img.shields.io/badge/NetCore-blue
[3]: https://img.shields.io/badge/3-Support-blue
[5]: https://img.shields.io/badge/5-Support-blue
[6]: https://img.shields.io/badge/6-Support-blue
[7]: https://img.shields.io/badge/7-Support-blue
[8]: https://img.shields.io/badge/8-Support-blue
[9]: https://img.shields.io/badge/9-Support-blue

[Ava-0X]: https://img.shields.io/badge/0.21-Support-green
[Ava-11]: https://img.shields.io/badge/11-Support-green

|                |                                                   |
|----------------|---------------------------------------------------|
| License        | ![][license]                                      |
| Builds         | ![][LinuxBuild] ![][MacOSBuild] ![][WindowsBuild] |
| .NET Core      | ![][3] ![][5] ![][6] ![][7] ![][8] ![][9]         |
| Avalonia       | ![][Ava-0X] ![][Ava-11]                           |
| Core           | [![](https://img.shields.io/nuget/v/I18N.Avalonia.svg)](https://www.nuget.org/packages/I18N.Avalonia) |
| Prism          | [![](https://img.shields.io/nuget/v/I18N.Avalonia.Prism.svg)](https://www.nuget.org/packages/I18N.Avalonia.Prism) |
| Reactive       | [![](https://img.shields.io/nuget/v/I18N.Avalonia.ReactiveUi.svg)](https://www.nuget.org/packages/I18N.Avalonia.ReactiveUi) |

[![][NugetCore](https://www.nuget.org/packages/I18N.Avalonia)]

| Prism                                        | ReactiveUi                                        |
|----------------------------------------------|---------------------------------------------------|
| ![][Prism-Example]  | ![][Reactive-Example] |

# How to use it

## Ressource manager files (.resx)

* Recommended tool to manage resx files is ResXResourceManager
  *  https://github.com/dotnet/ResXResourceManager

### Prism registration

```dotnet
protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
    containerRegistry.RegisterInstance<ILocalizer>(new Localizer(Properties.Resource.ResourceManager));
}
```

Include prism internationalizing module by .axaml

```
xmlns:i18N="clr-namespace:I18N.Avalonia.Prism;assembly=I18N.Avalonia.Prism"
```

### Usage in .axaml

```
<StackPanel>
    <TextBlock Text="{i18N:PrismLocalization Welcome}"
               HorizontalAlignment="Center"
               VerticalAlignment="Center"
               Margin="0, 24, 0,24"
               FontSize="17"
               FontWeight="Heavy" />

    <Button Content="{i18N:PrismLocalization English}"
            Margin="0,0,0,8"
            Command="{Binding SwitchLanguage}"
            CommandParameter="en"/>

    <Button Content="{i18N:PrismLocalization German}"
            Margin="0,0,0,8"
            Command="{Binding SwitchLanguage}"
            CommandParameter="de"/>

</StackPanel>
```

### ReactiveUi registration (Splat)

```dotnet
public override void RegisterServices()
{
    base.RegisterServices();
    Locator.CurrentMutable.RegisterLazySingleton(() => new Localizer(Properties.Resource.ResourceManager), typeof(ILocalizer));
}
```

Include reactive internatinalizing module by .axaml

```
xmlns:i18N="clr-namespace:I18N.Avalonia.ReactiveUi;assembly=I18N.Avalonia.ReactiveUi"
```

### Usage in .axaml

```
<StackPanel>
    <TextBlock Text="{i18N:ReactiveUiLocalization Welcome}"
                HorizontalAlignment="Center"
                VerticalAlignment="Center"
                Margin="0, 24, 0,24"
                FontSize="17"
                FontWeight="Heavy" />

    <Button Content="{i18N:ReactiveUiLocalization English}"
            Margin="0,0,0,8"
            Command="{Binding SwitchLanguage}"
            CommandParameter="en"/>

    <Button Content="{i18N:ReactiveUiLocalization German}"
            Margin="0,0,0,8"
            Command="{Binding SwitchLanguage}"
            CommandParameter="de"/>

</StackPanel>
```

### Usage in model view

```
public LanguageViewModel(ILocalizer i18N)
{
    i18N.LanguageChangedNotification += OnLanguageChangedNotification;
}

private void OnLanguageChangedNotification()
{
    Console.WriteLine(@"Change language to" + _localizer.Language.TwoLetterISOLanguageName);
    // Your binding can be changed here or notify property changed can be called to refresh
}
```

### Language change

* After language is set all binding properties will be automatic refreshed and LanguageChangedNotification is called to refresh bindings.

```
public LanguageViewModel(ILocalizer i18N)
{
    i18N.Language = new CultureInfo("de");
}
```

# Acknowledgment

Thanks to Sakya which has written this nice blog to understand this behavior and to build a nuget package with some changes.

-   <https://www.sakya.it/wordpress/avalonia-ui-framework-localization>
