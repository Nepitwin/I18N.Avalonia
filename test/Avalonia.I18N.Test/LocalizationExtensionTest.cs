using Avalonia.Data;
using FluentAssertions;
using I18N.Avalonia.Interface;
using I18N.Avalonia.Prism;
using Moq;
using Prism.DryIoc;
using Prism.Ioc;

namespace I18N.Avalonia.Test;

public class LocalizationExtensionTest
{
    public LocalizationExtensionTest()
    {
        ContainerLocator.SetContainerExtension((Func<DryIocContainerExtension>?)CreateContainerExtension);
        ContainerLocator.Current.RegisterSingleton<ILocalizer, Localizer>();
    }

    [Fact]
    public void AvaloniaBindingCreationExpectsKeyBinding()
    {
        var mockServiceProvider = new Mock<IServiceProvider>();
        var localizationSource = new PrismLocalizationExtension("Key");
        localizationSource.Key.Should().Be("Key");
        var binding = localizationSource.ProvideValue(mockServiceProvider.Object);

        binding.Should().BeOfType(typeof(Binding));

        var avaloniaBinding = (Binding)binding;
        avaloniaBinding.Path.Should().Be("[Key]");
        avaloniaBinding.Source.Should().BeOfType(typeof(Localizer));
    }

    [Fact]
    public void AvaloniaContextBindingCreationExpectsSubKeyBinding()
    {
        var mockServiceProvider = new Mock<IServiceProvider>();
        var localizationSource = new PrismLocalizationExtension("Key")
        {
            Context = "Context"
        };

        localizationSource.Key.Should().Be("Key");
        localizationSource.Context.Should().Be("Context");

        var binding = localizationSource.ProvideValue(mockServiceProvider.Object);

        binding.Should().BeOfType(typeof(Binding));

        var avaloniaBinding = (Binding)binding;
        avaloniaBinding.Path.Should().Be("[Context/Key]");
        avaloniaBinding.Source.Should().BeOfType(typeof(Localizer));
    }

    private static DryIocContainerExtension CreateContainerExtension()
    {
        return new DryIocContainerExtension();
    }
}