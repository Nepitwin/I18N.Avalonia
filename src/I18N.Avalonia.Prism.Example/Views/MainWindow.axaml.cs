using Avalonia;
using Avalonia.Controls;

namespace I18N.Avalonia.Prism.Example.Zero.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }
}
