using System.Globalization;
using FluentAssertions;

namespace Avalonia.Prism.I18N.Test;

public class LocalizerTest
{
    [Fact]
    public void GetValueFromCultureShouldReturnEnglishTranslation()
    {
        var localizationSource = new Localizer(Properties.Resource.ResourceManager);
        localizationSource["Lang_en"].Should().Be("EN_ENG");
        localizationSource.GetValueFromCulture("Lang_en").Should().Be("EN_ENG");
    }
    
    [Fact]
    public void GetValueFromCultureShouldReturnGermanTranslation()
    {
        var localizationSource = new Localizer(Properties.Resource.ResourceManager)
        {
            Language = new CultureInfo("de")
        };
        localizationSource["Lang_de"].Should().Be("DE_GER");
        localizationSource.GetValueFromCulture("Lang_de").Should().Be("DE_GER");
    }
    
    [Fact]
    public void DirectLocalizationUsageShouldBeEqualToGetValueFromCulture()
    {
        var localizer = new Localizer(Properties.Resource.ResourceManager);
        localizer["Lang_en"].Should().Be("EN_ENG");
        localizer.GetValueFromCulture("Lang_en", localizer.Language).Should().Be("EN_ENG");
    }

    [Fact]
    public void UnknownLocalizationShouldReturnEmptyString()
    {
        var localizer = new Localizer(Properties.Resource.ResourceManager);
        localizer["NOT_EXISTING"].Should().BeEmpty();
        localizer.GetValueFromCulture("NOT_EXISTING", localizer.Language).Should().BeEmpty();
    }

    [Fact]
    public void OnPropertyChangedIsCalledIfCultureIsChanged()
    {
        var localizer = new Localizer(Properties.Resource.ResourceManager);
        var events = localizer.Monitor();
        localizer.Language = new CultureInfo("kgb");
        events.Should().Raise("PropertyChanged");
    }

    [Fact]
    public void LocalizationChangedNotificationIsCalledIfCultureIsChanged()
    {
        var localizer = new Localizer(Properties.Resource.ResourceManager);
        var events = localizer.Monitor();
        localizer.Language = new CultureInfo("kgb");
        events.Should().Raise("LanguageChangedNotification");
    }

    [Fact]
    public void NoNotificationsByEqualLanguageIsChanged()
    {
        var localizer = new Localizer(Properties.Resource.ResourceManager)
        {
            Language = new CultureInfo("en")
        };
        var events = localizer.Monitor();
        localizer.Language = new CultureInfo("en");

        events.Should().NotRaise("PropertyChanged");
        events.Should().NotRaise("LanguageChangedNotification");
    }
}
