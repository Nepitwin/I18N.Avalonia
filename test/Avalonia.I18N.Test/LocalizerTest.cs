using System.Collections;
using System.Globalization;
using FluentAssertions;
using I18N.Avalonia.Interface;

namespace I18N.Avalonia.Test;

public class LocalizerTest
{
    public class TestLocalizerGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] { typeof(Localizer)},
            new object[] { typeof(Visualizer)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class TestLocalizerTranslatorGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            // English language
            new object[] { new Localizer(Properties.Resource.ResourceManager), new CultureInfo("en"), "Lang_en", "EN_ENG" },
            new object[] { new Visualizer(), new CultureInfo("en"), "Lang_en", "<Lang_en>" },
            // Language switch test
            new object[] { new Localizer(Properties.Resource.ResourceManager), new CultureInfo("de"), "Lang_de", "DE_GER" },
            new object[] { new Visualizer(), new CultureInfo("de"), "Lang_de", "<Lang_de>" },
            // Translation not existing test
            new object[] { new Localizer(Properties.Resource.ResourceManager), new CultureInfo("en"), "NOT_EXISTING", "<NOT_EXISTING>" },
            new object[] { new Visualizer(), new CultureInfo("en"), "NOT_EXISTING", "<NOT_EXISTING>" },
            // Neutral language test
            new object[] { new Localizer(Properties.Resource.ResourceManager), new CultureInfo("bg"), "Lang_en", "EN_ENG" },
            new object[] { new Visualizer(), new CultureInfo("bg"), "Lang_en", "<Lang_en>" },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(TestLocalizerTranslatorGenerator))]
    public void GetValueFromCultureShouldReturnTranslation(ILocalizer localizer, CultureInfo culture, string key, string expectedTranslation)
    {
        localizer.Language = culture;
        localizer[key].Should().Be(expectedTranslation);
        localizer.GetValueFromCulture(key).Should().Be(expectedTranslation);
        localizer.GetValueFromCulture(key, culture).Should().Be(expectedTranslation);
    }

    [Theory]
    [ClassData(typeof(TestLocalizerGenerator))]
    public void EventsCalledIfLanguageIsChanged(Type typeLocalizer)
    {
        var localizer = CreateLocalizer(typeLocalizer);
        var events = localizer.Monitor();
        localizer.Language = new CultureInfo("kgb");
        events.Should().Raise("PropertyChanged");
        events.Should().Raise("LanguageChangedNotification");
    }

    [Theory]
    [ClassData(typeof(TestLocalizerGenerator))]
    public void EventsNotCalledByEqualLanguage(Type typeLocalizer)
    {
        var localizer = CreateLocalizer(typeLocalizer);
        var events = localizer.Monitor();
        localizer.Language = new CultureInfo("en");
        events.Should().NotRaise("PropertyChanged");
        events.Should().NotRaise("LanguageChangedNotification");
    }

    public ILocalizer CreateLocalizer(Type type)
    {
        if (type == typeof(Localizer))
        {
            return new Localizer(Properties.Resource.ResourceManager);
        }

        if (type == typeof(Visualizer))
        {
            return new Visualizer();
        }

        throw new NotSupportedException();
    }
}
