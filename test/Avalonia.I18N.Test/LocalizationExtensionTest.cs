using System.Collections;
using Avalonia.Data;
using FluentAssertions;
using I18N.Avalonia.Prism;
using I18N.Avalonia.ReactiveUi;
using I18N.Avalonia.Test.Helper;
using I18N.Avalonia.Test.Helper.Interface;
using Moq;
namespace I18N.Avalonia.Test;

public class LocalizationExtensionTest
{
    public class TestLocationSourceGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] { new PrismLocalizationExtension("Key"), new PrismContainer(), typeof(Localizer) },
            new object[] { new ReactiveUiLocalizationExtension("Key"), new SplatContainer(), typeof(Localizer) },
            new object[] { new PrismLocalizationExtension("Key"), new EmptyContainer(), typeof(Visualizer) },
            new object[] { new ReactiveUiLocalizationExtension("Key"), new EmptyContainer(), typeof(Visualizer) },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(TestLocationSourceGenerator))]
    public void AvaloniaBindingCreationExpectsBinding(LocalizationExtension localizationSource, IContainerHelper containerHelper, Type expectedType)
    {
        try
        {
            containerHelper.Init();

            var mockServiceProvider = new Mock<IServiceProvider>();

            localizationSource.Key.Should().Be("Key");
            var binding = localizationSource.ProvideValue(mockServiceProvider.Object);

            binding.Should().BeOfType(typeof(Binding));

            var avaloniaBinding = (Binding)binding;
            avaloniaBinding.Path.Should().Be("[Key]");
            avaloniaBinding.Source.Should().BeOfType(expectedType);
        }
        finally
        {
            containerHelper.Destroy();
        }
    }

    [Theory]
    [ClassData(typeof(TestLocationSourceGenerator))]
    public void AvaloniaContextBindingCreationExpectsSubKeyBinding(LocalizationExtension localizationSource, IContainerHelper containerHelper, Type expectedType)
    {
        try
        {
            containerHelper.Init();

            var mockServiceProvider = new Mock<IServiceProvider>();
            localizationSource.Context = "Context";

            localizationSource.Key.Should().Be("Key");
            localizationSource.Context.Should().Be("Context");

            var binding = localizationSource.ProvideValue(mockServiceProvider.Object);

            binding.Should().BeOfType(typeof(Binding));

            var avaloniaBinding = (Binding)binding;
            avaloniaBinding.Path.Should().Be("[Context/Key]");
            avaloniaBinding.Source.Should().BeOfType(expectedType);
        }
        finally
        {
            containerHelper.Destroy();
        }
    }
}